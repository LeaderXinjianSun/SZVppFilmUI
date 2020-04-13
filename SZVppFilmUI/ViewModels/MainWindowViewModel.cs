using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingLibrary.hjb.Metro;

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

        #endregion
        #region 方法绑定
        public DelegateCommand AppLoadedEventCommand { get; set; }
        #endregion
        #region 变量
        Metro metro = new Metro();
        #endregion
        #region 构造函数
        public MainWindowViewModel()
        {
            this.AppLoadedEventCommand = new DelegateCommand(new Action(this.AppLoadedEventCommandExecute));
        }
        #endregion
        #region 方法绑定函数
        private void AppLoadedEventCommandExecute()
        {
            Init();
        }
        #endregion
        #region 自定义函数
        private async void Init()
        {
            WindowTitle = "SZVppFilmUI20200414";
            await metro.ShowConfirm("确认","欢饮登录软件");
        }
        #endregion
    }
}
