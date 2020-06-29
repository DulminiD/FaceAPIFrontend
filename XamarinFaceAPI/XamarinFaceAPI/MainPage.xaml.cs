using Xamarin.Forms;
using XamarinFaceAPI.Service;
using XamarinFaceAPI.ViewModel;

namespace XamarinFaceAPI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new FaceAttributes();
            
        }
    }
}
