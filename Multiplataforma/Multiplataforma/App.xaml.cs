using Multiplataforma.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Multiplataforma
{
    public partial class App : Application
    {
        public static MyCameraView Instance;
        public MyCameraView myCameraView;

        
        public App()
        {
            myCameraView = new MyCameraView();
            Instance = myCameraView;
            InitializeComponent();
            MainPage = new LeadCreateView();


        }

        public void ShowImage(byte[] array)
        {
            myCameraView.ShowImage(array);
        }

        


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}
