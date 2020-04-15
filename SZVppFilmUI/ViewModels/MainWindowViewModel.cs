using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingLibrary.hjb.Metro;
using HalconDotNet;
using ViewROI;
using BingLibrary.HVision;
using SXJLibrary;
using BingLibrary.hjb.file;
using System.Diagnostics;

namespace SZVppFilmUI.ViewModels
{
    class MainWindowViewModel : NotificationObject
    {
        #region 属性绑定
        private string sindowTitle;

        public string WindowTitle
        {
            get { return sindowTitle; }
            set
            {
                sindowTitle = value;
                this.RaisePropertyChanged("WindowTitle");
            }
        }
        private string topCameraName;

        public string TopCameraName
        {
            get { return topCameraName; }
            set
            {
                topCameraName = value;
                this.RaisePropertyChanged("TopCameraName");
            }
        }
        private string bttomCamera1Name;

        public string BottomCamera1Name
        {
            get { return bttomCamera1Name; }
            set
            {
                bttomCamera1Name = value;
                this.RaisePropertyChanged("BottomCamera1Name");
            }
        }
        private string bottomCamera2Name;

        public string BottomCamera2Name
        {
            get { return bottomCamera2Name; }
            set
            {
                bottomCamera2Name = value;
                this.RaisePropertyChanged("BottomCamera2Name");
            }
        }

        private bool statusTop;

        public bool StatusTop
        {
            get { return statusTop; }
            set
            {
                statusTop = value;
                this.RaisePropertyChanged("StatusTop");
            }
        }
        private bool statusBottom1;

        public bool StatusBottom1
        {
            get { return statusBottom1; }
            set
            {
                statusBottom1 = value;
                this.RaisePropertyChanged("StatusBottom1");
            }
        }
        private bool statusBottom2;

        public bool StatusBottom2
        {
            get { return statusBottom2; }
            set
            {
                statusBottom2 = value;
                this.RaisePropertyChanged("StatusBottom2");
            }
        }
        private string messageStr;

        public string MessageStr
        {
            get { return messageStr; }
            set
            {
                messageStr = value;
                this.RaisePropertyChanged("MessageStr");
            }
        }
        private HImage topCameraIamge;

        public HImage TopCameraIamge
        {
            get { return topCameraIamge; }
            set
            {
                topCameraIamge = value;
                this.RaisePropertyChanged("TopCameraIamge");
            }
        }
        private HImage bottomCamera1Iamge;

        public HImage BottomCamera1Iamge
        {
            get { return bottomCamera1Iamge; }
            set
            {
                bottomCamera1Iamge = value;
                this.RaisePropertyChanged("BottomCamera1Iamge");
            }
        }
        private HImage bottomCamera2Iamge;

        public HImage BottomCamera2Iamge
        {
            get { return bottomCamera2Iamge; }
            set
            {
                bottomCamera2Iamge = value;
                this.RaisePropertyChanged("BottomCamera2Iamge");
            }
        }
        private bool topCameraRepaint;

        public bool TopCameraRepaint
        {
            get { return topCameraRepaint; }
            set
            {
                topCameraRepaint = value;
                this.RaisePropertyChanged("TopCameraRepaint");
            }
        }
        private bool bottomCamera1Repaint;

        public bool BottomCamera1Repaint
        {
            get { return bottomCamera1Repaint; }
            set
            {
                bottomCamera1Repaint = value;
                this.RaisePropertyChanged("BottomCamera1Repaint");
            }
        }
        private bool bottomCamera2Repaint;

        public bool BottomCamera2Repaint
        {
            get { return bottomCamera2Repaint; }
            set
            {
                bottomCamera2Repaint = value;
                this.RaisePropertyChanged("BottomCamera2Repaint");
            }
        }
        private bool statusPLC;

        public bool StatusPLC
        {
            get { return statusPLC; }
            set
            {
                statusPLC = value;
                this.RaisePropertyChanged("StatusPLC");
            }
        }
        private long cycle;

