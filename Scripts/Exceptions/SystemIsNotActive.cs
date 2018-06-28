using System;

namespace DH.Drawing.Exceptions
{
    public class SystemIsNotActive : Exception
    {
        public SystemIsNotActive() : base("Drawing module is not active")
        {
        }
    }
}