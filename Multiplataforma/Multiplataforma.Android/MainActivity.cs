using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.IO;
using Android.Content;
using Android.Provider;
using Android.Graphics;

namespace Multiplataforma.Droid
{
    [Activity(Label = "Multiplataforma", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            App.Instance.ShouldTakePicture += () =>
            {
                var intent = new Intent(MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 200);
            };
        }

        

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode != Result.Ok) return;
            if (requestCode != 200) return;
            base.OnActivityResult(requestCode, resultCode, data);
            var extras = data.Extras;
            foreach (var item in extras.KeySet())
            {
                Console.WriteLine(item);
            }
            var extra = data.Extras.GetByteArray("data");
            App.Instance.ShowImage(extra);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}