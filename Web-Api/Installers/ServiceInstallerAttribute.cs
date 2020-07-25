using System;

namespace Web_Api.Installers
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ServiceInstallerAttribute : Attribute
    {
        
        public ServiceInstallerAttribute(bool isActive )
        {
            IsActive = isActive;
        }
        public bool IsActive { get; }
    }
    
    
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ProfileAttribute : Attribute
    {
        
        public ProfileAttribute(string profile )
                 {
                     Profiles = new []{profile};
                 }
        public ProfileAttribute(params string[]  profiles )
        {
            Profiles = profiles;
        }
        public string[] Profiles { get; }
    }
}