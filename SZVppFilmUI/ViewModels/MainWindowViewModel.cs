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
using Newtonsoft.Json;
using OfficeOpenXml;
using BingLibrary.hjb;
using ModbusServo;
using System.IO.Ports;

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
        private bool clibButtonIsEnabled;

        public bool ClibButtonIsEnabled
        {
            get { return clibButtonIsEnabled; }
            set
            {
                clibButtonIsEnabled = value;
                this.RaisePropertyChanged("ClibButtonIsEnabled");
            }
        }
        private Tuple<string, object> topCameraGCStyle;

        public Tuple<string, object> TopCameraGCStyle
        {
            get { return topCameraGCStyle; }
            set
            {
                topCameraGCStyle = value;
                this.RaisePropertyChanged("TopCameraGCStyle");
            }
        }
        private Tuple<string, object> bottomCamera1GCStyle;

        public Tuple<string, object> BottomCamera1GCStyle
        {
            get { return bottomCamera1GCStyle; }
            set
            {
                bottomCamera1GCStyle = value;
                this.RaisePropertyChanged("BottomCamera1GCStyle");
            }
        }
        private Tuple<string, object> bottomCamera2GCStyle;

        public Tuple<string, object> BottomCamera2GCStyle
        {
            get { return bottomCamera2GCStyle; }
            set
            {
                bottomCamera2GCStyle = value;
                this.RaisePropertyChanged("BottomCamera2GCStyle");
            }
        }

        private PointViewModel topCameraDiff1;

        public PointViewModel TopCameraDiff1
        {
            get { return topCameraDiff1; }
            set
            {
                topCameraDiff1 = value;
                this.RaisePropertyChanged("TopCameraDiff1");
            }
        }
        private PointViewModel topCameraDiff2;

        public PointViewModel TopCameraDiff2
        {
            get { return topCameraDiff2; }
            set
            {
                topCameraDiff2 = value;
                this.RaisePropertyChanged("TopCameraDiff2");
            }
        }
        private PointViewModel bottomCamera1Diff;

        public PointViewModel BottomCamera1Diff
        {
            get { return bottomCamera1Diff; }
            set
            {
                bottomCamera1Diff = value;
                this.RaisePropertyChanged("BottomCamera1Diff");
            }
        }
        private PointViewModel bottomCamera2Diff;

        public PointViewModel BottomCamera2Diff
        {
            get { return bottomCamera2Diff; }
            set
            {
                bottomCamera2Diff = value;
                this.RaisePropertyChanged("BottomCamera2Diff");
            }
        }
        private int topCameraExposureValue;

        public int TopCameraExposureValue
        {
            get { return topCameraExposureValue; }
            set
            {
                topCameraExposureValue = value;
                this.RaisePropertyChanged("TopCameraExposureValue");
            }
        }
        private int bottomCamera1ExposureValue;

        public int BottomCamera1ExposureValue
        {
            get { return bottomCamera1ExposureValue; }
            set
            {
                bottomCamera1ExposureValue = value;
                this.RaisePropertyChanged("BottomCamera1ExposureValue");
            }
        }
        private int bottomCamera2ExposureValue;

        public int BottomCamera2ExposureValue
        {
            get { return bottomCamera2ExposureValue; }
            set
            {
                bottomCamera2ExposureValue = value;
                this.RaisePropertyChanged("BottomCamera2ExposureValue");
            }
        }
        private int topCameraRadius;

        public int TopCameraRadius
        {
            get { return topCameraRadius; }
            set
            {
                topCameraRadius = value;
                this.RaisePropertyChanged("TopCameraRadius");
            }
        }
        private int bottomCamera1Radius;

        public int BottomCamera1Radius
        {
            get { return bottomCamera1Radius; }
            set
            {
                bottomCamera1Radius = value;
                this.RaisePropertyChanged("BottomCamera1Radius");
            }
        }
        private int bottomCamera2Radius;

        public int BottomCamera2Radius
        {
            get { return bottomCamera2Radius; }
            set
            {
                bottomCamera2Radius = value;
                this.RaisePropertyChanged("BottomCamera2Radius");
            }
        }
        private int tabControlSelectedIndex;

        public int TabControlSelectedIndex
        {
            get { return tabControlSelectedIndex; }
            set
            {
                tabControlSelectedIndex = value;
                this.RaisePropertyChanged("TabControlSelectedIndex");
            }
        }

        private int topCameraContrast;

        public int TopCameraContrast
        {
            get { return topCameraContrast; }
            set
            {
                topCameraContrast = value;
                this.RaisePropertyChanged("TopCameraContrast");
            }
        }
        private int topCameraLow;

        public int TopCameraLow
        {
            get { return topCameraLow; }
            set
            {
                topCameraLow = value;
                this.RaisePropertyChanged("TopCameraLow");
            }
        }
        private int bottomCamera1Contrast;

        public int BottomCamera1Contrast
        {
            get { return bottomCamera1Contrast; }
            set
            {
                bottomCamera1Contrast = value;
                this.RaisePropertyChanged("BottomCamera1Contrast");
            }
        }
        private int bottomCamera1Low;

        public int BottomCamera1Low
        {
            get { return bottomCamera1Low; }
            set
            {
                bottomCamera1Low = value;
                this.RaisePropertyChanged("BottomCamera1Low");
            }
        }
        private int bottomCamera2Contrast;

        public int BottomCamera2Contrast
        {
            get { return bottomCamera2Contrast; }
            set
            {
                bottomCamera2Contrast = value;
                this.RaisePropertyChanged("BottomCamera2Contrast");
            }
        }
        private int bottomCamera2Low;

        public int BottomCamera2Low
        {
            get { return bottomCamera2Low; }
            set
            {
                bottomCamera2Low = value;
                this.RaisePropertyChanged("BottomCamera2Low");
            }
        }
        private bool onlyImage;

        public bool OnlyImage
        {
            get { return onlyImage; }
            set
            {
                onlyImage = value;
                this.RaisePropertyChanged("OnlyImage");
            }
        }
        private double topCameraCalibRadius;

        public double TopCameraCalibRadius
        {
            get { return topCameraCalibRadius; }
            set
            {
                topCameraCalibRadius = value;
                this.RaisePropertyChanged("TopCameraCalibRadius");
            }
        }
        private double bottomCamera1CalibRadius;

        public double BottomCamera1CalibRadius
        {
            get { return bottomCamera1CalibRadius; }
            set
            {
                bottomCamera1CalibRadius = value;
                this.RaisePropertyChanged("BottomCamera1CalibRadius");
            }
        }
        private double bottomCamera2CalibRadius;

        public double BottomCamera2CalibRadius
        {
            get { return bottomCamera2CalibRadius; }
            set
            {
                bottomCamera2CalibRadius = value;
                this.RaisePropertyChanged("BottomCamera2CalibRadius");
            }
        }
        private double noiseValue;

        public double NoiseValue
        {
            get { return noiseValue; }
            set
            {
                noiseValue = value;
                this.RaisePropertyChanged("NoiseValue");
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
        public DelegateCommand<object> CreateLineCommand { get; set; }
        public DelegateCommand<object> FindShapeModelOperateCommand { get; set; }
        public DelegateCommand<object> FindLineOperateCommand { get; set; }
        public DelegateCommand<object> ClibOperateCommand { get; set; }
        public DelegateCommand CreateShapeModel2 { get; set; }
        public DelegateCommand FindShapeModel2 { get; set; }
        public DelegateCommand AppClosedEventCommand { get; set; }
        public DelegateCommand<object> TopCameraProductSelectCommand { get; set; }
        #endregion
        #region 变量
        private Metro metro = new Metro();
        private CameraOperate topCamera = new CameraOperate();
        private CameraOperate bottomCamera1 = new CameraOperate();
        private CameraOperate bottomCamera2 = new CameraOperate();
        Fx5u Fx5u;
        private string iniParameterPath = System.Environment.CurrentDirectory + "\\Parameter.ini";
        List<AlarmData> AlarmList = new List<AlarmData>(); bool[] M300;
        int TopCameraProductIndex = 0;
        #endregion
        #region 构造函数
        public MainWindowViewModel()
        {
            AppLoadedEventCommand = new DelegateCommand(new Action(this.AppLoadedEventCommandExecute));
            AppClosedEventCommand = new DelegateCommand(new Action(this.AppClosedEventCommandExecute));
            MenuActionCommand = new DelegateCommand<object>(new Action<object>(this.MenuActionCommandExecute));
            TopCameraFunctionCommand = new DelegateCommand(new Action(this.TopCameraFunctionCommandExecute));
            BottonCamera1FunctionCommand = new DelegateCommand(new Action(this.BottonCamera1FunctionCommandExecute));
            BottonCamera2FunctionCommand = new DelegateCommand(new Action(this.BottonCamera2FunctionCommandExecute));
            DrawROIOperateCommand = new DelegateCommand<object>(new Action<object>(this.DrawROIOperateCommandExecute));
            ReadImageOperateCommand = new DelegateCommand<object>(new Action<object>(this.ReadImageOperateCommandExecute));
            FuncBtnCommand = new DelegateCommand(new Action(this.FuncBtnCommandExecute));
            SaveParamOperateCommand = new DelegateCommand<object>(new Action<object>(this.SaveParamOperateCommandExecute));
            CreateShapeModelOperateCommand = new DelegateCommand<object>(new Action<object>(this.CreateShapeModelOperateCommandExecute));
            FindShapeModelOperateCommand = new DelegateCommand<object>(new Action<object>(this.FindShapeModelOperateCommandExecute));
            FindLineOperateCommand = new DelegateCommand<object>(new Action<object>(this.FindLineOperateCommandExecute));
            ClibOperateCommand = new DelegateCommand<object>(new Action<object>(this.ClibOperateCommandExecute));
            CreateShapeModel2 = new DelegateCommand(new Action(this.CreateShapeModel2Execute));
            FindShapeModel2 = new DelegateCommand(new Action(this.FindShapeModel2Execute));
            CreateLineCommand = new DelegateCommand<object>(new Action<object>(this.CreateLineCommandExecute));
            TopCameraProductSelectCommand = new DelegateCommand<object>(new Action<object>(this.TopCameraProductSelectCommandExecute));
        }
        #endregion
        #region 方法绑定函数
        private void AppLoadedEventCommandExecute()
        {
            Init();
            UIRun();
            Task.Run(() => { SystemRun(); });
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(100);
                TabControlSelectedIndex = 0;
                if (topCamera.OpenCamera(TopCameraName, "GigEVision"))
                {
                    AddMessage("TopCamera Open Success!");
                    TopCameraExposureValue = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "TopCameraExposureValue", "3500"));
                    topCamera.SetExpose(TopCameraExposureValue);
                    if (topCamera.GrabImage(TopCameraRadius, true))
                    {
                        AddMessage("TopCamera拍照成功");
                        TopCameraIamge = topCamera.CurrentImage;
                    }
                }
                else
                {
                    AddMessage("TopCamera Open Fail!");
                }
                TabControlSelectedIndex = 1;
                if (bottomCamera1.OpenCamera(BottomCamera1Name, "GigEVision"))
                {
                    AddMessage("BottomCamera1 Open Success!");
                    BottomCamera1ExposureValue = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "BottomCamera1ExposureValue", "3500"));
                    bottomCamera1.SetExpose(BottomCamera1ExposureValue);
                    if (bottomCamera1.GrabImage(BottomCamera1Radius, false))
                    {
                        AddMessage("BottomCamera1拍照成功");
                        BottomCamera1Iamge = bottomCamera1.CurrentImage;
                    }
                }
                else
                {
                    AddMessage("BottomCamera1 Open Fail!");
                }
                TabControlSelectedIndex = 2;
                if (bottomCamera2.OpenCamera(BottomCamera2Name, "GigEVision"))
                {
                    BottomCamera2ExposureValue = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "BottomCamera2ExposureValue", "3500"));
                    bottomCamera2.SetExpose(BottomCamera2ExposureValue);
                    AddMessage("BottomCamera2 Open Success!");
                    if (bottomCamera2.GrabImage(BottomCamera2Radius, false))
                    {
                        AddMessage("BottomCamera2拍照成功");
                        BottomCamera2Iamge = bottomCamera2.CurrentImage;
                    }
                }
                else
                {
                    AddMessage("BottomCamera2 Open Fail!");
                }
            });
        }
        private void AppClosedEventCommandExecute()
        {
            try
            {
                topCamera.CloseCamera();
                bottomCamera1.CloseCamera();
                bottomCamera2.CloseCamera();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

            topCamera.GrabImageVoid(TopCameraRadius, true);
            TopCameraIamge = topCamera.CurrentImage;
            AddMessage("TopCamera拍照");
        }
        private void BottonCamera1FunctionCommandExecute()
        {

            bottomCamera1.GrabImageVoid(BottomCamera1Radius, false);
            BottomCamera1Iamge = bottomCamera1.CurrentImage;
            AddMessage("BottomCamera1拍照");
        }
        private void BottonCamera2FunctionCommandExecute()
        {

            bottomCamera2.GrabImageVoid(BottomCamera2Radius, false);
            BottomCamera2Iamge = bottomCamera2.CurrentImage;
            AddMessage("BottomCamera2拍照");
        }
        private async void DrawROIOperateCommandExecute(object p)
        {
            metro.ChangeAccent("Red");
            HalconWindowVisibility = "Collapsed";
            var r = await metro.ShowConfirm("确认", "请确认需要重画区域吗？");
            if (r)
            {
                metro.ChangeAccent("Blue");
                HalconWindowVisibility = "Visible";
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
                        switch (TopCameraProductIndex)
                        {
                            case 1:
                                path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top\ON");
                                break;
                            case 0:
                            default:
                                path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top\OFF");
                                break;
                        }
                        imageViewer = Global.TopCameraImageViewer;
                        rOIList = TopCameraROIList;
                        break;
                }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                ROI roi = imageViewer.DrawROI(ROI.ROI_TYPE_RECTANGLE1);
                Tuple<string, object> t = new Tuple<string, object>("Color", "red");

                switch (p.ToString())
                {
                    case "1":
                        BottomCamera1GCStyle = t;
                        BottomCamera1AppendHObject = null;
                        BottomCamera1AppendHObject = roi.getRegion();
                        break;

                    case "2":
                        BottomCamera2GCStyle = t;
                        BottomCamera2AppendHObject = null;
                        BottomCamera2AppendHObject = roi.getRegion();
                        break;
                    default:
                        TopCameraGCStyle = t;
                        TopCameraAppendHObject = null;
                        TopCameraAppendHObject = roi.getRegion();
                        break;
                }
                HOperatorSet.WriteRegion(roi.getRegion(), Path.Combine(path, "Region.hobj"));
            }
            else
            {
                metro.ChangeAccent("Blue");
                HalconWindowVisibility = "Visible";
            }

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
                var rst = TopCameraCalc("D4116", TopCameraDiff2.X, TopCameraDiff2.Y, TopCameraDiff2.U, 0);
                ////var rst = BottomCamera2Calc(TopCameraDiff2.X, TopCameraDiff2.Y, TopCameraDiff2.U);
                AddMessage(rst.Item1[0].ToString() + "," + rst.Item1[1].ToString() + "," + rst.Item1[2].ToString());
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
                    WriteToJson(TopCameraDiff1, Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top", "TopCameraDiff1.json"));
                    WriteToJson(TopCameraDiff2, Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top", "TopCameraDiff2.json"));
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "TopCameraExposureValue", TopCameraExposureValue.ToString());
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "TopCameraRadius", TopCameraRadius.ToString());
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "TopCameraContrast", TopCameraContrast.ToString());
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "TopCameraLow", TopCameraLow.ToString());
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "TopCameraCalibRadius", TopCameraCalibRadius.ToString());
                    topCamera.SetExpose(TopCameraExposureValue);
                    AddMessage("上相机参数保存完成");
                    break;
                case "1":
                    WriteToJson(BottomCamera1Diff, Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom1", "BottomCamera1Diff.json"));
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "BottomCamera1ExposureValue", BottomCamera1ExposureValue.ToString());
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "BottomCamera1Radius", BottomCamera1Radius.ToString());
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "BottomCamera1Contrast", BottomCamera1Contrast.ToString());
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "BottomCamera1Low", BottomCamera1Low.ToString());
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "BottomCamera1CalibRadius", BottomCamera1CalibRadius.ToString());
                    bottomCamera1.SetExpose(BottomCamera1ExposureValue);
                    AddMessage("下相机1参数保存完成");
                    break;
                case "2":
                    WriteToJson(BottomCamera2Diff, Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom2", "BottomCamera2Diff.json"));
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "BottomCamera2ExposureValue", BottomCamera2ExposureValue.ToString());
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "BottomCamera2Radius", BottomCamera2Radius.ToString());
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "BottomCamera2Contrast", BottomCamera2Contrast.ToString());
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "BottomCamera2Low", BottomCamera2Low.ToString());
                    Inifile.INIWriteValue(iniParameterPath, "Camera", "BottomCamera2CalibRadius", BottomCamera2CalibRadius.ToString());
                    bottomCamera2.SetExpose(BottomCamera2ExposureValue);
                    AddMessage("下相机2参数保存完成");
                    break;
                default:
                    break;
            }
        }
        private async void CreateShapeModelOperateCommandExecute(object p)
        {
            metro.ChangeAccent("Red");
            HalconWindowVisibility = "Collapsed";
            var r = await metro.ShowConfirm("确认", "请确认需要重新画模板吗？");
            if (r)
            {
                metro.ChangeAccent("Blue");
                HalconWindowVisibility = "Visible";
                try
                {
                    HImage image;
                    ImageViewer imageViewer;
                    ObservableCollection<ROI> rOIList;
                    CameraOperate camera;
                    HTuple Contrast;
                    string path;
                    switch (p.ToString())
                    {
                        case "1":
                            image = bottomCamera1.CurrentImage;
                            path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom1");
                            imageViewer = Global.BottonCamera1ImageViewer;
                            rOIList = BottomCamera1ROIList;
                            camera = bottomCamera1;
                            BottomCamera1AppendHObject = null;
                            Contrast = BottomCamera1Contrast;
                            break;
                        case "2":
                            image = bottomCamera2.CurrentImage;
                            path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom2");
                            imageViewer = Global.BottonCamera2ImageViewer;
                            rOIList = BottomCamera2ROIList;
                            camera = bottomCamera2;
                            BottomCamera2AppendHObject = null;
                            Contrast = BottomCamera2Contrast;
                            break;
                        default:
                            image = topCamera.CurrentImage;
                            switch (TopCameraProductIndex)
                            {
                                case 1:
                                    path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top\ON");
                                    break;
                                case 0:
                                default:
                                    path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top\OFF");
                                    break;
                            }
                            imageViewer = Global.TopCameraImageViewer;
                            rOIList = TopCameraROIList;
                            camera = topCamera;
                            TopCameraAppendHObject = null;
                            Contrast = TopCameraContrast;
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
                    HOperatorSet.InspectShapeModel(ReduceDomainImage, out modelImages, out modelRegions, 7, Contrast);
                    HObject objectSelected;
                    HOperatorSet.SelectObj(modelRegions, out objectSelected, 1);
                    HOperatorSet.WriteRegion(objectSelected, Path.Combine(path, "ModelRegion.hobj"));
                    switch (p.ToString())
                    {
                        case "1":
                            BottomCamera1AppendHObject = null;
                            BottomCamera1AppendHObject = objectSelected;
                            break;

                        case "2":
                            BottomCamera2AppendHObject = null;
                            BottomCamera2AppendHObject = objectSelected;
                            break;
                        default:
                            TopCameraAppendHObject = null;
                            TopCameraAppendHObject = objectSelected;
                            break;
                    }
                    HTuple ModelID;
                    HOperatorSet.CreateShapeModel(ReduceDomainImage, 7, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), (new HTuple(0.1)).TupleRad(), "no_pregeneration", "use_polarity", Contrast, 10, out ModelID);
                    HOperatorSet.WriteShapeModel(ModelID, Path.Combine(path, "ShapeModel.shm"));
                    camera.SaveImage("bmp", Path.Combine(path, "ModelImage.bmp"));
                    AddMessage("创建模板完成");
                }
                catch (Exception ex)
                {
                    AddMessage(ex.Message);
                }
            }
            else
            {
                metro.ChangeAccent("Blue");
                HalconWindowVisibility = "Visible";
            }



        }
        private async void CreateShapeModel2Execute()
        {
            metro.ChangeAccent("Red");
            HalconWindowVisibility = "Collapsed";
            var r = await metro.ShowConfirm("确认", "请确认需要重新画模板2吗？");
            if (r)
            {
                metro.ChangeAccent("Blue");
                HalconWindowVisibility = "Visible";
                try
                {
                    TopCameraAppendHObject = null;
                    string path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top");
                    ROI roi = Global.TopCameraImageViewer.DrawROI(ROI.ROI_TYPE_REGION);
                    HObject ReduceDomainImage;
                    HOperatorSet.ReduceDomain(topCamera.CurrentImage, roi.getRegion(), out ReduceDomainImage);
                    HObject modelImages, modelRegions;
                    HOperatorSet.InspectShapeModel(ReduceDomainImage, out modelImages, out modelRegions, 7, TopCameraContrast);

                    HObject objectSelected;
                    HOperatorSet.SelectObj(modelRegions, out objectSelected, 1);
                    HOperatorSet.WriteRegion(objectSelected, Path.Combine(path, "ModelRegion2.hobj"));
                    Tuple<string, object> t = new Tuple<string, object>("Color", "green");
                    TopCameraGCStyle = t;
                    TopCameraAppendHObject = null;
                    TopCameraAppendHObject = objectSelected;
                    HTuple ModelID;
                    HOperatorSet.CreateShapeModel(ReduceDomainImage, 7, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), (new HTuple(0.1)).TupleRad(), "no_pregeneration", "use_polarity", TopCameraContrast, 10, out ModelID);
                    HOperatorSet.WriteShapeModel(ModelID, Path.Combine(path, "ShapeModel2.shm"));
                    topCamera.SaveImage("bmp", Path.Combine(path, "ModelImage2.bmp"));
                    AddMessage("创建模板2完成");
                }
                catch (Exception ex)
                {

                    AddMessage(ex.Message);
                }
            }
            else
            {
                metro.ChangeAccent("Blue");
                HalconWindowVisibility = "Visible";
            }


        }
        private void FindShapeModelOperateCommandExecute(object p)
        {
            try
            {
                HImage image;
                ImageViewer imageViewer;
                ObservableCollection<ROI> rOIList;
                CameraOperate camera;
                string path;
                switch (p.ToString())
                {
                    case "1":
                        image = bottomCamera1.CurrentImage;
                        path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom1");
                        imageViewer = Global.BottonCamera1ImageViewer;
                        rOIList = BottomCamera1ROIList;
                        camera = bottomCamera1;
                        break;
                    case "2":
                        image = bottomCamera2.CurrentImage;
                        path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom2");
                        imageViewer = Global.BottonCamera2ImageViewer;
                        rOIList = BottomCamera2ROIList;
                        camera = bottomCamera2;
                        break;
                    default:
                        image = topCamera.CurrentImage;
                        switch (TopCameraProductIndex)
                        {
                            case 1:
                                path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top\ON");
                                break;
                            case 0:
                            default:
                                path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top\OFF");
                                break;
                        }
                        imageViewer = Global.TopCameraImageViewer;
                        rOIList = TopCameraROIList;
                        camera = topCamera;
                        break;
                }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                HTuple ModelID, row, column, angle, score, row1, column1, angle1, score1;
                HOperatorSet.ReadShapeModel(Path.Combine(path, "ShapeModel.shm"), out ModelID);
                HObject ModelImage;
                HOperatorSet.ReadImage(out ModelImage, Path.Combine(path, "ModelImage.bmp"));
                HOperatorSet.FindShapeModel(ModelImage, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row, out column, out angle, out score);
                HOperatorSet.FindShapeModel(camera.CurrentImage, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row1, out column1, out angle1, out score1);
                HTuple homMat2D;
                HOperatorSet.VectorAngleToRigid(row, column, angle, row1, column1, angle1, out homMat2D);
                HObject modelRegion;
                HOperatorSet.ReadRegion(out modelRegion, Path.Combine(path, "ModelRegion.hobj"));
                HObject regionAffineTrans;
                HOperatorSet.AffineTransRegion(modelRegion, out regionAffineTrans, homMat2D, "nearest_neighbor");
                Tuple<string, object> t = new Tuple<string, object>("Color", "green");
                switch (p.ToString())
                {
                    case "1":
                        BottomCamera1GCStyle = t;
                        BottomCamera1AppendHObject = null;
                        BottomCamera1AppendHObject = regionAffineTrans;
                        break;

                    case "2":
                        BottomCamera2GCStyle = t;
                        BottomCamera2AppendHObject = null;
                        BottomCamera2AppendHObject = regionAffineTrans;
                        break;
                    default:
                        TopCameraGCStyle = t;
                        TopCameraAppendHObject = null;
                        TopCameraAppendHObject = regionAffineTrans;

                        break;
                }


                AddMessage("找到模板: Row:" + row1.D.ToString("F0") + " Column:" + column1.D.ToString("F0") + " Angle:" + angle1.TupleDeg().D.ToString("F2") + " Score:" + score1.D.ToString("F1"));
            }
            catch (Exception ex)
            {

                AddMessage(ex.Message);
            }



        }
        private void FindLineOperateCommandExecute(object p)
        {
            try
            {
                HImage image;
                ImageViewer imageViewer;
                CameraOperate camera;
                HTuple edges_sub_pix_low = null, edges_sub_pix_high = null;
                string path;
                switch (p.ToString())
                {
                    case "1":
                        image = bottomCamera1.CurrentImage;
                        path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom1");
                        imageViewer = Global.BottonCamera1ImageViewer;
                        edges_sub_pix_low = BottomCamera1Low;
                        edges_sub_pix_high = BottomCamera1Low + 20;
                        camera = bottomCamera1;
                        break;
                    case "2":
                        image = bottomCamera2.CurrentImage;
                        path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom2");
                        imageViewer = Global.BottonCamera2ImageViewer;
                        edges_sub_pix_low = BottomCamera2Low;
                        edges_sub_pix_high = BottomCamera2Low + 20;
                        camera = bottomCamera2;
                        break;
                    default:
                        image = topCamera.CurrentImage;
                        switch (TopCameraProductIndex)
                        {
                            case 1:
                                path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top\ON");
                                break;
                            case 0:
                            default:
                                path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top\OFF");
                                break;
                        }
                        imageViewer = Global.TopCameraImageViewer;
                        edges_sub_pix_low = TopCameraLow;
                        edges_sub_pix_high = TopCameraLow + 20;
                        camera = topCamera;
                        break;
                }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                HTuple ModelID, row, column, angle, score, row1, column1, angle1, score1;
                HOperatorSet.ReadShapeModel(Path.Combine(path, "ShapeModel.shm"), out ModelID);
                HObject ModelImage;
                HOperatorSet.ReadImage(out ModelImage, Path.Combine(path, "ModelImage.bmp"));
                HOperatorSet.FindShapeModel(ModelImage, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row, out column, out angle, out score);
                HOperatorSet.FindShapeModel(camera.CurrentImage, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row1, out column1, out angle1, out score1);
                HTuple homMat2D;
                HOperatorSet.VectorAngleToRigid(row, column, angle, row1, column1, angle1, out homMat2D);
                HObject lineRegion;
                HOperatorSet.ReadRegion(out lineRegion, Path.Combine(path, "Line.hobj"));
                HObject regionAffineTrans;
                HOperatorSet.AffineTransRegion(lineRegion, out regionAffineTrans, homMat2D, "nearest_neighbor");
                HObject imageReduced1;
                HOperatorSet.ReduceDomain(camera.CurrentImage, regionAffineTrans, out imageReduced1);
                HObject edges1;
                HOperatorSet.EdgesSubPix(imageReduced1, out edges1, "canny", 1, edges_sub_pix_low, edges_sub_pix_high);
                HObject contoursSplit1;
                HOperatorSet.SegmentContoursXld(edges1, out contoursSplit1, "lines_circles", 5, 4, 2);
                HObject selectedContours1;
                HOperatorSet.SelectContoursXld(contoursSplit1, out selectedContours1, "contour_length", 15, 500, -0.5, 0.5);
                HObject unionContours1;
                HOperatorSet.UnionAdjacentContoursXld(selectedContours1, out unionContours1, 10, 1, "attr_keep");
                HTuple rowBegin1, colBegin1, rowEnd1, colEnd1, nr1, nc1, dist1;
                HOperatorSet.FitLineContourXld(unionContours1, "tukey", -1, 0, 5, 2, out rowBegin1, out colBegin1, out rowEnd1, out colEnd1, out nr1, out nc1, out dist1);
                HObject regionLine;
                HOperatorSet.GenRegionLine(out regionLine, rowBegin1, colBegin1, rowEnd1, colEnd1);

                Tuple<string, object> t = new Tuple<string, object>("Color", "green");
                switch (p.ToString())
                {
                    case "1":
                        BottomCamera1GCStyle = t;
                        BottomCamera1AppendHObject = null;
                        BottomCamera1AppendHObject = regionLine;
                        break;

                    case "2":
                        BottomCamera2GCStyle = t;
                        BottomCamera2AppendHObject = null;
                        BottomCamera2AppendHObject = regionLine;
                        break;
                    default:
                        TopCameraGCStyle = t;
                        TopCameraAppendHObject = null;
                        TopCameraAppendHObject = regionLine;

                        break;
                }


                AddMessage("找到直线: " + (Math.Atan2((nc1), (nr1)) * 180 / Math.PI - 90).ToString("F2") + "°");
            }
            catch (Exception ex)
            {

                AddMessage(ex.Message);
            }
        }
        private void FindShapeModel2Execute()
        {
            try
            {
                string path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top");
                HTuple ModelID, row, column, angle, score, row1, column1, angle1, score1;
                HOperatorSet.ReadShapeModel(Path.Combine(path, "ShapeModel2.shm"), out ModelID);
                HObject ModelImage;
                HOperatorSet.ReadImage(out ModelImage, Path.Combine(path, "ModelImage2.bmp"));
                HOperatorSet.FindShapeModel(ModelImage, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row, out column, out angle, out score);
                HOperatorSet.FindShapeModel(topCamera.CurrentImage, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row1, out column1, out angle1, out score1);
                HTuple homMat2D;
                HOperatorSet.VectorAngleToRigid(row, column, angle, row1, column1, angle1, out homMat2D);
                HObject modelRegion;
                HOperatorSet.ReadRegion(out modelRegion, Path.Combine(path, "ModelRegion2.hobj"));
                HObject regionAffineTrans;
                HOperatorSet.AffineTransRegion(modelRegion, out regionAffineTrans, homMat2D, "nearest_neighbor");
                Tuple<string, object> t = new Tuple<string, object>("Color", "green");
                TopCameraGCStyle = t;
                TopCameraAppendHObject = null;
                TopCameraAppendHObject = regionAffineTrans;
                AddMessage("找到模板: Row:" + row1.D.ToString("F0") + " Column:" + column1.D.ToString("F0") + " Angle:" + angle1.TupleDeg().D.ToString("F2") + " Score:" + score1.D.ToString("F1"));
            }
            catch (Exception ex)
            {

                AddMessage(ex.Message);
            }

        }
        private async void ClibOperateCommandExecute(object p)
        {
            bool isMirror = false;
            metro.ChangeAccent("Red");
            HalconWindowVisibility = "Collapsed";
            var r = await metro.ShowConfirm("确认", "请确认需要重新标定吗？");
            if (r)
            {
                metro.ChangeAccent("Blue");
                HalconWindowVisibility = "Visible";
                HImage image;
                ImageViewer imageViewer;
                ObservableCollection<ROI> rOIList;
                CameraOperate camera;
                int radius;
                string path;
                switch (p.ToString())
                {
                    case "1":
                        image = bottomCamera1.CurrentImage;
                        path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom1");
                        imageViewer = Global.BottonCamera1ImageViewer;
                        rOIList = BottomCamera1ROIList;
                        camera = bottomCamera1;
                        radius = BottomCamera1Radius;
                        break;
                    case "2":
                        image = bottomCamera2.CurrentImage;
                        path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom2");
                        imageViewer = Global.BottonCamera2ImageViewer;
                        rOIList = BottomCamera2ROIList;
                        camera = bottomCamera2;
                        radius = BottomCamera2Radius;
                        break;
                    default:
                        image = topCamera.CurrentImage;
                        path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top");
                        imageViewer = Global.TopCameraImageViewer;
                        rOIList = TopCameraROIList;
                        camera = topCamera;
                        radius = TopCameraRadius;
                        break;
                }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                ClibButtonIsEnabled = false;
                await Task.Run(() =>
                {
                    string Station = Inifile.INIGetStringValue(iniParameterPath, "System", "Station", "A");

                    int[][] diff = new int[9][] {
                    new int[] { 0,0,0},
                    new int[] { -5,-5,0},
                    new int[] { 0,-5,0},
                    new int[] { 5,-5,0},
                    new int[] { 5,0,0},
                    new int[] { 5,5,0},
                    new int[] { 0,5,0},
                    new int[] { -5,5,0},
                    new int[] { -5,0,0}
                };
                    double[][] diff_r = new double[3][] {
                    new double[] { 0,0,0},
                    new double[] { 0,0,TopCameraCalibRadius},
                    new double[] { 0,0, TopCameraCalibRadius * -1 }
                };
                    string MoveStart = "M3210";
                    string MoveFinish = "M3110";
                    string MoveData = "D3200";
                    string CameraP = "D4128";
                    string CameraRP = "D4280";
                    string StartButton = "M120";

                    switch (Station)
                    {
                        case "A":
                            MoveStart = "M3210";
                            MoveFinish = "M3110";
                            MoveData = "D3200";
                            StartButton = "M120";
                            switch (p.ToString())
                            {
                                case "1":
                                    CameraP = "D4134";
                                    CameraRP = "D4134";
                                    diff_r[1][2] = BottomCamera1CalibRadius;
                                    diff_r[2][2] = BottomCamera1CalibRadius * -1;
                                    isMirror = false;
                                    break;
                                case "2":
                                    CameraP = "D4134";
                                    CameraRP = "D4134";
                                    diff_r[1][2] = BottomCamera2CalibRadius;
                                    diff_r[2][2] = BottomCamera2CalibRadius * -1;
                                    isMirror = false;
                                    break;
                                default:
                                    CameraP = "D4128";
                                    CameraRP = "D4128";
                                    isMirror = true;
                                    break;
                            }
                            break;
                        case "B":
                            MoveStart = "M3230";
                            MoveFinish = "M3130";
                            MoveData = "D3240";
                            StartButton = "M124";
                            switch (p.ToString())
                            {
                                case "1":
                                    CameraP = "D4240";
                                    CameraRP = "D4240";
                                    diff_r[1][2] = BottomCamera1CalibRadius;
                                    diff_r[2][2] = BottomCamera1CalibRadius * -1;
                                    isMirror = false;
                                    break;
                                case "2":
                                    CameraP = "D4240";
                                    CameraRP = "D4240";
                                    diff_r[1][2] = BottomCamera2CalibRadius;
                                    diff_r[2][2] = BottomCamera2CalibRadius * -1;
                                    isMirror = false;
                                    break;
                                default:
                                    CameraP = "D4234";
                                    CameraRP = "D4234";
                                    isMirror = true;
                                    break;
                            }
                            break;
                        default:
                            break;
                    }

                    //9点标定拍照
                    int[] camerap = Fx5u.ReadMultiW(CameraP, 3);
                    if (!OnlyImage)
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            int[] senddata = new int[3] { camerap[0] + diff[i][0] * 100, camerap[1] + diff[i][1] * 100, camerap[2] + diff[i][2] * 100 };
                            Fx5u.WriteMultW(MoveData, senddata);
                            Fx5u.SetM(MoveFinish, false);
                            Fx5u.SetM(MoveStart, true);
                            AddMessage("运动到位，按启动开始拍照");
                            while (true)
                            {
                                try
                                {
                                    if (Fx5u.ReadM(MoveFinish) && Fx5u.ReadM(StartButton))
                                        break;
                                }
                                catch { }
                                System.Threading.Thread.Sleep(100);
                            }
                            camera.GrabImageVoid(radius, isMirror);
                            switch (p.ToString())
                            {
                                case "1":
                                    BottomCamera1Iamge = camera.CurrentImage;
                                    break;

                                case "2":
                                    BottomCamera2Iamge = camera.CurrentImage;
                                    break;
                                default:
                                    TopCameraIamge = camera.CurrentImage;
                                    break;
                            }
                            if (!Directory.Exists(Path.Combine(path, "Calib")))
                            {
                                Directory.CreateDirectory(Path.Combine(path, "Calib"));
                            }
                            camera.SaveImage("bmp", Path.Combine(path, "Calib", (i + 1).ToString() + ".bmp"));


                        }
                    }

                    double[][] Array1 = new double[9][];
                    for (int i = 0; i < 9; i++)
                    {
                        try
                        {
                            HObject img;
                            HOperatorSet.ReadImage(out img, Path.Combine(path, "Calib", (i + 1).ToString() + ".bmp"));
                            HTuple ModelID, row, column, angle, score;
                            if (p.ToString() == "0")
                            {
                                HOperatorSet.ReadShapeModel(Path.Combine(path, "OFF", "ShapeModel.shm"), out ModelID);
                            }
                            else
                            {
                                HOperatorSet.ReadShapeModel(Path.Combine(path, "ShapeModel.shm"), out ModelID);
                            }
                            HOperatorSet.FindShapeModel(img, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row, out column, out angle, out score);

                            Array1[i] = new double[4] { row.D, column.D, (double)camerap[0] / 100 + diff[i][0], (double)camerap[1] / 100 + diff[i][1] };
                        }
                        catch (Exception ex)
                        {
                            Array1[i] = new double[4] { 0, 0, (double)camerap[0] / 100 + diff[i][0], (double)camerap[1] / 100 + diff[i][1] };
                            AddMessage(ex.Message);
                        }
                    }
                    HTuple homMat2D = new HTuple();
                    try
                    {
                        HOperatorSet.VectorToHomMat2d(new HTuple(Array1[0][0]).TupleConcat(Array1[1][0]).TupleConcat(Array1[2][0]).TupleConcat(Array1[3][0]).TupleConcat(Array1[4][0]).TupleConcat(Array1[5][0]).TupleConcat(Array1[6][0]).TupleConcat(Array1[7][0]).TupleConcat(Array1[8][0]),
    new HTuple(Array1[0][1]).TupleConcat(Array1[1][1]).TupleConcat(Array1[2][1]).TupleConcat(Array1[3][1]).TupleConcat(Array1[4][1]).TupleConcat(Array1[5][1]).TupleConcat(Array1[6][1]).TupleConcat(Array1[7][1]).TupleConcat(Array1[8][1]),
    new HTuple(Array1[0][2]).TupleConcat(Array1[1][2]).TupleConcat(Array1[2][2]).TupleConcat(Array1[3][2]).TupleConcat(Array1[4][2]).TupleConcat(Array1[5][2]).TupleConcat(Array1[6][2]).TupleConcat(Array1[7][2]).TupleConcat(Array1[8][2]),
    new HTuple(Array1[0][3]).TupleConcat(Array1[1][3]).TupleConcat(Array1[2][3]).TupleConcat(Array1[3][3]).TupleConcat(Array1[4][3]).TupleConcat(Array1[5][3]).TupleConcat(Array1[6][3]).TupleConcat(Array1[7][3]).TupleConcat(Array1[8][3])
    , out homMat2D);
                    }
                    catch (Exception ex)
                    {
                        AddMessage(ex.Message);
                    }

                    //旋转标定拍照
                    int[] camerap1 = Fx5u.ReadMultiW(CameraRP, 3);
                    if (!OnlyImage)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            int[] senddata = new int[3] { camerap1[0] + (int)(diff_r[i][0] * 100), camerap1[1] + (int)(diff_r[i][1] * 100), camerap1[2] + (int)(diff_r[i][2] * 100) };
                            Fx5u.WriteMultW(MoveData, senddata);
                            Fx5u.SetM(MoveFinish, false);
                            Fx5u.SetM(MoveStart, true);
                            AddMessage("运动到位，按启动开始拍照");
                            while (true)
                            {
                                try
                                {
                                    if (Fx5u.ReadM(MoveFinish) && Fx5u.ReadM(StartButton))
                                        break;
                                }
                                catch { }
                                System.Threading.Thread.Sleep(100);
                            }
                            camera.GrabImageVoid(radius, isMirror);
                            switch (p.ToString())
                            {
                                case "1":
                                    BottomCamera1Iamge = camera.CurrentImage;
                                    break;

                                case "2":
                                    BottomCamera2Iamge = camera.CurrentImage;
                                    break;
                                default:
                                    TopCameraIamge = camera.CurrentImage;
                                    break;
                            }
                            if (!Directory.Exists(Path.Combine(path, "Calib")))
                            {
                                Directory.CreateDirectory(Path.Combine(path, "Calib"));
                            }
                            camera.SaveImage("bmp", Path.Combine(path, "Calib", (i + 1 + 9).ToString() + ".bmp"));
                        }
                    }

                    double[][] Array2 = new double[3][];
                    for (int i = 0; i < 3; i++)
                    {
                        try
                        {
                            HObject img;
                            HOperatorSet.ReadImage(out img, Path.Combine(path, "Calib", (i + 1 + 9).ToString() + ".bmp"));
                            HTuple ModelID, row, column, angle, score;
                            string shapmodelname = p.ToString() == "0" ? "ShapeModel2.shm" : "ShapeModel.shm";
                            HOperatorSet.ReadShapeModel(Path.Combine(path, shapmodelname), out ModelID);
                            HOperatorSet.FindShapeModel(img, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row, out column, out angle, out score);
                            Array2[i] = new double[2] { row.D, column.D };
                        }
                        catch (Exception ex)
                        {
                            Array2[i] = new double[2] { 0, 0 };
                            AddMessage(ex.Message);
                        }
                    }
                    double[] circleCenter = rotateCenter(Array2[0][0], Array2[0][1], Array2[1][0], Array2[1][1], Array2[2][0], Array2[2][1]);

                    try
                    {
                        HTuple qx0, qy0;
                        HOperatorSet.AffineTransPoint2d(homMat2D, circleCenter[0], circleCenter[1], out qx0, out qy0);
                        double delta_x = (double)camerap[0] / 100 - qx0;
                        double delta_y = (double)camerap[1] / 100 - qy0;
                        AddMessage(delta_x.ToString() + " , " + delta_y.ToString());
                        HOperatorSet.VectorToHomMat2d(new HTuple(Array1[0][0]).TupleConcat(Array1[1][0]).TupleConcat(Array1[2][0]).TupleConcat(Array1[3][0]).TupleConcat(Array1[4][0]).TupleConcat(Array1[5][0]).TupleConcat(Array1[6][0]).TupleConcat(Array1[7][0]).TupleConcat(Array1[8][0]),
                            new HTuple(Array1[0][1]).TupleConcat(Array1[1][1]).TupleConcat(Array1[2][1]).TupleConcat(Array1[3][1]).TupleConcat(Array1[4][1]).TupleConcat(Array1[5][1]).TupleConcat(Array1[6][1]).TupleConcat(Array1[7][1]).TupleConcat(Array1[8][1]),
                            new HTuple(Array1[0][2] + delta_x).TupleConcat(Array1[1][2] + delta_x).TupleConcat(Array1[2][2] + delta_x).TupleConcat(Array1[3][2] + delta_x).TupleConcat(Array1[4][2] + delta_x).TupleConcat(Array1[5][2] + delta_x).TupleConcat(Array1[6][2] + delta_x).TupleConcat(Array1[7][2] + delta_x).TupleConcat(Array1[8][2] + delta_x),
                            new HTuple(Array1[0][3] + delta_y).TupleConcat(Array1[1][3] + delta_y).TupleConcat(Array1[2][3] + delta_y).TupleConcat(Array1[3][3] + delta_y).TupleConcat(Array1[4][3] + delta_y).TupleConcat(Array1[5][3] + delta_y).TupleConcat(Array1[6][3] + delta_y).TupleConcat(Array1[7][3] + delta_y).TupleConcat(Array1[8][3] + delta_y)
                            , out homMat2D);
                        if (p.ToString() == "0")
                        {
                            HOperatorSet.WriteTuple(homMat2D, Path.Combine(path, "OFF", "homMat2D.tup"));
                            HOperatorSet.WriteTuple(homMat2D, Path.Combine(path, "ON", "homMat2D.tup"));
                        }
                        else
                        {
                            HOperatorSet.WriteTuple(homMat2D, Path.Combine(path, "homMat2D.tup"));
                        }
                        AddMessage("保存标定文件成功");
                    }
                    catch (Exception ex)
                    {
                        AddMessage(ex.Message);
                    }

                    HOperatorSet.SetColor(imageViewer.viewController.viewPort.HalconWindow, "green");
                    for (int i = 0; i < 9; i++)
                    {
                        HOperatorSet.DispCross(imageViewer.viewController.viewPort.HalconWindow, Array1[i][0], Array1[i][1], 120, 0);
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        HOperatorSet.DispCross(imageViewer.viewController.viewPort.HalconWindow, Array2[i][0], Array2[i][1], 120, 0);
                    }
                });
                ClibButtonIsEnabled = true;
            }
            else
            {
                metro.ChangeAccent("Blue");
                HalconWindowVisibility = "Visible";
            }

        }
        private async void CreateLineCommandExecute(object p)
        {
            metro.ChangeAccent("Red");
            HalconWindowVisibility = "Collapsed";
            var r = await metro.ShowConfirm("确认", "请确认需要重新画直线吗？");
            if (r)
            {
                metro.ChangeAccent("Blue");
                HalconWindowVisibility = "Visible";
                try
                {
                    HImage image;
                    ImageViewer imageViewer;
                    CameraOperate camera;

                    string path;
                    switch (p.ToString())
                    {
                        case "1":
                            image = bottomCamera1.CurrentImage;
                            path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom1");
                            imageViewer = Global.BottonCamera1ImageViewer;
                            camera = bottomCamera1;
                            BottomCamera1AppendHObject = null;
                            break;
                        case "2":
                            image = bottomCamera2.CurrentImage;
                            path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom2");
                            imageViewer = Global.BottonCamera2ImageViewer;
                            camera = bottomCamera2;
                            BottomCamera2AppendHObject = null;
                            break;
                        default:
                            image = topCamera.CurrentImage;
                            switch (TopCameraProductIndex)
                            {
                                case 1:
                                    path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top\ON");
                                    break;
                                case 0:
                                default:
                                    path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top\OFF");
                                    break;
                            }
                            imageViewer = Global.TopCameraImageViewer;
                            camera = topCamera;
                            TopCameraAppendHObject = null;
                            break;
                    }

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    ROI roi = imageViewer.DrawROI(ROI.ROI_TYPE_RECTANGLE2);
                    HOperatorSet.SetColor(imageViewer.viewController.viewPort.HalconWindow, "green");
                    switch (p.ToString())
                    {
                        case "1":
                            BottomCamera1AppendHObject = roi.getRegion();
                            break;
                        case "2":
                            BottomCamera2AppendHObject = roi.getRegion();
                            break;
                        default:
                            TopCameraAppendHObject = roi.getRegion();
                            break;
                    }
                    HOperatorSet.WriteRegion(roi.getRegion(), Path.Combine(path, "Line.hobj"));
                    AddMessage("画直线完成");
                }
                catch (Exception ex)
                {
                    AddMessage(ex.Message);
                }

            }
            else
            {
                metro.ChangeAccent("Blue");
                HalconWindowVisibility = "Visible";
            }
        }
        private void TopCameraProductSelectCommandExecute(object p)
        {
            switch (p.ToString())
            {
                case "0":
                    TopCameraProductIndex = 0;
                    AddMessage("上相机选择：旋转OFF");
                    break;
                case "1":
                    TopCameraProductIndex = 1;
                    AddMessage("上相机选择：旋转ON");
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region 自定义函数
        private void Init()
        {
            MessageStr = "";
            NoiseValue = 0;
            OnlyImage = true;
            string Station = Inifile.INIGetStringValue(iniParameterPath, "System", "Station", "A");
            WindowTitle = "SZVppFilmUI20200710:" + Station;
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
            ClibButtonIsEnabled = true;
            TopCameraRadius = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "TopCameraRadius", "0"));
            BottomCamera1Radius = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "BottomCamera1Radius", "0"));
            BottomCamera2Radius = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "BottomCamera2Radius", "0"));
            TopCameraContrast = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "TopCameraContrast", "30"));
            BottomCamera1Contrast = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "BottomCamera1Contrast", "30"));
            BottomCamera2Contrast = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "BottomCamera2Contrast", "30"));
            TopCameraLow = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "TopCameraLow", "20"));
            BottomCamera1Low = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "BottomCamera1Low", "20"));
            BottomCamera2Low = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "BottomCamera2Low", "20"));
            TopCameraCalibRadius = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "TopCameraCalibRadius", "5"));
            BottomCamera1CalibRadius = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "BottomCamera1CalibRadius", "5"));
            BottomCamera2CalibRadius = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Camera", "BottomCamera2CalibRadius", "5"));
            string plc_ip = Inifile.INIGetStringValue(iniParameterPath, "System", "PLCIP", "192.168.1.13");
            int plc_port = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "System", "PLCPORT", "3900"));

            Fx5u = new Fx5u(plc_ip, plc_port);
            Fx5u.ConnectStateChanged += Fx5uConnectStateChanged;
            try
            {
                using (StreamReader reader = new StreamReader(Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top", "TopCameraDiff1.json")))
                {
                    string json = reader.ReadToEnd();
                    TopCameraDiff1 = JsonConvert.DeserializeObject<PointViewModel>(json);
                }
            }
            catch (Exception ex)
            {
                TopCameraDiff1 = new PointViewModel();
                AddMessage(ex.Message);
            }
            try
            {
                using (StreamReader reader = new StreamReader(Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top", "TopCameraDiff2.json")))
                {
                    string json = reader.ReadToEnd();
                    TopCameraDiff2 = JsonConvert.DeserializeObject<PointViewModel>(json);
                }
            }
            catch (Exception ex)
            {
                TopCameraDiff2 = new PointViewModel();
                AddMessage(ex.Message);
            }
            try
            {
                using (StreamReader reader = new StreamReader(Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom1", "BottomCamera1Diff.json")))
                {
                    string json = reader.ReadToEnd();
                    BottomCamera1Diff = JsonConvert.DeserializeObject<PointViewModel>(json);
                }
            }
            catch (Exception ex)
            {
                BottomCamera1Diff = new PointViewModel();
                AddMessage(ex.Message);
            }
            try
            {
                using (StreamReader reader = new StreamReader(Path.Combine(System.Environment.CurrentDirectory, @"Camera\Bottom2", "BottomCamera2Diff.json")))
                {
                    string json = reader.ReadToEnd();
                    BottomCamera2Diff = JsonConvert.DeserializeObject<PointViewModel>(json);
                }
            }
            catch (Exception ex)
            {
                BottomCamera2Diff = new PointViewModel();
                AddMessage(ex.Message);
            }
            #region 报警文档
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                string alarmExcelPath = Path.Combine(System.Environment.CurrentDirectory, "VPP贴膜下料机报警.xlsx");
                if (File.Exists(alarmExcelPath))
                {

                    FileInfo existingFile = new FileInfo(alarmExcelPath);
                    using (ExcelPackage package = new ExcelPackage(existingFile))
                    {
                        // get the first worksheet in the workbook
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        for (int i = 1; i <= worksheet.Dimension.End.Row; i++)
                        {
                            AlarmData ad = new AlarmData();
                            ad.Code = worksheet.Cells["A" + i.ToString()].Value == null ? "Null" : worksheet.Cells["A" + i.ToString()].Value.ToString();
                            ad.Content = worksheet.Cells["B" + i.ToString()].Value == null ? "Null" : worksheet.Cells["B" + i.ToString()].Value.ToString();
                            ad.Type = worksheet.Cells["C" + i.ToString()].Value == null ? "Null" : worksheet.Cells["C" + i.ToString()].Value.ToString();
                            ad.Start = DateTime.Now;
                            ad.End = DateTime.Now;
                            ad.State = false;
                            AlarmList.Add(ad);
                        }
                        AddMessage("读取到" + worksheet.Dimension.End.Row.ToString() + "条报警");
                    }
                }
                else
                {
                    AddMessage("VPP贴膜下料机报警.xlsx 文件不存在");
                }
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }
            #endregion
            try
            {
                if (!Directory.Exists("E:\\RecordImages"))
                {
                    Directory.CreateDirectory("E:\\RecordImages");
                }
                if (!Directory.Exists("E:\\RecordImages\\top1"))
                {
                    Directory.CreateDirectory("E:\\RecordImages\\top1");
                }
                if (!Directory.Exists("E:\\RecordImages\\top2"))
                {
                    Directory.CreateDirectory("E:\\RecordImages\\top2");
                }
                if (!Directory.Exists("E:\\RecordImages\\bottom1"))
                {
                    Directory.CreateDirectory("E:\\RecordImages\\bottom1");
                }
                if (!Directory.Exists("E:\\RecordImages\\bottom2"))
                {
                    Directory.CreateDirectory("E:\\RecordImages\\bottom2");
                }
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }            
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
            string CurrentAlarm = "";
            if (!Directory.Exists("D:\\报警记录"))
            {
                Directory.CreateDirectory("D:\\报警记录");
            }
            while (true)
            {
                await Task.Delay(100);
                #region UI更新
                StatusTop = topCamera.Connected;
                StatusBottom1 = bottomCamera1.Connected;
                StatusBottom2 = bottomCamera2.Connected;
                #endregion
                #region 报警记录
                try
                {
                    if (M300 != null && StatusPLC)
                    {
                        for (int i = 0; i < AlarmList.Count; i++)
                        {
                            if (M300[i] != AlarmList[i].State && AlarmList[i].Content != "Null")
                            {
                                AlarmList[i].State = M300[i];
                                if (AlarmList[i].State)
                                {
                                    AlarmList[i].Start = DateTime.Now;
                                    AlarmList[i].End = DateTime.Now;
                                    AddMessage(AlarmList[i].Code + AlarmList[i].Content + "发生");
                                    if (CurrentAlarm != AlarmList[i].Content)
                                    {
                                        string banci = GetBanci();
                                        if (!File.Exists(Path.Combine("D:\\报警记录", "VPP贴膜下料机报警记录" + banci + ".csv")))
                                        {
                                            string[] heads = new string[] { "时间", "内容" };
                                            Csvfile.savetocsv(Path.Combine("D:\\报警记录", "VPP贴膜下料机报警记录" + banci + ".csv"), heads);
                                        }
                                        string[] conts = new string[] { AlarmList[i].Start.ToString(), AlarmList[i].Content };
                                        Csvfile.savetocsv(Path.Combine("D:\\报警记录", "VPP贴膜下料机报警记录" + banci + ".csv"), conts);
                                        CurrentAlarm = AlarmList[i].Content;
                                    }
                                }

                            }
                        }

                    }
                }
                catch
                {

                }
                #endregion
            }
        }
        private void SystemRun()
        {
            Stopwatch sw = new Stopwatch();
            ModbusRTURead MESDriverRead = new ModbusRTURead();
            bool serialportconnect = false;
            int noisereadcount = 0;
            string Station = Inifile.INIGetStringValue(iniParameterPath, "System", "Station", "A");
            string _COM = Inifile.INIGetStringValue(iniParameterPath, "System", "NoiseCOM", "COM16");
            string isRecordImage = Inifile.INIGetStringValue(iniParameterPath, "System", "isRecordImage", "0");
            MESDriverRead.ModbusInit(_COM, 4800, Parity.None, 8, StopBits.One);
            if (Station == "A")
            {
                serialportconnect = MESDriverRead.ModbusConnect();
                AddMessage("噪声监控设备端口打开" + (serialportconnect ? "成功" : "失败"));
            }
            while (true)
            {
                sw.Restart();
                System.Threading.Thread.Sleep(10);
                try
                {
                    switch (Station)
                    {
                        case "A":
                            #region PLC部分
                            if (Fx5u.ReadM("M3100"))
                            {
                                Fx5u.SetM("M3100", false);
                                Fx5u.SetMultiM("M3200", new bool[] { false, false });
                                AddMessage("上相机拍照1");
                                try
                                {
                                    bool rst = topCamera.GrabImage(TopCameraRadius, true);
                                    if (rst)
                                    {
                                        TopCameraIamge = topCamera.CurrentImage;
                                        if (isRecordImage != "0")
                                        {
                                            topCamera.SaveImage("bmp", Path.Combine("E:\\RecordImages\\top1", DateTime.Now.ToString("yyyyMMddHHmmss") + "Top1.bmp"));
                                        }
                                        //var calcrst = TopCameraCalc("D4116", TopCameraDiff1.X, TopCameraDiff1.Y, TopCameraDiff1.U, 0);
                                        Tuple<int[], bool> calcrst = new Tuple<int[], bool>(new int[3]{ 0, 0, 0 }, true );
                                        AddMessage(calcrst.Item1[0].ToString() + "," + calcrst.Item1[1].ToString() + "," + calcrst.Item1[2].ToString());
                                        CalcRecord(0, calcrst);
                                        Fx5u.WriteMultW("D3206", calcrst.Item1);
                                        Fx5u.SetM("M3201", calcrst.Item2);
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
                                    bool rst = topCamera.GrabImage(TopCameraRadius, true);
                                    if (rst)
                                    {
                                        TopCameraIamge = topCamera.CurrentImage;
                                        if (isRecordImage != "0")
                                        {
                                            topCamera.SaveImage("bmp", Path.Combine("E:\\RecordImages\\top2", DateTime.Now.ToString("yyyyMMddHHmmss") + "Top2.bmp"));
                                        }
                                        //var calcrst = TopCameraCalc("D4122", TopCameraDiff2.X, TopCameraDiff2.Y, TopCameraDiff2.U, 1);
                                        Tuple<int[], bool> calcrst = new Tuple<int[], bool>(new int[3] { 0, 0, 0 }, true);
                                        AddMessage(calcrst.Item1[0].ToString() + "," + calcrst.Item1[1].ToString() + "," + calcrst.Item1[2].ToString());
                                        CalcRecord(1, calcrst);
                                        Fx5u.WriteMultW("D3206", calcrst.Item1);
                                        Fx5u.SetM("M3203", calcrst.Item2);
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
                                    Task.Run(() => { rst1 = bottomCamera1.GrabImage(BottomCamera1Radius, false); finish1 = true; });
                                    Task.Run(() => { rst2 = bottomCamera2.GrabImage(BottomCamera2Radius, false); finish2 = true; });
                                    while (!finish1 || !finish2)
                                    {
                                        System.Threading.Thread.Sleep(10);
                                    }
                                    if (rst1)
                                    {
                                        BottomCamera1Iamge = bottomCamera1.CurrentImage;
                                        if (isRecordImage != "0")
                                        {
                                            bottomCamera1.SaveImage("bmp", Path.Combine("E:\\RecordImages\\bottom1", DateTime.Now.ToString("yyyyMMddHHmmss") + "bottom1.bmp"));
                                        }
                                        var calcrst = BottomCamera1Calc("D4134", "D4086", BottomCamera1Diff.X, BottomCamera1Diff.Y, BottomCamera1Diff.U);
                                        AddMessage(calcrst.Item1[0].ToString() + "," + calcrst.Item1[1].ToString() + "," + calcrst.Item1[2].ToString());
                                        CalcRecord(2, calcrst);
                                        Fx5u.WriteMultW("D3212", calcrst.Item1);
                                        Fx5u.SetM("M3205", calcrst.Item2);
                                    }
                                    if (rst2)
                                    {
                                        BottomCamera2Iamge = bottomCamera2.CurrentImage;
                                        if (isRecordImage != "0")
                                        {
                                            bottomCamera2.SaveImage("bmp", Path.Combine("E:\\RecordImages\\bottom2", DateTime.Now.ToString("yyyyMMddHHmmss") + "bottom2.bmp"));
                                        }
                                        var calcrst = BottomCamera2Calc("D4134", "D4092", BottomCamera2Diff.X, BottomCamera2Diff.Y, BottomCamera2Diff.U);
                                        AddMessage(calcrst.Item1[0].ToString() + "," + calcrst.Item1[1].ToString() + "," + calcrst.Item1[2].ToString());
                                        CalcRecord(3, calcrst);
                                        Fx5u.WriteMultW("D3218", calcrst.Item1);
                                        Fx5u.SetM("M3206", calcrst.Item2);
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
                            #endregion
                            #region 噪声检测部分
                            if (noisereadcount++ > 10)
                            {
                                noisereadcount = 0;
                                try
                                {
                                    if (serialportconnect)
                                    {
                                        string s1 = MESDriverRead.Read("0000", "01", "0001");
                                        short v1 = Convert.ToInt16(s1, 16);
                                        NoiseValue = (double)v1 / 10;
                                        Fx5u.WriteD("D4510", v1);
                                    }
                                }
                                catch
                                {

                                }
                            }

                            #endregion
                            break;
                        case "B":
                            #region PLC部分
                            if (Fx5u.ReadM("M3120"))
                            {
                                Fx5u.SetM("M3120", false);
                                Fx5u.SetMultiM("M3220", new bool[] { false, false });
                                AddMessage("上相机拍照1");
                                try
                                {
                                    bool rst = topCamera.GrabImage(TopCameraRadius, true);
                                    if (rst)
                                    {
                                        TopCameraIamge = topCamera.CurrentImage;
                                        if (isRecordImage != "0")
                                        {
                                            topCamera.SaveImage("bmp", Path.Combine("E:\\RecordImages\\top1", DateTime.Now.ToString("yyyyMMddHHmmss") + "Top1.bmp"));
                                        }
                                        //var calcrst = TopCameraCalc("D4222", TopCameraDiff1.X, TopCameraDiff1.Y, TopCameraDiff1.U, 0);
                                        Tuple<int[], bool> calcrst = new Tuple<int[], bool>(new int[3] { 0, 0, 0 }, true);
                                        AddMessage(calcrst.Item1[0].ToString() + "," + calcrst.Item1[1].ToString() + "," + calcrst.Item1[2].ToString());
                                        CalcRecord(0, calcrst);
                                        Fx5u.WriteMultW("D3246", calcrst.Item1);
                                        Fx5u.SetM("M3221", calcrst.Item2);
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
                                Fx5u.SetM("M3220", true);
                            }

                            if (Fx5u.ReadM("M3121"))
                            {
                                Fx5u.SetM("M3121", false);
                                Fx5u.SetMultiM("M3222", new bool[] { false, false });
                                AddMessage("上相机拍照2");
                                try
                                {
                                    bool rst = topCamera.GrabImage(TopCameraRadius, true);
                                    if (rst)
                                    {
                                        TopCameraIamge = topCamera.CurrentImage;
                                        if (isRecordImage != "0")
                                        {
                                            topCamera.SaveImage("bmp", Path.Combine("E:\\RecordImages\\top2", DateTime.Now.ToString("yyyyMMddHHmmss") + "Top2.bmp"));
                                        }
                                        //var calcrst = TopCameraCalc("D4228", TopCameraDiff2.X, TopCameraDiff2.Y, TopCameraDiff2.U, 1);
                                        Tuple<int[], bool> calcrst = new Tuple<int[], bool>(new int[3] { 0, 0, 0 }, true);
                                        AddMessage(calcrst.Item1[0].ToString() + "," + calcrst.Item1[1].ToString() + "," + calcrst.Item1[2].ToString());
                                        CalcRecord(1, calcrst);
                                        Fx5u.WriteMultW("D3246", calcrst.Item1);
                                        Fx5u.SetM("M3223", calcrst.Item2);
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
                                Fx5u.SetM("M3222", true);
                            }

                            if (Fx5u.ReadM("M3122"))
                            {
                                Fx5u.SetM("M3122", false);
                                Fx5u.SetMultiM("M3224", new bool[] { false, false, false });
                                AddMessage("下相机拍照");
                                try
                                {
                                    bool rst1 = false, rst2 = false, finish1 = false, finish2 = false;
                                    Task.Run(() => { rst1 = bottomCamera1.GrabImage(BottomCamera1Radius, false); finish1 = true; });
                                    Task.Run(() => { rst2 = bottomCamera2.GrabImage(BottomCamera2Radius, false); finish2 = true; });
                                    while (!finish1 || !finish2)
                                    {
                                        System.Threading.Thread.Sleep(10);
                                    }
                                    if (rst1)
                                    {
                                        BottomCamera1Iamge = bottomCamera1.CurrentImage;
                                        if (isRecordImage != "0")
                                        {
                                            bottomCamera1.SaveImage("bmp", Path.Combine("E:\\RecordImages\\bottom1", DateTime.Now.ToString("yyyyMMddHHmmss") + "bottom1.bmp"));
                                        }
                                        var calcrst = BottomCamera1Calc("D4240", "D4192", BottomCamera1Diff.X, BottomCamera1Diff.Y, BottomCamera1Diff.U);
                                        AddMessage(calcrst.Item1[0].ToString() + "," + calcrst.Item1[1].ToString() + "," + calcrst.Item1[2].ToString());
                                        CalcRecord(2, calcrst);
                                        Fx5u.WriteMultW("D3252", calcrst.Item1);
                                        Fx5u.SetM("M3225", calcrst.Item2);
                                    }
                                    if (rst2)
                                    {
                                        BottomCamera2Iamge = bottomCamera2.CurrentImage;
                                        if (isRecordImage != "0")
                                        {
                                            bottomCamera2.SaveImage("bmp", Path.Combine("E:\\RecordImages\\bottom2", DateTime.Now.ToString("yyyyMMddHHmmss") + "bottom2.bmp"));
                                        }
                                        var calcrst = BottomCamera2Calc("D4240", "D4198", BottomCamera2Diff.X, BottomCamera2Diff.Y, BottomCamera2Diff.U);
                                        AddMessage(calcrst.Item1[0].ToString() + "," + calcrst.Item1[1].ToString() + "," + calcrst.Item1[2].ToString());
                                        CalcRecord(3, calcrst);
                                        Fx5u.WriteMultW("D3258", calcrst.Item1);
                                        Fx5u.SetM("M3226", calcrst.Item2);
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
                                Fx5u.SetM("M3224", true);
                            }
                            #endregion
                            if (noisereadcount++ > 10)
                            {
                                noisereadcount = 0;
                                NoiseValue = (double)Fx5u.ReadD("D4510") / 10;
                            }
                            break;
                        default:
                            break;
                    }
                    //读报警
                    M300 = Fx5u.ReadMultiM("M300", 64);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Cycle = sw.ElapsedMilliseconds;
            }
        }
        private void CalcRecord(int index, Tuple<int[], bool> data)
        {
            string sheetname;
            switch (index)
            {
                case 1:
                    sheetname = "top2";
                    break;
                case 2:
                    sheetname = "bottom1";
                    break;
                case 3:
                    sheetname = "bottom2";
                    break;
                case 0:
                default:
                    sheetname = "top1";
                    break;
            }
            try
            {
                string calcExcelPath = Path.Combine(System.Environment.CurrentDirectory, "calcrecorddata.xlsx");
                if (File.Exists(calcExcelPath))
                {

                    FileInfo existingFile = new FileInfo(calcExcelPath);
                    using (ExcelPackage package = new ExcelPackage(existingFile))
                    {

                        ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetname];
                        int rownum;
                        if (worksheet.Dimension == null)
                            rownum = 1;
                        else
                            rownum = worksheet.Dimension.End.Row + 1;
                        worksheet.Cells["A" + rownum].Value = DateTime.Now.ToString();
                        worksheet.Cells["B" + rownum].Value = data.Item1[0];
                        worksheet.Cells["C" + rownum].Value = data.Item1[1];
                        worksheet.Cells["D" + rownum].Value = data.Item1[2];
                        worksheet.Cells["E" + rownum].Value = data.Item2;
                        worksheet.Cells.AutoFitColumns();
                        package.Save();
                    }
                }
                else
                {
                    AddMessage(calcExcelPath + "不存在");
                }
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }

        }
        private Tuple<int[], bool> TopCameraCalc(string TargetD, double _x, double _y, double _u, int pindex)
        {
            try
            {
                #region 读取PLC坐标
                //int[] camerap = Fx5u.ReadMultiW("D4128", 3);
                int[] targetp = Fx5u.ReadMultiW(TargetD, 3);
                #endregion
                #region 识别图像
                //找模板
                string path;
                switch (pindex)
                {
                    case 1:
                        path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top\ON");
                        break;
                    case 0:
                    default:
                        path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top\OFF");
                        break;
                }
                HObject ModelImage;
                HOperatorSet.ReadImage(out ModelImage, Path.Combine(path, "ModelImage.bmp"));
                HTuple ModelID, row, column, angle, score, row1, column1, angle1, score1;
                HOperatorSet.ReadShapeModel(Path.Combine(path, "ShapeModel.shm"), out ModelID);
                HObject ImageRegion;
                HOperatorSet.ReadRegion(out ImageRegion, Path.Combine(path, "Region.hobj"));
                HObject ImageReduced;
                HOperatorSet.ReduceDomain(ModelImage, ImageRegion, out ImageReduced);
                HOperatorSet.FindShapeModel(ImageReduced, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row, out column, out angle, out score);
                HOperatorSet.ReduceDomain(topCamera.CurrentImage, ImageRegion, out ImageReduced);
                HOperatorSet.FindShapeModel(ImageReduced, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row1, out column1, out angle1, out score1);
                HTuple homMat2D;
                HOperatorSet.VectorAngleToRigid(row, column, angle, row1, column1, angle, out homMat2D);
                HObject modelRegion;
                HOperatorSet.ReadRegion(out modelRegion, Path.Combine(path, "ModelRegion.hobj"));
                HObject regionAffineTrans;
                HOperatorSet.AffineTransRegion(modelRegion, out regionAffineTrans, homMat2D, "nearest_neighbor");
                Tuple<string, object> t = new Tuple<string, object>("Color", "green");
                TopCameraGCStyle = t;
                TopCameraAppendHObject = null;
                TopCameraAppendHObject = regionAffineTrans;
                AddMessage("找到模板: Row:" + row1.D.ToString("F0") + " Column:" + column1.D.ToString("F0") + " Angle:" + angle1.TupleDeg().D.ToString("F2") + " Score:" + score1.D.ToString("F1"));

                //确认角度
                HObject lineRegion;
                HOperatorSet.ReadRegion(out lineRegion, Path.Combine(path, "Line.hobj"));
                HObject imageReduced1;
                HOperatorSet.ReduceDomain(ModelImage, lineRegion, out imageReduced1);
                HObject edges1;
                HOperatorSet.EdgesSubPix(imageReduced1, out edges1, "canny", 1, TopCameraLow, TopCameraLow + 20);
                HObject contoursSplit1;
                HOperatorSet.SegmentContoursXld(edges1, out contoursSplit1, "lines_circles", 5, 4, 2);
                HObject selectedContours1;
                HOperatorSet.SelectContoursXld(contoursSplit1, out selectedContours1, "contour_length", 15, 500, -0.5, 0.5);
                HObject unionContours1;
                HOperatorSet.UnionAdjacentContoursXld(selectedContours1, out unionContours1, 10, 1, "attr_keep");
                HTuple rowBegin1, colBegin1, rowEnd1, colEnd1, nr1, nc1, dist1;
                HOperatorSet.FitLineContourXld(unionContours1, "tukey", -1, 0, 5, 2, out rowBegin1, out colBegin1, out rowEnd1, out colEnd1, out nr1, out nc1, out dist1);
                HObject regionLine;
                HOperatorSet.GenRegionLine(out regionLine, rowBegin1, colBegin1, rowEnd1, colEnd1);
                var index = FindMaxLine(regionLine);
                double lineAngle1 = Math.Atan2((nc1.DArr[index]), (nr1.DArr[index])) * 180 / Math.PI - 90;

                HObject regionLineAffineTrans;
                HOperatorSet.AffineTransRegion(lineRegion, out regionLineAffineTrans, homMat2D, "nearest_neighbor");
                HOperatorSet.ReduceDomain(topCamera.CurrentImage, regionLineAffineTrans, out imageReduced1);
                HOperatorSet.EdgesSubPix(imageReduced1, out edges1, "canny", 1, TopCameraLow, TopCameraLow + 20);
                HOperatorSet.SegmentContoursXld(edges1, out contoursSplit1, "lines_circles", 5, 4, 2);
                HOperatorSet.SelectContoursXld(contoursSplit1, out selectedContours1, "contour_length", 15, 500, -0.5, 0.5);
                HOperatorSet.UnionAdjacentContoursXld(selectedContours1, out unionContours1, 10, 1, "attr_keep");
                HOperatorSet.FitLineContourXld(unionContours1, "tukey", -1, 0, 5, 2, out rowBegin1, out colBegin1, out rowEnd1, out colEnd1, out nr1, out nc1, out dist1);
                HOperatorSet.GenRegionLine(out regionLine, rowBegin1, colBegin1, rowEnd1, colEnd1);
                TopCameraAppendHObject = regionLine;
                index = FindMaxLine(regionLine);
                double lineAngle2 = Math.Atan2((nc1.DArr[index]), (nr1.DArr[index])) * 180 / Math.PI - 90;



                //坐标变换
                HOperatorSet.ReadTuple(Path.Combine(path, "homMat2D.tup"), out homMat2D);
                HTuple CamImage_x, CamImage_y;
                HOperatorSet.AffineTransPoint2d(homMat2D, row, column, out CamImage_x, out CamImage_y);
                HTuple CamImage_x1, CamImage_y1;
                HOperatorSet.AffineTransPoint2d(homMat2D, row1, column1, out CamImage_x1, out CamImage_y1);
                HTuple T3;
                HOperatorSet.VectorAngleToRigid(CamImage_x, CamImage_y, new HTuple(lineAngle1).TupleRad(), CamImage_x1 + _x, CamImage_y1 + _y, new HTuple(lineAngle2 + _u).TupleRad(), out T3);//T3是模板料移动到新料位置的变换
                HTuple FitRobot_x1, FitRobot_y1;
                HOperatorSet.AffineTransPoint2d(T3, (double)targetp[0] / 100, (double)targetp[1] / 100, out FitRobot_x1, out FitRobot_y1);//移动到新料与模板料重合
                //HOperatorSet.AffineTransPoint2d(T3, CamImage_x - 90, CamImage_y, out FitRobot_x1, out FitRobot_y1);//移动到新料与模板料重合
                #endregion
                #region 范围
                bool result = true;
                if (FitRobot_x1.D * 100 - targetp[0] > 1000 || FitRobot_x1.D * 100 - targetp[0] < -1000)
                {
                    result = false;
                }
                else
                {
                    if (FitRobot_y1.D * 100 - targetp[1] > 1000 || FitRobot_y1.D * 100 - targetp[1] < -1000)
                    {
                        result = false;
                    }
                    else
                    {
                        if (lineAngle1 - lineAngle2 > 5 || lineAngle1 - lineAngle2 < -5)
                        {
                            result = false;
                        }
                    }
                }
                #endregion
                return new Tuple<int[], bool>(new int[3] { (int)(FitRobot_x1.D * 100 - targetp[0]), (int)(FitRobot_y1.D * 100 - targetp[1]), (int)((lineAngle2 + _u - lineAngle1) * 100) }, result); ;
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
                return new Tuple<int[], bool>(new int[3] { 0, 0, 0 }, false);
            }

        }
        private Tuple<int[], bool> BottomCamera1Calc(string CameraD, string TargetD, double _x, double _y, double _u)
        {
            try
            {
                #region 读取PLC坐标
                int[] camerap = Fx5u.ReadMultiW(CameraD, 3);
                int[] targetp = Fx5u.ReadMultiW(TargetD, 3);
                #endregion
                #region 识别图像
                //找模板
                string path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\\Bottom1");
                HObject ModelImage;
                HOperatorSet.ReadImage(out ModelImage, Path.Combine(path, "ModelImage.bmp"));
                HTuple ModelID, row, column, angle, score, row1, column1, angle1, score1;
                HOperatorSet.ReadShapeModel(Path.Combine(path, "ShapeModel.shm"), out ModelID);
                HObject ImageRegion;
                HOperatorSet.ReadRegion(out ImageRegion, Path.Combine(path, "Region.hobj"));
                HObject ImageReduced;
                HOperatorSet.ReduceDomain(ModelImage, ImageRegion, out ImageReduced);
                HOperatorSet.FindShapeModel(ImageReduced, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row, out column, out angle, out score);
                HOperatorSet.ReduceDomain(bottomCamera1.CurrentImage, ImageRegion, out ImageReduced);
                HOperatorSet.FindShapeModel(ImageReduced, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row1, out column1, out angle1, out score1);
                HTuple homMat2D;
                HOperatorSet.VectorAngleToRigid(row, column, angle, row1, column1, angle1, out homMat2D);
                HObject modelRegion;
                HOperatorSet.ReadRegion(out modelRegion, Path.Combine(path, "ModelRegion.hobj"));
                HObject regionAffineTrans;
                HOperatorSet.AffineTransRegion(modelRegion, out regionAffineTrans, homMat2D, "nearest_neighbor");
                Tuple<string, object> t = new Tuple<string, object>("Color", "green");
                BottomCamera1GCStyle = t;
                BottomCamera1AppendHObject = null;
                BottomCamera1AppendHObject = regionAffineTrans;
                AddMessage("找到模板: Row:" + row1.D.ToString("F0") + " Column:" + column1.D.ToString("F0") + " Angle:" + angle1.TupleDeg().D.ToString("F2") + " Score:" + score1.D.ToString("F1"));
                //确认角度
                HObject lineRegion;
                HOperatorSet.ReadRegion(out lineRegion, Path.Combine(path, "Line.hobj"));
                HObject imageReduced1;
                HOperatorSet.ReduceDomain(ModelImage, lineRegion, out imageReduced1);
                HObject edges1;
                HOperatorSet.EdgesSubPix(imageReduced1, out edges1, "canny", 1, BottomCamera1Low, BottomCamera1Low + 20);
                HObject contoursSplit1;
                HOperatorSet.SegmentContoursXld(edges1, out contoursSplit1, "lines_circles", 5, 4, 2);
                HObject selectedContours1;
                HOperatorSet.SelectContoursXld(contoursSplit1, out selectedContours1, "contour_length", 15, 500, -0.5, 0.5);
                HObject unionContours1;
                HOperatorSet.UnionAdjacentContoursXld(selectedContours1, out unionContours1, 10, 1, "attr_keep");
                HTuple rowBegin1, colBegin1, rowEnd1, colEnd1, nr1, nc1, dist1;
                HOperatorSet.FitLineContourXld(unionContours1, "tukey", -1, 0, 5, 2, out rowBegin1, out colBegin1, out rowEnd1, out colEnd1, out nr1, out nc1, out dist1);
                HObject regionLine;
                HOperatorSet.GenRegionLine(out regionLine, rowBegin1, colBegin1, rowEnd1, colEnd1);
                var index = FindMaxLine(regionLine);
                double lineAngle1 = Math.Atan2((nc1.DArr[index]), (nr1.DArr[index])) * 180 / Math.PI - 90;

                HObject regionLineAffineTrans;
                HOperatorSet.AffineTransRegion(lineRegion, out regionLineAffineTrans, homMat2D, "nearest_neighbor");
                HOperatorSet.ReduceDomain(bottomCamera1.CurrentImage, regionLineAffineTrans, out imageReduced1);
                HOperatorSet.EdgesSubPix(imageReduced1, out edges1, "canny", 1, BottomCamera1Low, BottomCamera1Low + 20);
                HOperatorSet.SegmentContoursXld(edges1, out contoursSplit1, "lines_circles", 5, 4, 2);
                HOperatorSet.SelectContoursXld(contoursSplit1, out selectedContours1, "contour_length", 15, 500, -0.5, 0.5);
                HOperatorSet.UnionAdjacentContoursXld(selectedContours1, out unionContours1, 10, 1, "attr_keep");
                HOperatorSet.FitLineContourXld(unionContours1, "tukey", -1, 0, 5, 2, out rowBegin1, out colBegin1, out rowEnd1, out colEnd1, out nr1, out nc1, out dist1);
                HOperatorSet.GenRegionLine(out regionLine, rowBegin1, colBegin1, rowEnd1, colEnd1);
                BottomCamera1AppendHObject = regionLine;
                index = FindMaxLine(regionLine);
                double lineAngle2 = Math.Atan2((nc1.DArr[index]), (nr1.DArr[index])) * 180 / Math.PI - 90;
                //坐标变换
                HOperatorSet.ReadTuple(Path.Combine(path, "homMat2D.tup"), out homMat2D);
                HTuple CamImage_x, CamImage_y;
                HOperatorSet.AffineTransPoint2d(homMat2D, row, column, out CamImage_x, out CamImage_y);
                HTuple CamImage_x1, CamImage_y1;
                HOperatorSet.AffineTransPoint2d(homMat2D, row1, column1, out CamImage_x1, out CamImage_y1);
                HTuple T2;
                HOperatorSet.VectorAngleToRigid(CamImage_x1, CamImage_y1, new HTuple(lineAngle2 * -1).TupleRad(), CamImage_x, CamImage_y, new HTuple(lineAngle1 * -1).TupleRad(), out T2);//T2是新料移动到模板料位置的变换
                HTuple T1;
                HOperatorSet.VectorAngleToRigid((double)camerap[0] / 100, (double)camerap[1] / 100, new HTuple((double)camerap[2] / 100).TupleRad(), (double)targetp[0] / 100 + _x, (double)targetp[1] / 100 + _y, new HTuple((double)targetp[2] / 100 + _u).TupleRad(), out T1);//T1是拍照位置移动到贴合位置的变换
                HTuple CamRobot_x1, CamRobot_y1;
                HOperatorSet.AffineTransPoint2d(T2, (double)camerap[0] / 100, (double)camerap[1] / 100, out CamRobot_x1, out CamRobot_y1);//移动到新料与模板料重合
                HTuple FitRobot_x1, FitRobot_y1;
                HOperatorSet.AffineTransPoint2d(T1, CamRobot_x1, CamRobot_y1, out FitRobot_x1, out FitRobot_y1);//移动到贴合位置

                #endregion
                #region 范围
                bool result = true;
                if (FitRobot_x1.D * 100 - targetp[0] > 1000 || FitRobot_x1.D * 100 - targetp[0] < -1000)
                {
                    result = false;
                }
                else
                {
                    if (FitRobot_y1.D * 100 - targetp[1] > 1000 || FitRobot_y1.D * 100 - targetp[1] < -1000)
                    {
                        result = false;
                    }
                    else
                    {
                        if (lineAngle1 - lineAngle2 > 15 || lineAngle1 - lineAngle2 < -15)
                        {
                            result = false;
                        }
                    }
                }
                #endregion
                return new Tuple<int[], bool>(new int[3] { (int)(FitRobot_x1.D * 100 - targetp[0]), (int)(FitRobot_y1.D * 100 - targetp[1]), (int)(((lineAngle1 - lineAngle2) * -1 + _u) * 100) }, result);
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
                return new Tuple<int[], bool>(new int[3] { 0, 0, 0 }, false);
            }

        }
        private Tuple<int[], bool> BottomCamera2Calc(string CameraD, string TargetD, double _x, double _y, double _u)
        {
            try
            {
                #region 读取PLC坐标
                int[] camerap = Fx5u.ReadMultiW(CameraD, 3);
                int[] targetp = Fx5u.ReadMultiW(TargetD, 3);
                #endregion
                #region 识别图像
                //找模板
                string path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\\Bottom2");
                HObject ModelImage;
                HOperatorSet.ReadImage(out ModelImage, Path.Combine(path, "ModelImage.bmp"));
                HTuple ModelID, row, column, angle, score, row1, column1, angle1, score1;
                HOperatorSet.ReadShapeModel(Path.Combine(path, "ShapeModel.shm"), out ModelID);
                HObject ImageRegion;
                HOperatorSet.ReadRegion(out ImageRegion, Path.Combine(path, "Region.hobj"));
                HObject ImageReduced;
                HOperatorSet.ReduceDomain(ModelImage, ImageRegion, out ImageReduced);
                HOperatorSet.FindShapeModel(ImageReduced, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row, out column, out angle, out score);
                HOperatorSet.ReduceDomain(bottomCamera2.CurrentImage, ImageRegion, out ImageReduced);
                HOperatorSet.FindShapeModel(ImageReduced, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row1, out column1, out angle1, out score1);
                HTuple homMat2D;
                HOperatorSet.VectorAngleToRigid(row, column, angle, row1, column1, angle1, out homMat2D);
                HObject modelRegion;
                HOperatorSet.ReadRegion(out modelRegion, Path.Combine(path, "ModelRegion.hobj"));
                HObject regionAffineTrans;
                HOperatorSet.AffineTransRegion(modelRegion, out regionAffineTrans, homMat2D, "nearest_neighbor");
                Tuple<string, object> t = new Tuple<string, object>("Color", "green");
                BottomCamera2GCStyle = t;
                BottomCamera2AppendHObject = null;
                BottomCamera2AppendHObject = regionAffineTrans;
                AddMessage("找到模板: Row:" + row1.D.ToString("F0") + " Column:" + column1.D.ToString("F0") + " Angle:" + angle1.TupleDeg().D.ToString("F2") + " Score:" + score1.D.ToString("F1"));

                //确认角度
                HObject lineRegion;
                HOperatorSet.ReadRegion(out lineRegion, Path.Combine(path, "Line.hobj"));
                HObject imageReduced1;
                HOperatorSet.ReduceDomain(ModelImage, lineRegion, out imageReduced1);
                HObject edges1;
                HOperatorSet.EdgesSubPix(imageReduced1, out edges1, "canny", 1, BottomCamera2Low, BottomCamera2Low + 20);
                HObject contoursSplit1;
                HOperatorSet.SegmentContoursXld(edges1, out contoursSplit1, "lines_circles", 5, 4, 2);
                HObject selectedContours1;
                HOperatorSet.SelectContoursXld(contoursSplit1, out selectedContours1, "contour_length", 15, 500, -0.5, 0.5);
                HObject unionContours1;
                HOperatorSet.UnionAdjacentContoursXld(selectedContours1, out unionContours1, 10, 1, "attr_keep");
                HTuple rowBegin1, colBegin1, rowEnd1, colEnd1, nr1, nc1, dist1;
                HOperatorSet.FitLineContourXld(unionContours1, "tukey", -1, 0, 5, 2, out rowBegin1, out colBegin1, out rowEnd1, out colEnd1, out nr1, out nc1, out dist1);
                HObject regionLine;
                HOperatorSet.GenRegionLine(out regionLine, rowBegin1, colBegin1, rowEnd1, colEnd1);
                var index = FindMaxLine(regionLine);
                double lineAngle1 = Math.Atan2((nc1.DArr[index]), (nr1.DArr[index])) * 180 / Math.PI - 90;

                HObject regionLineAffineTrans;
                HOperatorSet.AffineTransRegion(lineRegion, out regionLineAffineTrans, homMat2D, "nearest_neighbor");
                HOperatorSet.ReduceDomain(bottomCamera2.CurrentImage, regionLineAffineTrans, out imageReduced1);
                HOperatorSet.EdgesSubPix(imageReduced1, out edges1, "canny", 1, BottomCamera2Low, BottomCamera2Low + 20);
                HOperatorSet.SegmentContoursXld(edges1, out contoursSplit1, "lines_circles", 5, 4, 2);
                HOperatorSet.SelectContoursXld(contoursSplit1, out selectedContours1, "contour_length", 15, 500, -0.5, 0.5);
                HOperatorSet.UnionAdjacentContoursXld(selectedContours1, out unionContours1, 10, 1, "attr_keep");
                HOperatorSet.FitLineContourXld(unionContours1, "tukey", -1, 0, 5, 2, out rowBegin1, out colBegin1, out rowEnd1, out colEnd1, out nr1, out nc1, out dist1);
                HOperatorSet.GenRegionLine(out regionLine, rowBegin1, colBegin1, rowEnd1, colEnd1);
                BottomCamera2AppendHObject = regionLine;
                index = FindMaxLine(regionLine);
                double lineAngle2 = Math.Atan2((nc1.DArr[index]), (nr1.DArr[index])) * 180 / Math.PI - 90;




                //坐标变换
                HOperatorSet.ReadTuple(Path.Combine(path, "homMat2D.tup"), out homMat2D);
                HTuple CamImage_x, CamImage_y;
                HOperatorSet.AffineTransPoint2d(homMat2D, row, column, out CamImage_x, out CamImage_y);
                HTuple CamImage_x1, CamImage_y1;
                HOperatorSet.AffineTransPoint2d(homMat2D, row1, column1, out CamImage_x1, out CamImage_y1);
                HTuple T2;
                HOperatorSet.VectorAngleToRigid(CamImage_x1, CamImage_y1, new HTuple(lineAngle2 * -1).TupleRad(), CamImage_x, CamImage_y, new HTuple(lineAngle1 * -1).TupleRad(), out T2);//T2是新料移动到模板料位置的变换
                HTuple T1;
                HOperatorSet.VectorAngleToRigid((double)camerap[0] / 100, (double)camerap[1] / 100, new HTuple((double)camerap[2] / 100).TupleRad(), (double)targetp[0] / 100 + _x, (double)targetp[1] / 100 + _y, new HTuple((double)targetp[2] / 100 + _u).TupleRad(), out T1);//T1是拍照位置移动到贴合位置的变换
                HTuple CamRobot_x1, CamRobot_y1;
                HOperatorSet.AffineTransPoint2d(T2, (double)camerap[0] / 100, (double)camerap[1] / 100, out CamRobot_x1, out CamRobot_y1);//移动到新料与模板料重合
                HTuple FitRobot_x1, FitRobot_y1;
                HOperatorSet.AffineTransPoint2d(T1, CamRobot_x1, CamRobot_y1, out FitRobot_x1, out FitRobot_y1);//移动到贴合位置

                #endregion
                #region 范围
                bool result = true;
                if (FitRobot_x1.D * 100 - targetp[0] > 1000 || FitRobot_x1.D * 100 - targetp[0] < -1000)
                {
                    result = false;
                }
                else
                {
                    if (FitRobot_y1.D * 100 - targetp[1] > 1000 || FitRobot_y1.D * 100 - targetp[1] < -1000)
                    {
                        result = false;
                    }
                    else
                    {
                        if (lineAngle1 - lineAngle2 > 15 || lineAngle1 - lineAngle2 < -15)
                        {
                            result = false;
                        }
                    }
                }
                #endregion
                return new Tuple<int[], bool>(new int[3] { (int)(FitRobot_x1.D * 100 - targetp[0]), (int)(FitRobot_y1.D * 100 - targetp[1]), (int)(((lineAngle1 - lineAngle2) * -1 + _u) * 100) }, result);
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
                return new Tuple<int[], bool>(new int[3] { 0, 0, 0 }, false);
            }

        }
        void Fx5uConnectStateChanged(object sender, bool e)
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
        private double[] rotateCenter(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double a, b, c, d, e, f;
            a = 2 * (x2 - x1);
            b = 2 * (y2 - y1);
            c = x2 * x2 + y2 * y2 - x1 * x1 - y1 * y1;
            d = 2 * (x3 - x2);
            e = 2 * (y3 - y2);
            f = x3 * x3 + y3 * y3 - x2 * x2 - y2 * y2;

            double x = (b * f - e * c) / (b * d - e * a);
            double y = (d * c - a * f) / (b * d - e * a);
            double[] xy = new double[2];
            xy[0] = x;
            xy[1] = y;
            return xy;
        }
        private void WriteToJson(object p, string path)
        {
            try
            {
                using (FileStream fs = File.Open(path, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fs))
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jw, p);
                }
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }
        }
        private int FindMaxLine(HObject LineRegion)
        {
            HTuple area, row, column;
            HOperatorSet.AreaCenter(LineRegion, out area, out row, out column);
            HTuple max;
            HOperatorSet.TupleMax(area, out max);

            for (int i = 0; i < area.LArr.Length; i++)
            {
                if (area.LArr[i] == max)
                {
                    return i;
                }
            }
            return 0;
        }
        private string GetBanci()
        {
            string rs = "";
            if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
            {
                rs += DateTime.Now.ToString("yyyyMMdd") + "_D";
            }
            else
            {
                if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 8)
                {
                    rs += DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "_N";
                }
                else
                {
                    rs += DateTime.Now.ToString("yyyyMMdd") + "_N";
                }
            }
            return rs;
        }
        #endregion
    }
}