        public long Cycle
        {
            get { return cycle; }
            set
            {
                cycle = value;
                this.RaisePropertyChanged("Cycle");
            }
        }

        #endregion
        #region 方法绑定
        public DelegateCommand AppLoadedEventCommand { get; set; }
        public DelegateCommand TopCameraFunctionCommand { get; set; }
        public DelegateCommand BottonCamera1FunctionCommand { get; set; }
        public DelegateCommand BottonCamera2FunctionCommand { get; set; }
        #endregion
        #region 变量
        private Metro metro = new Metro();
        private CameraOperate topCamera = new CameraOperate();
        private CameraOperate bottomCamera1 = new CameraOperate();
        private CameraOperate bottomCamera2 = new CameraOperate();
        Fx5u Fx5u;
        private string iniParameterPath = System.Environment.CurrentDirectory + "\\Parameter.ini";
        #endregion
        #region 构造函数
        public MainWindowViewModel()
        {
            AppLoadedEventCommand = new DelegateCommand(new Action(this.AppLoadedEventCommandExecute));
            TopCameraFunctionCommand = new DelegateCommand(new Action(this.TopCameraFunctionCommandExecute));
            BottonCamera1FunctionCommand = new DelegateCommand(new Action(this.BottonCamera1FunctionCommandExecute));
            BottonCamera2FunctionCommand = new DelegateCommand(new Action(this.BottonCamera2FunctionCommandExecute));
        }
        #endregion
        #region 方法绑定函数
        private void AppLoadedEventCommandExecute()
        {
            Init();
            UIRun();
            Task.Run(()=> { SystemRun(); });
        }
        private void TopCameraFunctionCommandExecute()
        {

            topCamera.GrabImage();
            TopCameraIamge = topCamera.CurrentImage;
            TopCameraRepaint = !TopCameraRepaint;

        }
        private void BottonCamera1FunctionCommandExecute()
        {

            bottomCamera1.GrabImage();
            BottomCamera1Iamge = bottomCamera1.CurrentImage;
            BottomCamera1Repaint = !BottomCamera1Repaint;

        }
        private void BottonCamera2FunctionCommandExecute()
        {

            bottomCamera2.GrabImage();
            BottomCamera2Iamge = bottomCamera2.CurrentImage;
            BottomCamera2Repaint = !BottomCamera2Repaint;
        }
        #endregion
        #region 自定义函数
        private void Init()
        {
            MessageStr = "";
            WindowTitle = "SZVppFilmUI20200414";
            TopCameraName = "cam3";
            BottomCamera1Name = "cam1";
            BottomCamera2Name = "cam2";
            StatusPLC = true;
            if (topCamera.OpenCamera(TopCameraName, "GigEVision"))
            {
                AddMessage("TopCamera Open Success!");
                if (topCamera.GrabImage())
                {
                    AddMessage("TopCamera拍照成功");
                    TopCameraIamge = topCamera.CurrentImage;
                }
            }
            else
            {
                AddMessage("TopCamera Open Fail!");
            }
            if (bottomCamera1.OpenCamera(BottomCamera1Name, "GigEVision"))
            {
                AddMessage("BottomCamera1 Open Success!");
                if (bottomCamera1.GrabImage())
                {
                    AddMessage("BottomCamera1拍照成功");
                    BottomCamera1Iamge = bottomCamera1.CurrentImage;
                }
            }
            else
            {
                AddMessage("BottomCamera1 Open Fail!");
            }
            if (bottomCamera2.OpenCamera(BottomCamera2Name, "GigEVision"))
            {
                AddMessage("BottomCamera2 Open Success!");
                if (bottomCamera2.GrabImage())
                {
                    AddMessage("BottomCamera2拍照成功");
                    BottomCamera2Iamge = bottomCamera2.CurrentImage;
                }
            }
            else
            {
                AddMessage("BottomCamera2 Open Fail!");
            }
            string plc_ip = Inifile.INIGetStringValue(iniParameterPath, "System", "PLCIP", "192.168.1.13");
            int plc_port = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "System", "PLCPORT", "3900"));
            
