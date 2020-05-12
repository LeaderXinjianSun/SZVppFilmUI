using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace ModbusServo
{
    public class ModbusRTURead
    {
        public SerialPort curSerialPort = new SerialPort();

        public void ModbusInit(String PortName, int BaudRate, Parity Parity, int DataBits, StopBits StopBits)
        {
            curSerialPort.PortName = PortName;
            curSerialPort.BaudRate = BaudRate;
            curSerialPort.Parity = Parity;
            curSerialPort.DataBits = DataBits;
            curSerialPort.StopBits = StopBits;
        }
        public bool ModbusConnect()
        {
            bool isConnected = false;
            int connectCounts = 0;
            while (curSerialPort?.PortName != "" && curSerialPort?.IsOpen == false && isConnected == false && connectCounts < 10)
            {
                try
                {
                    curSerialPort.Open();
                    isConnected = true;
                }
                catch
                {
                    System.Threading.Thread.Sleep(500);
                    connectCounts++;
                    isConnected = false;
                }
            }
            return isConnected;
        }

        public void ModbusDisConnect()
        {
            try
            {
                curSerialPort?.Close();
            }
            catch { }
        }
        private object SerialLock = new object();
        private string mRecStr;
        public string Read(string coilAddress, string deviceID = "01", string coilCount = "0002")
        {
            string functionCode, coilStartlAddress, coliValue;
            string modbusStr;
           
            functionCode = "03";
            coilStartlAddress = coilAddress;
            modbusStr = deviceID + functionCode + coilStartlAddress + coilCount;

            byte[] mByteToWrite = StrToByte(modbusStr);

            int len = Convert.ToInt32(coilCount, 16);

            len = len * 2 + 5;
            
            lock (SerialLock)
            {
                mRecStr = "";
                curSerialPort.ReadExisting();
                curSerialPort.Write(mByteToWrite, 0, mByteToWrite.Length);

                //Thread.Sleep(20);
                int mCount = curSerialPort.BytesToRead;
                int mtiemout = 0;
                while (mCount < len)
                {
                    mCount = curSerialPort.BytesToRead;
                    System.Threading.Thread.Sleep(1);
                    mtiemout++;
                    if (mtiemout > 100)
                    {
                        curSerialPort.ReadExisting();
                        return "";
                    }
                }

                byte[] mRecByte = new byte[len];
                curSerialPort.Read(mRecByte, 0, len);
                mRecStr = "";
                for (int ctick = 0; ctick < len; ctick++)
                {
                    mRecStr = mRecStr + mRecByte[ctick].ToString("X2");
                }

                int m;
                if (mRecStr.Contains(deviceID + functionCode))
                {
                    m = 2 * Convert.ToInt32(mRecStr.Substring(4, 2), 16);
                    coliValue = mRecStr.Substring(6, m);


                  

                    return coliValue;
                }
                //Tool.DebugInfo("读取PLC失败!");
                return "";
            }
        }
        private byte[] StrToByte(string mStr)
        {
            int wCrc = 0xFFFF;
            int wPolynom = 0xA001;
            mStr = mStr.Trim();
            int count = mStr.Length / 2;
            byte[] b = new byte[count + 2];
            for (int ctick = 0; ctick < count; ctick++)
            {
                string temp = mStr.Substring(ctick * 2, 2);
                b[ctick] = Convert.ToByte(temp, 16);
                wCrc ^= b[ctick];
                for (int j = 0; j < 8; j++)
                {
                    if ((wCrc & 0x0001) != 0)
                    { wCrc = (wCrc >> 1) ^ wPolynom; }
                    else { wCrc = wCrc >> 1; }
                }
            }
            string strCrc = wCrc.ToString("X4");
            b[count] = Convert.ToByte(strCrc.Substring(2, 2), 16);
            b[count + 1] = Convert.ToByte(strCrc.Substring(0, 2), 16);

            return b;
        }
    }
}
