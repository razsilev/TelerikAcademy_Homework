using System;

namespace CreateVersionAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
        AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]
    public class VersionAttribute : Attribute
    {
        private string major;
        private string minor;

        public VersionAttribute(string major, string monor)
        {
            this.major = major;
            this.minor = monor;
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}", this.major, this.minor);
        }
    }
}
