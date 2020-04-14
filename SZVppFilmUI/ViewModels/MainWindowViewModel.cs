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
        }
        private void TopCameraFunctionCommandExecute()
        {

            topCamera.GrabImage();
            TopCameraIamge = topCamera.CurrentImage;

        }
        private void BottonCamera1FunctionCommandExecute()
        {

            bottomCamera1.GrabImage();
            BottomCamera1Iamge = bottomCamera1.CurrentImage;

        }
        private void BottonCamera2FunctionCommandExecute()
        {

            bottomCamera2.GrabImage();
            BottomCamera2Iamge = bottomCamera2.CurrentImage;

        }
        #endregion
        #region 自定义函数
        private void Init()
        {
            MessageStr = "";
            WindowTitle = "SZVppFilmUI20200414";
            TopCameraName = "cam1";
            BottomCamera1Name = "cam2";
            BottomCamera2Name = "cam3";
            if (topCamera.OpenCamera(TopCameraName, "GigEVision"))
            {
                AddMessage("TopCamera Open Success!");
            }
            else
            {
                AddMessage("TopCamera Open Fail!");
            }
            if (bottomCamera1.OpenCamera(BottomCamera1Name, "GigEVision"))
            {
                AddMessage("BottomCamera1 Open Success!");
            }
            else
            {
                AddMessage("BottomCamera1 Open Fail!");
            }
            if (bottomCamera2.OpenCamera(BottomCamera2Name, "GigEVision"))
            {
                AddMessage("BottomCamera2 Open Success!");
            }
            else
            {
                AddMessage("BottomCamera2 Open Fail!");
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
            while (true)
            {
                await Task.Delay(200);
                #region UI更新
                StatusTop = topCamera.Connected;
                StatusBottom1 = bottomCamera1.Connected;
                StatusBottom2 = bottomCamera2.Connected;
                #endregion
            }
        }
        #endregion
    }
}
