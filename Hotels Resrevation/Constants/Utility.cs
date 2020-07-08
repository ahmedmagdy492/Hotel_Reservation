using Hotels_Resrevation.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hotels_Resrevation.Constants
{
    public static class Utility
    {
        public static string SaveImage(HttpPostedFileBase img, HttpContextBase HttpContext)
        {
            string path = HttpContext.Server.MapPath("~/Content/imgs/");
            string fileName = Guid.NewGuid() + img.FileName;
            string fullPath = Path.Combine(path, fileName);
            img.SaveAs(fullPath);
            return fullPath;
        }

        public static bool IsEqualtoListItem(SelectList list, string filter)
        {
            bool isEqual = false;
            foreach (var option in list)
            {
                if (filter == option.Text)
                {
                    isEqual = true;
                    break;
                }
            }
            return isEqual;
        }
    }
}
