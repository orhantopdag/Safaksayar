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
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    public class BootReceiver : BroadcastReceiver
    {

        //the interval currently every one minute
        //to set it to dayly change the value to 24 * 60 * 60 * 1000
        public static long reminderInterval = 24 * 60 * 60 * 1000;
        public static long FirstReminder()
        {
            Java.Util.Calendar calendar = Java.Util.Calendar.Instance;
            calendar.Set(Java.Util.CalendarField.HourOfDay, 23);
            calendar.Set(Java.Util.CalendarField.Minute, 30);
            calendar.Set(Java.Util.CalendarField.Second, 00);
            return calendar.TimeInMillis;
        }
        public override void OnReceive(Context context, Intent intent)
        {
            Console.WriteLine("BootReceiver: OnReceive");
            var alarmIntent = new Intent(context, typeof(AlarmReceiver));
            var pending = PendingIntent.GetBroadcast(context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);

            alarmManager.SetRepeating(AlarmType.RtcWakeup, FirstReminder(), reminderInterval, pending);
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, 0, alarmIntent, 0);
        }
    }
}