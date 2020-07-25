using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.Utils
{
    public static class Extensions
    {

        public static string MapLocalPathToUri(this ControllerBase controller,string localPath)
        {
            if (!String.IsNullOrEmpty(localPath) && !isValidUri(localPath))
            {
                string fileName = localPath.Contains(@":") || localPath.Contains(@"\\") ? Path.GetFileName(localPath) : localPath;
                string uri = $@"{controller.Request.Scheme}://{controller.Request.Host.ToUriComponent()}/api/Files/FromLocal/{fileName}";
                return uri;
            }
            else
                return localPath;
        }

        static private bool isValidUri(string uriToCheck)
        {
            if (!Uri.IsWellFormedUriString(uriToCheck, UriKind.Absolute))
                return false;
            Uri tmp;
            if (!Uri.TryCreate(uriToCheck, UriKind.Absolute, out tmp))
                return false;
            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }
    }
}
