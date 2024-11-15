using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;
using Firebase.Messaging;

namespace Interstay_Concierge_Xamarin.Droid
{
    [Activity(Label = "Interstay_Concierge_Xamarin", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            CreateNotificationChannel();

            IsPlayServicesAvailable();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            FirebaseMessaging.Instance.SubscribeToTopic("1_15");
            FirebaseMessaging.Instance.SubscribeToTopic("1_16");
            FirebaseMessaging.Instance.SubscribeToTopic("1_17");
            FirebaseMessaging.Instance.SubscribeToTopic("1_18");
            FirebaseMessaging.Instance.SubscribeToTopic("1_19");
            FirebaseMessaging.Instance.SubscribeToTopic("1_20");

            LoadApplication(new App());

            /*
            var logTokenButton = FindViewById<Button>(Resource.Id.logTokenButton);
            logTokenButton.Click += delegate { Log.Debug(TAG, "InstanceID token: " + FirebaseInstanceId.Instance.Token); };

            var subscribeButton = FindViewById<Button>(Resource.Id.subscribeButton);
            subscribeButton.Click += delegate
            {
                FirebaseMessaging.Instance.SubscribeToTopic("1_15");
                FirebaseMessaging.Instance.SubscribeToTopic("1_16");
                FirebaseMessaging.Instance.SubscribeToTopic("1_17");
                FirebaseMessaging.Instance.SubscribeToTopic("1_18");
                FirebaseMessaging.Instance.SubscribeToTopic("1_19");
                FirebaseMessaging.Instance.SubscribeToTopic("1_20");
                Log.Debug(TAG, "Subscribed to remote notifications");
            };
            */
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public bool IsPlayServicesAvailable()
        {
            var resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    //msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                }
                else
                {
                    //msgText.Text = "This device is not supported";
                    Finish();
                }

                return false;
            }

            //msgText.Text = "Google Play Services is available.";
            return true;
        }


        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification 
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID, "FCM Notifications", NotificationImportance.Default)
            {
                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
    }
}