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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using Artefact.Animation;
using System.Threading;
using Granicus.MediaManager.SDK;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml;

namespace WpfApplication1
{           
    public partial class MainWindow : Window
    {

        DisplayWindow newWindow;
        public Granicus.MediaManager.SDK.MediaManager mediamanager;
    
        public MainWindow()
        {
            double time = .75;
            double delay = 0;
            PercentHandler ease = AnimationTransitions.CubicEaseOut;

            InitializeComponent();

            //Opens the display window
            newWindow = new DisplayWindow();
            newWindow.Show();

            //Initial animations to move items off of the screen
            FadeInCanvas(newWindow.FullscreenLogo);
            FadeOut(newWindow.LowerThirdNameTag);
            FadeOut(newWindow.LowerThirdJobTag); 
            newWindow.TreeLogoLowerLeft.AlphaTo(0, time, ease, delay);
            MainLowerThirdDeactivateFunc();
            newWindow.CurrentMarquee.AlphaTo(0, time, ease, 0);
            newWindow.CurrentTitleBackground.AlphaTo(0, time, ease, .6);
            FadeOutCanvas(newWindow.FullscreenLogo);
     
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            newWindow.Close();
        }



        //**************************************************
        //
        // Basic Fade functions for use with animations
        //
        //**************************************************
        private void FadeOut(System.Windows.Controls.Label e) 
        {

            double time = .75;
            double delay = 0;
            PercentHandler ease = AnimationTransitions.CubicEaseOut;
            e.AlphaTo(0, time, ease, delay);
                  
        }

        private void FadeOutCanvas(System.Windows.Controls.Canvas e)
        {

            double time = .75;
            double delay = 0;
            PercentHandler ease = AnimationTransitions.CubicEaseOut;
            e.AlphaTo(0, time, ease, delay);

        }

        private void FadeInCanvas(System.Windows.Controls.Canvas e)
        {
            double time = .75;
            double delay = 0;
            PercentHandler ease = AnimationTransitions.CubicEaseOut;
            e.AlphaTo(1, time, ease, delay);
        }

        private void FadeIn(System.Windows.Controls.Label e)
        {

            double time = .75;
            double delay = 0;
            PercentHandler ease = AnimationTransitions.CubicEaseOut;
            e.AlphaTo(1, time, ease, delay);

        }

        //**************************************************************
        //
        //  Functions to control name and titles
        //
        //**************************************************************

        private void replaceLowerThirdText(string tempName, string tempTitle)
        {
            MainLowerThirdActivateFunc();
            var timeout3 = new Artefact.Animation.Timeout(750, true).OnUpdate((x) =>
            { }).OnComplete(x =>
            {
                FadeOut(newWindow.LowerThirdNameTag);
                FadeOut(newWindow.LowerThirdJobTag);
                var timeout2 = new Artefact.Animation.Timeout(750, true).OnUpdate((w) =>
                { }).OnComplete(w =>
                {
                    newWindow.LowerThirdNameTag.Content = tempName;
                    newWindow.LowerThirdJobTag.Content = tempTitle;
                    FadeIn(newWindow.LowerThirdNameTag);
                    FadeIn(newWindow.LowerThirdJobTag);
                });
            });


        }


        private void BobGrabowski_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("Bob Grabowski", "Councilman District 6");
        }

