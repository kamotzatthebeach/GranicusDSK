using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for DisplayWindow.xaml
    /// </summary>
    public partial class DisplayWindow : Window
    {
        public DisplayWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //This puts the new display window on the correct monitor output and makes it full screen
            Screen tempScreen = GetSecondaryScreen();
            this.Height = tempScreen.Bounds.Height;
            this.Width = tempScreen.Bounds.Width;
            this.Top = tempScreen.Bounds.Top;
            this.Left = tempScreen.Bounds.Left;
        }

        private Screen GetSecondaryScreen()
        {
            
            //This is for testing purposes
            //By default this uses any monitor that is not the main display
            //I use this commant to put it on a specific monitor for testing
            //Comment the next line and uncomment the foreach loop and other return for normal opterating condition

            //return Screen.AllScreens[2];

            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen != Screen.PrimaryScreen)
                    return screen;
            }
            return Screen.PrimaryScreen;
        }

    }
}