            Fx5u = new Fx5u(plc_ip, plc_port);
            Fx5u.ConnectStateChanged += Fx5uConnectStateChanged;

        }
        private void AddMessage(string str)
        {
            string[] s = MessageStr.Split('\n');
            if (s.Length > 1000)
            {
                MessageStr = "";
            }
            if (MessageStr != "")
            {
                MessageStr += "\n";
            }
            MessageStr += System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " " + str;
        }
        private async void UIRun()
        {
            while (true)
            {
                await Task.Delay(100);
                #region UI更新
                StatusTop = topCamera.Connected;
                StatusBottom1 = bottomCamera1.Connected;
                StatusBottom2 = bottomCamera2.Connected;
                #endregion

            }
        }
        private void SystemRun()
        {
            Stopwatch sw = new Stopwatch();
            string Station = Inifile.INIGetStringValue(iniParameterPath, "System", "Station", "A");
            while (true)
            {
                sw.Restart();
                System.Threading.Thread.Sleep(10);
                try
                {
                    switch (Station)
                    {
                        case "A":
                            if (Fx5u.ReadM("M3100"))
                            {
                                Fx5u.SetM("M3100", false);
                                Fx5u.SetMultiM("M3200", new bool[] { false, false });
                                AddMessage("上相机拍照1");
                                try
                                {
                                    bool rst = topCamera.GrabImage();
                                    if (rst)
                                    {
                                        TopCameraIamge = topCamera.CurrentImage;

                                        Fx5u.SetM("M3201", true);
                                    }
                                    else
                                    {
                                        AddMessage("上相机拍照1失败");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    AddMessage(ex.Message);
                                }
                                Fx5u.SetM("M3200", true);
                            }

                            if (Fx5u.ReadM("M3101"))
                            {
                                Fx5u.SetM("M3101", false);
                                Fx5u.SetMultiM("M3202", new bool[] { false, false });
                                AddMessage("上相机拍照2");
                                try
                                {
                                    bool rst = topCamera.GrabImage();
                                    if (rst)
                                    {
                                        TopCameraIamge = topCamera.CurrentImage;

                                        Fx5u.SetM("M3203", true);
                                    }
                                    else
                                    {
                                        AddMessage("上相机拍照2失败");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    AddMessage(ex.Message);
                                }
                                Fx5u.SetM("M3202", true);
                            }

                            if (Fx5u.ReadM("M3102"))
                            {
                                Fx5u.SetM("M3102", false);
                                Fx5u.SetMultiM("M3204", new bool[] { false, false, false });
                                AddMessage("下相机拍照");
                                try
                                {
                                    bool rst1 = false, rst2 = false, finish1 = false, finish2 = false;
                                    Task.Run(() => { rst1 = bottomCamera1.GrabImage(); finish1 = true; });
                                    Task.Run(() => { rst2 = bottomCamera2.GrabImage(); finish2 = true; });
                                    while (!finish1 || !finish2)
                                    {
                                        System.Threading.Thread.Sleep(10);
                                    }
                                    if (rst1)
                                    {
                                        BottomCamera1Iamge = bottomCamera1.CurrentImage;

                                        Fx5u.SetM("M3205", true);
                                    }
                                    if (rst2)
                                    {
                                        BottomCamera2Iamge = bottomCamera2.CurrentImage;

                                        Fx5u.SetM("M3206", true);
                                    }
                                    if (!rst1 || !rst2)
                                    {
                                        AddMessage("下相机拍照失败");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    AddMessage(ex.Message);
                                }
                                Fx5u.SetM("M3204", true);
                            }
                            break;
                        case "B":
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Cycle = sw.ElapsedMilliseconds;
            }
        }
        void Fx5uConnectStateChanged(object sender,bool e)
        {
            StatusPLC = e;
        }
        #endregion

    }
}
