using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFaceAPI.Model;

namespace XamarinFaceAPI.Service
{
    interface IService
    {
       Task GetAttributes(string url);
       //FaceAttributeModel SendData();
    }
}
