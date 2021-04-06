using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace X_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public Button Btn_Ok { get; set; }
        public Button Btn_Google { get; set; }
        public Button Btn_Picture { get; set; }
        public EditText Edt_Input { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Edt_Input = FindViewById<EditText>(Resource.Id.activity_main_Edt_Input);
            Btn_Ok = FindViewById<Button>(Resource.Id.activity_main_Btn_Ok);
            Btn_Google = FindViewById<Button>(Resource.Id.activity_main_Btn_Google);
            Btn_Picture = FindViewById<Button>(Resource.Id.activity_main_Btn_Picture);

            //Btn_Ok.Click += ShowNumber;
            Btn_Ok.Click += (s,e) => Toast.MakeText(this, $"Ihre gewählte Zahl ist {Edt_Input.Text}.", ToastLength.Long).Show();
            Edt_Input.Click += (s, e) => Toast.MakeText(this, $"Ihre gewählte Zahl ist {Edt_Input.Text}.", ToastLength.Long).Show();

            Intent impliziterIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://www.google.de"));
            Btn_Google.Click += (s, e) => StartActivity(impliziterIntent);

            Intent explizieterIntent = new Intent(this, typeof(ShowPictureActivity));
            Btn_Picture.Click += (s, e) => StartActivity(explizieterIntent);
        }

        private void ShowNumber (object sender, System.EventArgs e)
        {
            Toast.MakeText(this, $"Ihre gewählte Zahl ist {Edt_Input.Text}.", ToastLength.Long).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}