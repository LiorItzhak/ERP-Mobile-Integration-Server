using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Web_Api.Utils
{
    public abstract class MyUtils
    {
        //for logging
        public static long GetObjectMemoryAddress(Object obj)
        {
            GCHandle objHandle = GCHandle.Alloc(obj, GCHandleType.WeakTrackResurrection);
            return GCHandle.ToIntPtr(objHandle).ToInt64();
              
        }
    }
}
