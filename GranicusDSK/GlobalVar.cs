using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    static class GlobalVar
    {

        // This global variable is used to pass the picked agenda from the selection window to the main window
        // I'm sure there is a much better and elegant way to do this, but I didn't feel like looking for one

        private static int _eventID = 0;

        public static int eventID
        {
            get { return _eventID; }
            set { _eventID = value; }
        }     
    }
}