        private void TomRice_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("Tom Rice", "Chairman");
        }

        private void HaroldGWorley_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("Harold G. Worley", "Vice Chairman - District 1");
        }

        private void BrentSchulz_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("Brent Schulz", "District 2");
        }

        private void MarionFoxworth_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("Marion Foxworth, III", "District 3");
        }

        private void GaryLoftus_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("Gary Loftus", "District 4");
        }

        private void PaulDPriceJr_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("Paul D. Price, Jr.", "District 5");
        }

        private void JamesRFrazier_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("James R. Frazier", "District 7");
        }

        private void CarlSchwartzkopf_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("Carl Schwartzkopf", "District 8");
        }

        private void JodyPrince_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("Jody Prince", "District 10");
        }

        private void WPaulPrince_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("W. Paul Prince", "District 9");
        }

        private void JohnWeaver_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("John Weaver", "County Administrator");
        }

        private void PaulWhitten_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("Paul Whitten", "Assistant County Administrator");
        }

        private void AnnWright_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("Ann Wright", "Assistant County Administrator");
        }

        private void SteveGosnell_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("Steve Gosnell", "Assistant County Administrator");
        }

        private void CustomNameAndTitle_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText(NameTextBox.Text.ToString(), TitleTextBox.Text.ToString());
        }

        private void SheilaButler_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("Sheila Butler", "Chief Information Officer");
        }

        private void GaryWatson_Click(object sender, RoutedEventArgs e)
        {
            replaceLowerThirdText("Gary Watson", "Director of Maintenance");
        }

        //******************************************************************
        //
        // Various other Animation controls
        //
        //******************************************************************
        private void button2_Click_1(object sender, RoutedEventArgs e)
        {

            FadeOut(newWindow.LowerThirdNameTag);
            FadeOut(newWindow.LowerThirdJobTag);
            var timeout2 = new Artefact.Animation.Timeout(750, true).OnUpdate((w) =>
            { }).OnComplete(w =>
            {
                newWindow.LowerThirdNameTag.Content = "Al Allen";
                newWindow.LowerThirdJobTag.Content = "District 11";
                FadeIn(newWindow.LowerThirdNameTag);
                FadeIn(newWindow.LowerThirdJobTag);
            });
        }

        private void LiveLogo_Click(object sender, RoutedEventArgs e)
        {

            double time = .75;
            double delay = 0;
            PercentHandler ease = AnimationTransitions.CubicEaseOut;       
            newWindow.TreeLogoLowerLeft.AlphaTo(1, time, ease, delay);
        }

        private void LiveLogoDeactivate_Click(object sender, RoutedEventArgs e)
        {
            double time = .75;
            double delay = 0;
            PercentHandler ease = AnimationTransitions.CubicEaseOut;

       
            newWindow.TreeLogoLowerLeft.AlphaTo(0, time, ease, delay);
        }

        private void ClearNameAndTitle_Click(object sender, RoutedEventArgs e)
        {
            FadeOut(newWindow.LowerThirdNameTag);
            FadeOut(newWindow.LowerThirdJobTag);
        }

        private void OnBreakButton_Click(object sender, RoutedEventArgs e)
        {
            FadeInCanvas(newWindow.FullscreenLogo);
        }

        private void OnBreakDeactivateButton_Click(object sender, RoutedEventArgs e)
        {
            FadeOutCanvas(newWindow.FullscreenLogo);
        }

        private void MainLowerThirdDeactivate_Click(object sender, RoutedEventArgs e)
        {

            MainLowerThirdDeactivateFunc();

        }

        private void MainLowerThirdDeactivateFunc()
        {

            double time = 1.5;
            double delay = 0;
            PercentHandler ease = AnimationTransitions.CubicEaseOut;
            PercentHandler ease2 = AnimationTransitions.CubicEaseIn;

            FadeOut(newWindow.LowerThirdNameTag);
            FadeOut(newWindow.LowerThirdJobTag);

            var timeout2 = new Artefact.Animation.Timeout(500, true).OnUpdate((w) =>
            { }).OnComplete(w =>
            {
                newWindow.LowerThirdBackground.DimensionsTo(0, 139, time, ease, delay);

            });

        }

        private void MainLowerThirdActivate_Click(object sender, RoutedEventArgs e)
        {
            MainLowerThirdActivateFunc();
        }

        private void MainLowerThirdActivateFunc()
        {

            PercentHandler ease = AnimationTransitions.CubicEaseOut;
            PercentHandler ease2 = AnimationTransitions.CubicEaseIn;
            PercentHandler ease3 = AnimationTransitions.BounceEaseOut;

            newWindow.LowerThirdBackground.DimensionsTo(862, 139, 1.75, ease, .6);

        }

        private void ScrollActivate_Click(object sender, RoutedEventArgs e)
        {

            ScrollActivateFunc();

        }

        private void ScrollActivateFunc()
        {

            double time = .75;
            double delay = 0;
            String test = "";

            PercentHandler ease = AnimationTransitions.CubicEaseOut;


            newWindow.CurrentMarquee.AlphaTo(1, time, ease, .3);
            newWindow.CurrentTitleBackground.AlphaTo(1, time, ease, delay);

            test = newWindow.CurrentMarquee.ToString();


            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.To = -test.Length * 15;
            doubleAnimation.From = newWindow.Main.ActualWidth;
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation.Duration = new Duration(TimeSpan.Parse("0:0:30"));
            if (test.Length > 72)
            {
                newWindow.CurrentMarquee.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
            }

        }

        private void ScrollDeactivate_Click(object sender, RoutedEventArgs e)
        {
            double time = .75;
            PercentHandler ease = AnimationTransitions.CubicEaseOut;

            newWindow.CurrentMarquee.AlphaTo(0, time, ease, 0);
            newWindow.CurrentTitleBackground.AlphaTo(0, time, ease, .6);

        }

        //*************************************************************************
        //
        // Functions for Granicus control
        //
        //**************************************************************************
        private void GranicusLogin_Click(object sender, RoutedEventArgs e)
        {
 
            mediamanager = new MediaManager();
 
            // If login is successfull.  
            // Go to agenda slection screen

            LoginForm login = new LoginForm(mediamanager);
            DialogResult result = login.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                AgendaSelection agendaSelect = new AgendaSelection(mediamanager);
                agendaSelect.ShowDialog();

            }
            else
            {
                System.Windows.MessageBox.Show("Connection Failed!");
            }

            //Populate marquee area with data from agenda
            //This uses two recursive functions

            MetaDataData[] metaArray = mediamanager.GetEventMetaData(GlobalVar.eventID);

            mediamanager.ConvertToMetaTree(ref metaArray);

            foreach (MetaDataData meta in metaArray)
            {
                TreeViewItem newChild = new TreeViewItem();
                newChild.Header = meta.Name.Remove(0,3);
                agendaItemsTree.Items.Add(newChild);
                createTreeView(meta.Children, newChild);
            }
        }

        // Recursive function for populating agenda tree.
        private void createTreeView(MetaDataData[] meta_array, TreeViewItem treeItem)
        {
            //System.Windows.MessageBox.Show("hi");
            foreach (MetaDataData meta in meta_array)
            {
                TreeViewItem newChild = new TreeViewItem();
                newChild.Header = meta.Name.Remove(0,3);
                treeItem.Items.Add(newChild);
                //System.Windows.MessageBox.Show(meta.Name);
                createTreeView(meta.Children,newChild);

            }
        }

        // Recursive function for populating agenda tree.
        private void createTreeView(MetaDataDataCollection meta_collection, TreeViewItem treeItem)
        {
            ArrayList al = new ArrayList(meta_collection);
            MetaDataData[] meta = (MetaDataData[])al.ToArray(typeof(MetaDataData));
            createTreeView(meta,treeItem);
        }

        // Function to manually select an agenda item my double clicking on it.
        private void agendaItemsTree_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            double time = .75;
            String test = "";

            PercentHandler ease = AnimationTransitions.CubicEaseOut;
            TreeViewItem temp = (TreeViewItem) agendaItemsTree.SelectedItem;

            ScrollActivateFunc();

            //Fades the current marquee text
            newWindow.CurrentMarquee.AlphaTo(0, time, ease, 0);

            var timeout2 = new Artefact.Animation.Timeout(750, true).OnUpdate((w) =>
            { }).OnComplete(w =>
            {
                // Stops the current marquees animation and changes it's value
                newWindow.CurrentMarquee.BeginAnimation(Canvas.LeftProperty, null);
                newWindow.CurrentMarquee.Content = temp.Header.ToString();

                //Restarts the animation wiht new data
                test = newWindow.CurrentMarquee.ToString();
                DoubleAnimation doubleAnimation = new DoubleAnimation();
                doubleAnimation.To = -test.Length * 17;
                doubleAnimation.From = newWindow.Main.ActualWidth;
                doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
                doubleAnimation.Duration = new Duration(TimeSpan.Parse("0:0:30"));
                if (test.Length > 72)
                {
                    newWindow.CurrentMarquee.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
                }

                //Fades the marqee text back into view
                newWindow.CurrentMarquee.AlphaTo(1, time, ease, .3);
            });

        }
    }

    // Class to agenda item data
    public class agendaListing
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }

    }

}
