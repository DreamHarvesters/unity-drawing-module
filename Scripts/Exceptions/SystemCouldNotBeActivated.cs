using System;

namespace DH.Drawing.Exceptions
{
    public class SystemCouldNotBeActivated : Exception
    {
        public SystemCouldNotBeActivated() : base("Drawing system could not be activated")
        {}
    }
}