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
using Granicus.MediaManager.SDK;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;




namespace WpfApplication1
{

    public partial class AgendaSelectTree : Window
    {

        private MediaManager mediamanager;

        public AgendaSelectTree(MediaManager mediamanager)
        {
            // TODO: Complete member initialization
            this.mediamanager = mediamanager;

            InitializeComponent();

            FolderData[] folders = mediamanager.GetFolders();
            foreach (FolderData folder in folders)
            {
                //TreeNode foldernode = treeView1.Nodes.Add(folder.Name);
                //System.Windows.MessageBox.Show(folder.Name);
                TreeViewItem newChild = new TreeViewItem();
                newChild.Header = folder.Name;
                treeView1.Items.Add(newChild);
                
                ClipData[] clips = mediamanager.GetClips(folder.ID);
                foreach (ClipData clip in clips)
                {

                    TreeViewItem newSubChild = new TreeViewItem();
                    newSubChild.Header = clip.ID.ToString() + " - " + clip.Name + " - " + clip.Date.ToString();
                    newChild.Items.Add(newSubChild);
                }
            }

        }



    }
}
