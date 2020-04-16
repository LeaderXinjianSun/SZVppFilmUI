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
using System.IO;
using HalconViewer;
using System.Collections.ObjectModel;

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
        private string loginMenuItemHeader;

        public string LoginMenuItemHeader
        {
            get { return loginMenuItemHeader; }
            set
            {
                loginMenuItemHeader = value;
                this.RaisePropertyChanged("LoginMenuItemHeader");
            }
        }
        private bool isLogin;

        public bool IsLogin
        {
            get { return isLogin; }
            set
            {
                isLogin = value;
                this.RaisePropertyChanged("IsLogin");
            }
        }
        private string halconWindowVisibility;

        public string HalconWindowVisibility
        {
            get { return halconWindowVisibility; }
            set
            {
                halconWindowVisibility = value;
                this.RaisePropertyChanged("HalconWindowVisibility");
            }
        }
        private ObservableCollection<ROI> topCameraROIList;

        public ObservableCollection<ROI> TopCameraROIList
        {
            get { return topCameraROIList; }
            set
            {
                topCameraROIList = value;
                this.RaisePropertyChanged("TopCameraROIList");
            }
        }
        private ObservableCollection<ROI> bottomCamera1ROIList;

        public ObservableCollection<ROI> BottomCamera1ROIList
        {
            get { return bottomCamera1ROIList; }
            set
            {
                bottomCamera1ROIList = value;
                this.RaisePropertyChanged("BottomCamera1ROIList");
            }
        }
        private ObservableCollection<ROI> bottomCamera2ROIList;

        public ObservableCollection<ROI> BottomCamera2ROIList
        {
            get { return bottomCamera2ROIList; }
            set
            {
                bottomCamera2ROIList = value;
                this.RaisePropertyChanged("BottomCamera2ROIList");
            }
        }
        private string iniSection;

        public string IniSection
        {
            get { return iniSection; }
            set
            {
                iniSection = value;
                this.RaisePropertyChanged("IniSection");
            }
        }
        private string iniName;

        public string IniName
        {
            get { return iniName; }
            set
            {
                iniName = value;
                this.RaisePropertyChanged("IniName");
            }
        }
        private string iniValue;

        public string IniValue
        {
            get { return iniValue; }
            set
            {
                iniValue = value;
                this.RaisePropertyChanged("IniValue");
            }
        }
        private double topCameraDiff1_X;

        public double TopCameraDiff1_X
        {
            get { return topCameraDiff1_X; }
            set
            {
                topCameraDiff1_X = value;
                this.RaisePropertyChanged("TopCameraDiff1_X");
            }
        }
        private double topCameraDiff1_Y;

        public double TopCameraDiff1_Y
        {
            get { return topCameraDiff1_Y; }
            set
            {
                topCameraDiff1_Y = value;
                this.RaisePropertyChanged("TopCameraDiff1_Y");
            }
        }
        private double topCameraDiff1_U;

        public double TopCameraDiff1_U
        {
            get { return topCameraDiff1_U; }
            set
            {
                topCameraDiff1_U = value;
                this.RaisePropertyChanged("TopCameraDiff1_U");
            }
        }
        private double topCameraDiff2_X;

        public double TopCameraDiff2_X
        {
            get { return topCameraDiff2_X; }
            set
            {
                topCameraDiff2_X = value;
                this.RaisePropertyChanged("TopCameraDiff2_X");
            }
        }
        private double topCameraDiff2_Y;

        public double TopCameraDiff2_Y
        {
            get { return topCameraDiff2_Y; }
            set
            {
                topCameraDiff2_Y = value;
                this.RaisePropertyChanged("TopCameraDiff2_Y");
            }
        }
        private double topCameraDiff2_U;

        public double TopCameraDiff2_U
        {
            get { return topCameraDiff2_U; }
            set
            {
                topCameraDiff2_U = value;
                this.RaisePropertyChanged("TopCameraDiff2_U");
            }
        }
        private HObject topCameraAppendHObject;

        public HObject TopCameraAppendHObject
        {
            get { return topCameraAppendHObject; }
            set
            {
                topCameraAppendHObject = value;
                this.RaisePropertyChanged("TopCameraAppendHObject");
            }
        }
        private HObject bottomCamera1AppendHObject;

        public HObject BottomCamera1AppendHObject
        {
            get { return bottomCamera1AppendHObject; }
            set
            {
                bottomCamera1AppendHObject = value;
                this.RaisePropertyChanged("BottomCamera1AppendHObject");
            }
        }
        private HObject bottomCamera2AppendHObject;

        public HObject BottomCamera2AppendHObject
        {
            get { return bottomCamera2AppendHObject; }
            set
            {
                bottomCamera2AppendHObject = value;
                this.RaisePropertyChanged("BottomCamera2AppendHObject");
            }
        }

        #endregion
        #region 方法绑定
        public DelegateCommand AppLoadedEventCommand { get; set; }
        public DelegateCommand<object> MenuActionCommand { get; set; }
        public DelegateCommand TopCameraFunctionCommand { get; set; }
        public DelegateCommand BottonCamera1FunctionCommand { get; set; }
        public DelegateCommand BottonCamera2FunctionCommand { get; set; }
        public DelegateCommand<object> DrawROIOperateCommand { get; set; }
        public DelegateCommand<object> ReadImageOperateCommand { get; set; }
        public DelegateCommand FuncBtnCommand { get; set; }
        public DelegateCommand<object> SaveParamOperateCommand { get; set; }
        public DelegateCommand<object> CreateShapeModelOperateCommand { get; set; }
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
            MenuActionCommand = new DelegateCommand<object>(new Action<object>(this.MenuActionCommandExecute));
            TopCameraFunctionCommand = new DelegateCommand(new Action(this.TopCameraFunctionCommandExecute));
            BottonCamera1FunctionCommand = new DelegateCommand(new Action(this.BottonCamera1FunctionCommandExecute));
            BottonCamera2FunctionCommand = new DelegateCommand(new Action(this.BottonCamera2FunctionCommandExecute));
            DrawROIOperateCommand = new DelegateCommand<object>(new Action<object>(this.DrawROIOperateCommandExecute));
            ReadImageOperateCommand = new DelegateCommand<object>(new Action<object>(this.ReadImageOperateCommandExecute));
            FuncBtnCommand = new DelegateCommand(new Action(this.FuncBtnCommandExecute));
            SaveParamOperateCommand = new DelegateCommand<object>(new Action<object>(this.SaveParamOperateCommandExecute));
            CreateShapeModelOperateCommand = new DelegateCommand<object>(new Action<object>(this.CreateShapeModelOperateCommandExecute));
        }
        #endregion
        #region 方法绑定函数
        private void AppLoadedEventCommandExecute()
        {
            Init();
            UIRun();
            Task.Run(()=> { SystemRun(); });
        }
        private async void MenuActionCommandExecute(object p)
        {
            switch (p.ToString())
            {
                case "0":
                    break;
                case "1":
                    break;
                case "2":
                    if (IsLogin)
                    {
                        IsLogin = false;
                        LoginMenuItemHeader = "登录";
                        AddMessage("已登出");
                    }
                    else
                    {
                        metro.ChangeAccent("Orange");
                        HalconWindowVisibility = "Collapsed";
                        var r = await metro.ShowLoginOnlyPassword("请登录");
                        if (r == GetPassWord())
                        {
                            IsLogin = true;
                            LoginMenuItemHeader = "登出";
                        }
                        else
                        {
                            AddMessage("密码错误");
                        }
                        HalconWindowVisibility = "Visible";
                        metro.ChangeAccent("Blue");
                    }
                    break;
                default:
                    break;
            }
        }
        private void TopCameraFunctionCommandExecute()
        {

            topCamera.GrabImageVoid();
            TopCameraIamge = topCamera.CurrentImage;
            AddMessage("TopCamera拍照");
        }
        private void BottonCamera1FunctionCommandExecute()
        {

            bottomCamera1.GrabImageVoid();
            BottomCamera1Iamge = bottomCamera1.CurrentImage;
            AddMessage("BottomCamera1拍照");
        }
        private void BottonCamera2FunctionCommandExecute()
        {

            bottomCamera2.GrabImageVoid();
            BottomCamera2Iamge = bottomCamera2.CurrentImage;
            AddMessage("BottomCamera2拍照");
        }
        private void DrawROIOperateCommandExecute(object p)
        {
            HImage image;
            ImageViewer imageViewer;
            ObservableCollection<ROI> rOIList;
            string path;
            switch (p.ToString())
            {
                case "1":
                    image = bottomCamera1.CurrentImage;
                    path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom1");
                    imageViewer = Global.BottonCamera1ImageViewer;
                    rOIList = BottomCamera1ROIList;
                    break;
                case "2":
                    image = bottomCamera2.CurrentImage;
                    path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom2");
                    imageViewer = Global.BottonCamera2ImageViewer;
                    rOIList = BottomCamera2ROIList;
                    break;
                default:
                    image = topCamera.CurrentImage;
                    path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top");
                    imageViewer = Global.TopCameraImageViewer;
                    rOIList = TopCameraROIList;
                    break;
            }
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ROI roi = imageViewer.DrawROI(ROI.ROI_TYPE_RECTANGLE1);
            rOIList.Clear();
            rOIList.Add(roi);
            HOperatorSet.WriteRegion(roi.getRegion(),Path.Combine(path, "Region.hobj"));
        }
        private void ReadImageOperateCommandExecute(object p)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "Image文件(*.bmp;*.jpg)|*.bmp;*.jpg|所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strFileName = ofd.FileName;
                switch (p.ToString())
                {
                    case "0":
                        topCamera.ReadImage(strFileName);
                        TopCameraIamge = topCamera.CurrentImage;
                        break;
                    case "1":
                        bottomCamera1.ReadImage(strFileName);
                        BottomCamera1Iamge = bottomCamera1.CurrentImage;
                        break;
                    case "2":
                        bottomCamera2.ReadImage(strFileName);
                        BottomCamera2Iamge = bottomCamera2.CurrentImage;
                        break;
                    default:
                        break;
                }
            }

        }
        private void FuncBtnCommandExecute()
        {
            try
            {
                //Inifile.INIWriteValue(iniParameterPath, IniSection, IniName, IniValue);
                //AddMessage(string.Format("Ini文件,{0},{1},{2} 写入完成", IniSection, IniName, IniValue));
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }
        }
        private void SaveParamOperateCommandExecute(object p)
        {
            switch (p.ToString())
            {
                case "0":
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "TopCameraDiff1_X", TopCameraDiff1_X.ToString("F2"));
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "TopCameraDiff1_Y", TopCameraDiff1_Y.ToString("F2"));
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "TopCameraDiff1_U", TopCameraDiff1_U.ToString("F2"));
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "TopCameraDiff2_X", TopCameraDiff2_X.ToString("F2"));
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "TopCameraDiff2_Y", TopCameraDiff2_Y.ToString("F2"));
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "TopCameraDiff2_U", TopCameraDiff2_U.ToString("F2"));
                    AddMessage("上相机参数保存完成");
                    break;
                default:
                    break;
            }
        }
        private void CreateShapeModelOperateCommandExecute(object p)
        {
            HImage image;
            ImageViewer imageViewer;
            ObservableCollection<ROI> rOIList;
            string path;
            switch (p.ToString())
            {
                case "1":
                    image = bottomCamera1.CurrentImage;
                    path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom1");
                    imageViewer = Global.BottonCamera1ImageViewer;
                    rOIList = BottomCamera1ROIList;
                    break;
                case "2":
                    image = bottomCamera2.CurrentImage;
                    path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom2");
                    imageViewer = Global.BottonCamera2ImageViewer;
                    rOIList = BottomCamera2ROIList;
                    break;
                default:
                    image = topCamera.CurrentImage;
                    path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top");
                    imageViewer = Global.TopCameraImageViewer;
                    rOIList = TopCameraROIList;
                    break;
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ROI roi = imageViewer.DrawROI(ROI.ROI_TYPE_REGION);
            HObject ReduceDomainImage;
            HOperatorSet.ReduceDomain(image, roi.getRegion(), out ReduceDomainImage);
            HObject modelImages, modelRegions;
            HOperatorSet.InspectShapeModel(ReduceDomainImage, out modelImages, out modelRegions, 7, 30);
            HObject objectSelected;
            HOperatorSet.SelectObj(modelRegions, out objectSelected, 1);
            HOperatorSet.WriteRegion(objectSelected, Path.Combine(path, "ModelRegion.hobj"));
            TopCameraAppendHObject = null;
            TopCameraAppendHObject = objectSelected;
            //rOIList.Clear();
            //rOIList.Add();
            //HOperatorSet.WriteRegion(roi.getRegion(), Path.Combine(path, "Region.hobj"));
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
            IsLogin = false;
            HalconWindowVisibility = "Visible";
            LoginMenuItemHeader = "登录";
            TopCameraROIList = new ObservableCollection<ROI>();
            BottomCamera1ROIList = new ObservableCollection<ROI>();
            BottomCamera2ROIList = new ObservableCollection<ROI>();
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
            TopCameraDiff1_X = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "TopCameraDiff1_X", "0"));
            TopCameraDiff1_Y = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "TopCameraDiff1_Y", "0"));
            TopCameraDiff1_U = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "TopCameraDiff1_U", "0"));
            TopCameraDiff2_X = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "TopCameraDiff2_X", "0"));
            TopCameraDiff2_Y = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "TopCameraDiff2_Y", "0"));
            TopCameraDiff2_U = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "TopCameraDiff2_U", "0"));
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
        private string GetPassWord()
        {
            int day = System.DateTime.Now.Day;
            int month = System.DateTime.Now.Month;
            string ss = (day + month).ToString();
            string passwordstr = "";
            for (int i = 0; i < 4 - ss.Length; i++)
            {
                passwordstr += "0";
            }
            passwordstr += ss;
            return passwordstr;
        }
        #endregion

    }
}
