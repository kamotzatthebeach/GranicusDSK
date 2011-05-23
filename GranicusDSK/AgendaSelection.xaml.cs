using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Granicus.MediaManager.SDK;
using System.Web.Services.Protocols;
using System.Windows;

namespace WpfApplication1
{
    public partial class AgendaSelection : Window
    {
        private MediaManager mediamanager;
    
        public AgendaSelection(MediaManager mediamanager)
        {
            // TODO: Complete member initialization
            this.mediamanager = mediamanager;
         
            InitializeComponent();

            //Fill selection screen

            EventData[] existingEvents;
            existingEvents = this.mediamanager.GetEvents();

            foreach (EventData eventdata in existingEvents)
            {
                agendaList.Items.Add(new agendaListing { 
                    ID = eventdata.ID, 
                    Name = eventdata.Name, 
                    Date = eventdata.StartTime.ToString() }
                );   
            }
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {

            // Retrieves the selected agenda
            agendaListing temp = (agendaListing) agendaList.SelectedItem;

            // Saves ID number to global variable so main window can use it
            GlobalVar.eventID = temp.ID;

            this.Close();


        }    
    }
}
