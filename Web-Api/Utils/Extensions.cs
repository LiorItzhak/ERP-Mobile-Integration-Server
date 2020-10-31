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

        public static string BitmapMapLocalPathToUri(this ControllerBase controller,string localPath)
        {
            if (!string.IsNullOrEmpty(localPath) && !IsValidUri(localPath))
            {
                var fileName = localPath.Contains(@":") || localPath.Contains(@"\\") ? Path.GetFileName(localPath) : localPath;
                var uri = $@"{controller.Request.Scheme}://{controller.Request.Host.ToUriComponent()}/api/Files/Bitmap/{fileName}";
                return uri;
            }
            else
                return localPath;
        }

        private static bool IsValidUri(string uriToCheck)
        {
            if (!Uri.IsWellFormedUriString(uriToCheck, UriKind.Absolute))
                return false;
            if (!Uri.TryCreate(uriToCheck, UriKind.Absolute, out var tmp))
                return false;
            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }
    }
}
