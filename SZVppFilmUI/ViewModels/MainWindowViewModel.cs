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

        public Tuple<string, object>  TopCameraGCStyle
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
        private double bottomCamera1Diff1_X;

        public double BottomCamera1Diff1_X
        {
            get { return bottomCamera1Diff1_X; }
            set
            {
                bottomCamera1Diff1_X = value;
                this.RaisePropertyChanged("BottomCamera1Diff1_X");
            }
        }
        private double bottomCamera1Diff1_Y;

        public double BottomCamera1Diff1_Y
        {
            get { return bottomCamera1Diff1_Y; }
            set
            {
                bottomCamera1Diff1_Y = value;
                this.RaisePropertyChanged("BottomCamera1Diff1_Y");
            }
        }
        private double bottomCamera1Diff1_U;

        public double BottomCamera1Diff1_U
        {
            get { return bottomCamera1Diff1_U; }
            set
            {
                bottomCamera1Diff1_U = value;
                this.RaisePropertyChanged("BottomCamera1Diff1_U");
            }
        }
        private double bottomCamera2Diff1_X;

        public double BottomCamera2Diff1_X
        {
            get { return bottomCamera2Diff1_X; }
            set
            {
                bottomCamera2Diff1_X = value;
                this.RaisePropertyChanged("BottomCamera2Diff1_X");
            }
        }
        private double bottomCamera2Diff1_Y;

        public double BottomCamera2Diff1_Y
        {
            get { return bottomCamera2Diff1_Y; }
            set
            {
                bottomCamera2Diff1_Y = value;
                this.RaisePropertyChanged("BottomCamera2Diff1_Y");
            }
        }
        private double bottomCamera2Diff1_U;

        public double BottomCamera2Diff1_U
        {
            get { return bottomCamera2Diff1_U; }
            set
            {
                bottomCamera2Diff1_U = value;
                this.RaisePropertyChanged("BottomCamera2Diff1_U");
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
        public DelegateCommand<object> FindShapeModelOperateCommand { get; set; }
        public DelegateCommand<object> ClibOperateCommand { get; set; }
        public DelegateCommand CreateShapeModel2 { get; set; }
        public DelegateCommand FindShapeModel2 { get; set; }
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
            FindShapeModelOperateCommand = new DelegateCommand<object>(new Action<object>(this.FindShapeModelOperateCommandExecute));
            ClibOperateCommand = new DelegateCommand<object>(new Action<object>(this.ClibOperateCommandExecute));
            CreateShapeModel2 = new DelegateCommand(new Action(this.CreateShapeModel2Execute));
            FindShapeModel2 = new DelegateCommand(new Action(this.FindShapeModel2Execute));
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
                //int[] camerap = Fx5u.ReadMultiW("D4128", 3);
                //int[] senddata = new int[3] { camerap[0] + -5 * 100, camerap[1] + 5 * 100, camerap[2] + 30 * 100 };
                //Fx5u.WriteMultW("D3200", senddata);
                var rst = TopCameraCalc("D4116", TopCameraDiff1_X, TopCameraDiff1_Y, TopCameraDiff1_U);
                if (rst.Item2)
                {
                    AddMessage(rst.Item1[0].ToString() + "," + rst.Item1[1].ToString() + "," + rst.Item1[2].ToString());
                }
                else
                {
                    AddMessage("失败");
                }
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
                        path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top");
                        imageViewer = Global.TopCameraImageViewer;
                        rOIList = TopCameraROIList;
                        camera = topCamera;
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
                HOperatorSet.CreateShapeModel(ReduceDomainImage, 7, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), (new HTuple(0.1)).TupleRad(), "no_pregeneration", "use_polarity", 30, 10, out ModelID);
                HOperatorSet.WriteShapeModel(ModelID, Path.Combine(path, "ShapeModel.shm"));
                camera.SaveImage("bmp", Path.Combine(path, "ModelImage.bmp"));
                AddMessage("创建模板完成");
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }
            
            
        }
        private void CreateShapeModel2Execute()
        {
            try
            {
                string path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top");
                ROI roi = Global.TopCameraImageViewer.DrawROI(ROI.ROI_TYPE_REGION);
                HObject ReduceDomainImage;
                HOperatorSet.ReduceDomain(topCamera.CurrentImage, roi.getRegion(), out ReduceDomainImage);
                HObject modelImages, modelRegions;
                HOperatorSet.InspectShapeModel(ReduceDomainImage, out modelImages, out modelRegions, 7, 30);

                HObject objectSelected;
                HOperatorSet.SelectObj(modelRegions, out objectSelected, 1);
                HOperatorSet.WriteRegion(objectSelected, Path.Combine(path, "ModelRegion2.hobj"));
                Tuple<string, object> t = new Tuple<string, object>("Color", "green");
                TopCameraGCStyle = t;
                TopCameraAppendHObject = null;
                TopCameraAppendHObject = objectSelected;
                HTuple ModelID;
                HOperatorSet.CreateShapeModel(ReduceDomainImage, 7, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), (new HTuple(0.1)).TupleRad(), "no_pregeneration", "use_polarity", 30, 10, out ModelID);
                HOperatorSet.WriteShapeModel(ModelID, Path.Combine(path, "ShapeModel2.shm"));
                topCamera.SaveImage("bmp", Path.Combine(path, "ModelImage2.bmp"));
                AddMessage("创建模板2完成");
            }
            catch (Exception ex)
            {

                AddMessage(ex.Message);
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
                        path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top");
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
                    path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top");
                    imageViewer = Global.TopCameraImageViewer;
                    rOIList = TopCameraROIList;
                    camera = topCamera;
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
                int[][] diff_r = new int[3][] {
                    new int[] { 0,0,0},
                    new int[] { 0,0,5},
                    new int[] { 0,0,-5}
                };
                string MoveStart = "M3210";
                string MoveFinish = "M3110";
                string MoveData = "D3200";
                string CameraP = "D4128";
                string CameraRP = "D4280";
                switch (Station)
                {
                    case "A":
                        MoveStart = "M3210";
                        MoveFinish = "M3110";
                        MoveData = "D3200";
                        switch (p.ToString())
                        {
                            case "1":
                                CameraP = "D4134";
                                CameraRP = "D4134";
                                break;
                            case "2":
                                CameraP = "D4134";
                                CameraRP = "D4134";
                                break;
                            default:
                                CameraP = "D4128";
                                CameraRP = "D4280";
                                break;
                        }
                        break;

                    default:
                        break;
                }
                
                //9点标定拍照
                int[] camerap = Fx5u.ReadMultiW(CameraP, 3);
                //for (int i = 0; i < 9; i++)
                //{
                //    int[] senddata = new int[3] { camerap[0] + diff[i][0] * 100, camerap[1] + diff[i][1] * 100, camerap[2] + diff[i][2] * 100 };
                //    Fx5u.WriteMultW(MoveData, senddata);
                //    Fx5u.SetM(MoveFinish, false);
                //    Fx5u.SetM(MoveStart, true);
                //    AddMessage("运动到位，按启动开始拍照");
                //    while (true)
                //    {
                //        try
                //        {
                //            if (Fx5u.ReadM(MoveFinish) && Fx5u.ReadM("M120"))
                //                break;
                //        }
                //        catch { }
                //        System.Threading.Thread.Sleep(100);
                //    }
                //    camera.GrabImageVoid();
                //    switch (p.ToString())
                //    {
                //        case "1":
                //            BottomCamera1Iamge = camera.CurrentImage;
                //            break;

                //        case "2":
                //            BottomCamera2Iamge = camera.CurrentImage;
                //            break;
                //        default:
                //            TopCameraIamge = camera.CurrentImage;
                //            break;
                //    }
                //    if (!Directory.Exists(Path.Combine(path, "Calib")))
                //    {
                //        Directory.CreateDirectory(Path.Combine(path, "Calib"));
                //    }
                //    camera.SaveImage("bmp", Path.Combine(path, "Calib", (i + 1).ToString() + ".bmp"));


                //}
                double[][] Array1 = new double[9][];
                for (int i = 0; i < 9; i++)
                {
                    try
                    {
                        HObject img;
                        HOperatorSet.ReadImage(out img, Path.Combine(path, "Calib", (i + 1).ToString() + ".bmp"));
                        HTuple ModelID, row, column, angle, score;
                        HOperatorSet.ReadShapeModel(Path.Combine(path, "ShapeModel.shm"), out ModelID);
                        HOperatorSet.FindShapeModel(img, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row, out column, out angle, out score);
                        Array1[i] = new double[4] { row.D, column.D, camerap[0] - diff[i][0] * 100, camerap[1] - diff[i][1] * 100 };
                    }
                    catch (Exception ex)
                    {
                        Array1[i] = new double[4] { 0, 0, camerap[0] - diff[i][0] * 100, camerap[1] - diff[i][1] * 100 };
                        AddMessage(ex.Message);
                    }
                }
                HTuple homMat2D;
                HOperatorSet.VectorToHomMat2d(new HTuple(Array1[0][0]).TupleConcat(Array1[1][0]).TupleConcat(Array1[2][0]).TupleConcat(Array1[3][0]).TupleConcat(Array1[4][0]).TupleConcat(Array1[5][0]).TupleConcat(Array1[6][0]).TupleConcat(Array1[7][0]).TupleConcat(Array1[8][0]),
                    new HTuple(Array1[0][1]).TupleConcat(Array1[1][1]).TupleConcat(Array1[2][1]).TupleConcat(Array1[3][1]).TupleConcat(Array1[4][1]).TupleConcat(Array1[5][1]).TupleConcat(Array1[6][1]).TupleConcat(Array1[7][1]).TupleConcat(Array1[8][1]),
                    new HTuple(Array1[0][2]).TupleConcat(Array1[1][2]).TupleConcat(Array1[2][2]).TupleConcat(Array1[3][2]).TupleConcat(Array1[4][2]).TupleConcat(Array1[5][2]).TupleConcat(Array1[6][2]).TupleConcat(Array1[7][2]).TupleConcat(Array1[8][2]),
                    new HTuple(Array1[0][3]).TupleConcat(Array1[1][3]).TupleConcat(Array1[2][3]).TupleConcat(Array1[3][3]).TupleConcat(Array1[4][3]).TupleConcat(Array1[5][3]).TupleConcat(Array1[6][3]).TupleConcat(Array1[7][3]).TupleConcat(Array1[8][3])
                    , out homMat2D);
                //旋转标定拍照
                //camerap = Fx5u.ReadMultiW(CameraRP, 3);
                //for (int i = 0; i < 3; i++)
                //{
                //    int[] senddata = new int[3] { camerap[0] + diff_r[i][0] * 100, camerap[1] + diff_r[i][1] * 100, camerap[2] + diff_r[i][2] * 100 };
                //    Fx5u.WriteMultW(MoveData, senddata);
                //    Fx5u.SetM(MoveFinish, false);
                //    Fx5u.SetM(MoveStart, true);
                //    AddMessage("运动到位，按启动开始拍照");
                //    while (true)
                //    {
                //        try
                //        {
                //            if (Fx5u.ReadM(MoveFinish) && Fx5u.ReadM("M120"))
                //                break;
                //        }
                //        catch { }
                //        System.Threading.Thread.Sleep(100);
                //    }
                //    camera.GrabImageVoid();
                //    switch (p.ToString())
                //    {
                //        case "1":
                //            BottomCamera1Iamge = camera.CurrentImage;
                //            break;

                //        case "2":
                //            BottomCamera2Iamge = camera.CurrentImage;
                //            break;
                //        default:
                //            TopCameraIamge = camera.CurrentImage;
                //            break;
                //    }
                //    if (!Directory.Exists(Path.Combine(path, "Calib")))
                //    {
                //        Directory.CreateDirectory(Path.Combine(path, "Calib"));
                //    }
                //    camera.SaveImage("bmp", Path.Combine(path, "Calib", (i + 1 + 9).ToString() + ".bmp"));
                //}
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
                HTuple qx0, qy0;
                HOperatorSet.AffineTransPoint2d(homMat2D, circleCenter[0], circleCenter[1], out qx0, out qy0);
                double delta_x = camerap[0] - qx0;
                double delta_y = camerap[1] - qy0;
                AddMessage(delta_x.ToString() + " , " + delta_y.ToString());
                HOperatorSet.VectorToHomMat2d(new HTuple(Array1[0][0]).TupleConcat(Array1[1][0]).TupleConcat(Array1[2][0]).TupleConcat(Array1[3][0]).TupleConcat(Array1[4][0]).TupleConcat(Array1[5][0]).TupleConcat(Array1[6][0]).TupleConcat(Array1[7][0]).TupleConcat(Array1[8][0]),
                    new HTuple(Array1[0][1]).TupleConcat(Array1[1][1]).TupleConcat(Array1[2][1]).TupleConcat(Array1[3][1]).TupleConcat(Array1[4][1]).TupleConcat(Array1[5][1]).TupleConcat(Array1[6][1]).TupleConcat(Array1[7][1]).TupleConcat(Array1[8][1]),
                    new HTuple(Array1[0][2] + delta_x).TupleConcat(Array1[1][2] + delta_x).TupleConcat(Array1[2][2] + delta_x).TupleConcat(Array1[3][2] + delta_x).TupleConcat(Array1[4][2] + delta_x).TupleConcat(Array1[5][2] + delta_x).TupleConcat(Array1[6][2] + delta_x).TupleConcat(Array1[7][2] + delta_x).TupleConcat(Array1[8][2] + delta_x),
                    new HTuple(Array1[0][3] + delta_y).TupleConcat(Array1[1][3] + delta_y).TupleConcat(Array1[2][3] + delta_y).TupleConcat(Array1[3][3] + delta_y).TupleConcat(Array1[4][3] + delta_y).TupleConcat(Array1[5][3] + delta_y).TupleConcat(Array1[6][3] + delta_y).TupleConcat(Array1[7][3] + delta_y).TupleConcat(Array1[8][3] + delta_y)
                    , out homMat2D);
                HOperatorSet.WriteTuple(homMat2D, Path.Combine(path, "homMat2D.tup"));
                AddMessage("保存标定文件成功");
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
            ClibButtonIsEnabled = true;
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
                                        //var calcrst = TopCameraCalc("D4116", TopCameraDiff1_X, TopCameraDiff1_Y, TopCameraDiff1_U);
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
        private Tuple<int[], bool> TopCameraCalc(string TargetD, double _x, double _y, double _u)
        {
            try
            {
                #region 读取PLC坐标
                int[] camerap = Fx5u.ReadMultiW("D4128", 3);
                int[] targetp = Fx5u.ReadMultiW(TargetD, 3);
                #endregion
                #region 识别图像
                //找模板
                string path = Path.Combine(System.Environment.CurrentDirectory, @"Camera\Top");
                HObject ModelImage;
                HOperatorSet.ReadImage(out ModelImage, Path.Combine(path, "ModelImage.bmp"));
                HTuple ModelID, row, column, angle, score, row1, column1, angle1, score1;
                HOperatorSet.ReadShapeModel(Path.Combine(path, "ShapeModel.shm"), out ModelID);
                HObject ImageRegion;
                HOperatorSet.ReadRegion(out ImageRegion, Path.Combine(path, "Region.hobj"));
                HObject ImageReduced;
                HOperatorSet.ReduceDomain(ModelImage, ImageRegion,out ImageReduced);
                HOperatorSet.FindShapeModel(ImageReduced, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row, out column, out angle, out score);
                HOperatorSet.ReduceDomain(topCamera.CurrentImage, ImageRegion, out ImageReduced);
                HOperatorSet.FindShapeModel(ImageReduced, ModelID, (new HTuple(-45)).TupleRad(), (new HTuple(90)).TupleRad(), 0.5, 1, 0, "least_squares", 0, 0.9, out row1, out column1, out angle1, out score1);
                HTuple homMat2D;
                HOperatorSet.VectorAngleToRigid(row, column, angle, row1, column1, angle1, out homMat2D);
                HObject modelRegion;
                HOperatorSet.ReadRegion(out modelRegion, Path.Combine(path, "ModelRegion.hobj"));
                HObject regionAffineTrans;
                HOperatorSet.AffineTransRegion(modelRegion, out regionAffineTrans, homMat2D, "nearest_neighbor");
                Tuple<string, object> t = new Tuple<string, object>("Color", "green");
                TopCameraGCStyle = t;
                TopCameraAppendHObject = null;
                TopCameraAppendHObject = regionAffineTrans;
                AddMessage("找到模板: Row:" + row1.D.ToString("F0") + " Column:" + column1.D.ToString("F0") + " Angle:" + angle1.TupleDeg().D.ToString("F2") + " Score:" + score1.D.ToString("F1"));
                //坐标变换
                HOperatorSet.ReadTuple(Path.Combine(path, "homMat2D.tup"), out homMat2D);
                HTuple CamImage_x, CamImage_y;
                HOperatorSet.AffineTransPoint2d(homMat2D, row, column, out CamImage_x, out CamImage_y);
                HTuple CamImage_x1, CamImage_y1;
                HOperatorSet.AffineTransPoint2d(homMat2D, row1, column1, out CamImage_x1, out CamImage_y1);
                HTuple T2;
                HOperatorSet.VectorAngleToRigid(CamImage_x1, CamImage_y1, angle1, CamImage_x, CamImage_y, angle, out T2);//T2是新料移动到模板料位置的变换
                HTuple T1;
                HOperatorSet.VectorAngleToRigid(camerap[0], camerap[1], new HTuple(targetp[2]).TupleRad(), targetp[0] + _x * 100, targetp[1] + _y * 100, new HTuple(targetp[2] + _u * 100).TupleRad(), out T1);//T1是拍照位置移动到贴合位置的变换
                HTuple CamRobot_x1, CamRobot_y1;
                HOperatorSet.AffineTransPoint2d(T2, camerap[0], camerap[1], out CamRobot_x1, out CamRobot_y1);//移动到新料与模板料重合
                HTuple FitRobot_x1, FitRobot_y1;
                HOperatorSet.AffineTransPoint2d(T1, CamRobot_x1, CamRobot_y1, out FitRobot_x1, out FitRobot_y1);//移动到贴合位置

                #endregion
                return new Tuple<int[], bool> ( new int[3] { (int)(FitRobot_x1.D - targetp[0]), (int)(FitRobot_y1.D - targetp[1]), (int)((angle - angle1).TupleDeg().D * 100) } ,true);
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
                return new Tuple<int[], bool>(new int[3] { 0, 0, 0 }, false);
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
        #endregion
        //private void WriteToJson()
        //{
        //    try
        //    {
        //        using (FileStream fs = File.Open(Path.Combine(System.Environment.CurrentDirectory, "Partnum.json"), FileMode.Create))
        //        using (StreamWriter sw = new StreamWriter(fs))
        //        using (JsonWriter jw = new JsonTextWriter(sw))
        //        {
        //            jw.Formatting = Formatting.Indented;
        //            JsonSerializer serializer = new JsonSerializer();
        //            serializer.Serialize(jw, PARTNUMItems);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AddMessage(ex.Message);
        //    }
        //}
        //                    try
        //            {
        //                using (StreamReader reader = new StreamReader(Path.Combine(System.Environment.CurrentDirectory, "Partnum.json")))
        //                {
        //                    string json = reader.ReadToEnd();
        //        PARTNUMItems = JsonConvert.DeserializeObject<ObservableCollection<string>>(json);
        //                }
        //}
        //            catch (Exception ex)
        //            {
        //                PARTNUMItems = new ObservableCollection<string>();
        //                AddMessage(ex.Message);
        //            }
    }
}
