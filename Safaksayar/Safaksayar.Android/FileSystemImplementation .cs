using System;
using System.Collections.Generic;
using System.IO;
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
   public class FileSystemImplementation:IFileSystem
    {
        public string GetExternalStorage()
        {
            Context context = Android.App.Application.Context;
            var filePath = context.GetExternalFilesDir("");
            return filePath.Path;
        }
        public string GetExternalStorage2()
        {
            string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString());
            return dbPath;
        }
    

    }
}