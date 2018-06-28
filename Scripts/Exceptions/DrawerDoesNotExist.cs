using System;

namespace DH.Drawing.Exceptions
{
    public class DrawerDoesNotExist : Exception
    {
        public DrawerDoesNotExist() : base("Drawer does not exist. Please create a drawer first")
        {
        }
    }
}