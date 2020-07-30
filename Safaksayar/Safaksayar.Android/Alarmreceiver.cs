using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Safaksayar.Droid
{
    [BroadcastReceiver]
    public class AlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var title = "Hello world!";
            var message = "Checkout this notification";

            Intent backIntent = new Intent(context, typeof(MainActivity));
            backIntent.SetFlags(ActivityFlags.NewTask);

            //The activity opened when we click the notification is SecondActivity
            //Feel free to change it to you own activity
            var resultIntent = new Intent(context, typeof(MainActivity));

            PendingIntent pending = PendingIntent.GetActivities(context, 0,
                new Intent[] { backIntent, resultIntent },
                PendingIntentFlags.OneShot);

            var builder =
                new Notification.Builder(context)
                    .SetContentTitle(title)
                    .SetContentText(message)
                    .SetAutoCancel(true)
                    .SetSmallIcon(Resource.Drawable.Icon)
                    .SetDefaults(NotificationDefaults.All);

            builder.SetContentIntent(pending);
            var notification = builder.Build();
            var manager = NotificationManager.FromContext(context);
            manager.Notify(1331, notification);

        }
    }
}