using System;
using System.Collections.Generic;
using System.Globalization;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;

using Firebase.Messaging;

namespace Interstay_Concierge_Xamarin.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";

        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(TAG, "From: " + message.From);

            var body = message.GetNotification().Body;
            var title = message.GetNotification().Title;
            var time = System.DateTime.Now.ToString("tt", CultureInfo.InvariantCulture) + " " + System.DateTime.Now.ToString("HH:mm");
            
            Log.Debug(TAG, "Notification Message Body: " + body);
            SendNotification(title+"("+time+")", body, message.Data);
        }

        void SendNotification(string title, string messageBody, IDictionary<string, string> data)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            foreach (var key in data.Keys)
            {
                intent.PutExtra(key, data[key]);
            }

            var pendingIntent = PendingIntent.GetActivity(this, MainActivity.NOTIFICATION_ID, intent, PendingIntentFlags.OneShot);

            var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID)
                                      .SetSmallIcon(Resource.Drawable.ic_stat_ic_notification)
                                      .SetContentTitle(title)
                                      .SetContentText(messageBody)
                                      .SetAutoCancel(true)
                                      .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(MainActivity.NOTIFICATION_ID, notificationBuilder.Build());
        }


    }
}
