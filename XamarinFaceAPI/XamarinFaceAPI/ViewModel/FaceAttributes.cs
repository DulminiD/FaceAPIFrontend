using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFaceAPI.Service;

namespace XamarinFaceAPI.ViewModel
{
    class FaceAttributes : INotifyPropertyChanged
    {
        private string _url;
        private List<object> _listOfItems;
        public event PropertyChangedEventHandler PropertyChanged;

        #region Constructor
        public FaceAttributes()
        {
            ButtonClicked = new Command(
            execute: () =>
            {
                getData();
            });
        }
        #endregion

        #region Binding Data
        public ICommand ButtonClicked
        {
            get;
            private set;
        }
        public string URL
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                OnPropertyChanged();
            }
        }
        public List<object> ListOfItems
        {
            get
            {
                return _listOfItems;
            }
            set
            {
                _listOfItems = value;
                OnPropertyChanged();

            }
        }
        #endregion

        #region Set Data
        public void getData()
        {
            ServiceImpl serviceImpl = new ServiceImpl();
            serviceImpl.GetAttributes(URL);
            object vs = serviceImpl.SendData();   
            var enu = vs as IEnumerable;
            var listobj = enu.Cast<object>().ToList();
            ListOfItems = listobj;
            
        }
        #endregion

        #region OnPropertyChanged
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
