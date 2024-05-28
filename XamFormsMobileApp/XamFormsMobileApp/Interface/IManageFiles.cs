using System;
using System.Collections.Generic;
using System.Text;

namespace XamFormsMobileApp.Interface
{
  public  interface IManageFiles
    {
        bool SaveImage(string filename, byte[] imageData);

        byte[] GetImage(string imageName);
    }
}
