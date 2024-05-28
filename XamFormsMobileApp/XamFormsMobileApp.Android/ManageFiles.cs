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
using Xamarin.Forms;
using XamFormsMobileApp.Droid;
using XamFormsMobileApp.Interface;

[assembly: Dependency(typeof(ManageFiles))]

namespace XamFormsMobileApp.Droid
{
   public class ManageFiles:IManageFiles
    {
        public bool SaveImage(string filename, byte[] imageData)
        {
            try
            {
                CreateFolder();
                var dir = new Java.IO.File
                    (Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Pictures/MobileAppBackgroundImages");
                string filePath = System.IO.Path.Combine(dir.Path, filename);
                File.WriteAllBytes(filePath, imageData);
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }

        public byte[] GetImage(string imageName)
        {
            var sdCardpath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;

           // var sdCardpath = GetSdCardPath();
            var externalImagePath = System.IO.Path.Combine(sdCardpath + "/Pictures/MobileAppBackgroundImages", imageName);
            if (System.IO.File.Exists(externalImagePath))
            {
                byte[] data = File.ReadAllBytes(externalImagePath);
                return data;
            }
            else
            {
                return new byte[1];
            }
        }

        private void CreateFolder()
        {
            var dir = new Java.IO.File
                (Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Pictures/MobileAppBackgroundImages");
            if (!dir.Exists())
                dir.Mkdirs();
        }

    }
}