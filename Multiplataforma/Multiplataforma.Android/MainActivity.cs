using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.IO;
using Android.Content;
using Android.Provider;
using Android.Graphics;
using AndroidX.Core.App;
using Android;
using Google.Android.Material.Snackbar;

namespace Multiplataforma.Droid
{
    [Activity(Label = "Multiplataforma", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        Android.Net.Uri mPhotoUri;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            var requiredPermissions = new String[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.Camera, Manifest.Permission.WriteExternalStorage };
            ActivityCompat.RequestPermissions(this, requiredPermissions, 200);


            App.Instance.ShouldTakePicture += () =>
            {
                Intent takePicture = new Intent(MediaStore.ActionImageCapture);
                mPhotoUri = ContentResolver.Insert(MediaStore.Images.Media.ExternalContentUri, new ContentValues());
                takePicture.PutExtra(MediaStore.ExtraOutput, mPhotoUri);
                StartActivityForResult(takePicture, 200);
            };
        }

        

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode != Result.Ok) return;
            if (requestCode != 200) return;
            base.OnActivityResult(requestCode, resultCode, data);
            var extras = data.Extras;
            if(extras == null)
            {
                Bitmap bitmap = MediaStore.Images.Media.GetBitmap(ContentResolver, mPhotoUri);
                MemoryStream stream = new MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                byte[] bitmapData = stream.ToArray();
                App.Instance.ShowImage(bitmapData);
            }
            else
            {
                var extra = extras.GetByteArray("data");
                App.Instance.ShowImage(extra);
            }

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}