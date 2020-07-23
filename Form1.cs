﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuxBhi
{
    public partial class Form1 : Form
    {
        String Url = string.Empty;
        public Form1()
        {
            InitializeComponent();
            Url = "http://www.google.co.in";
            myBrowser();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = false;
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            myBrowser();
        }
        private void myBrowser()
        {
            if (toolStripComboBox1.Text != "")
                Url = toolStripComboBox1.Text;
            webBrowser1.Navigate(Url);
            webBrowser1.ProgressChanged +=
            new WebBrowserProgressChangedEventHandler(webpage_ProgressChanged);
            webBrowser1.DocumentTitleChanged += new EventHandler(webpage_DocumentTitleChanged);
            webBrowser1.StatusTextChanged += new EventHandler(webpage_StatusTextChanged);
            webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(webpage_Navigated);
            webBrowser1.DocumentCompleted +=
            new WebBrowserDocumentCompletedEventHandler(webpage_DocumentCompleted);
            webBrowser1.ScriptErrorsSuppressed = true;  // Disables script error
        }
        private void webpage_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs
       e)
        {
            if (webBrowser1.CanGoBack) toolStripButton1.Enabled = true;
            else toolStripButton1.Enabled = false;
            if (webBrowser1.CanGoForward) toolStripButton2.Enabled = true;
            else toolStripButton2.Enabled = false;
            toolStripStatusLabel1.Text = "Done";
        }
        private void webpage_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Text = webBrowser1.DocumentTitle.ToString();
        }
        private void webpage_StatusTextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = webBrowser1.StatusText;
        }
        private void webpage_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Maximum = (int)e.MaximumProgress;
            toolStripProgressBar1.Value = ((int)e.CurrentProgress < 0 ||
            (int)e.MaximumProgress < (int)e.CurrentProgress) ? (int)e.MaximumProgress :
           (int)e.CurrentProgress;
        }
        private void webpage_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            toolStripComboBox1.Text = webBrowser1.Url.ToString();
        }


        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton6_Click_1(object sender, EventArgs e)
        {
            TabPage tb = new TabPage();
            
            tabControl1.TabPages.Add(tb);
            WebBrowser wb = new WebBrowser()
            {
                ScriptErrorsSuppressed = true
            };
            tb.Controls.Add(wb);
            this.Text = webBrowser1.DocumentTitle; 
            tabControl1.SelectedTab.Text = webBrowser1.DocumentTitle;
           
            wb.Navigate("www.google.com");
            wb.Dock = DockStyle.Fill;

        }

       
        private void tabPage2_Click(object sender, EventArgs e)
        {
            TabPage tb = new TabPage();
            WebBrowser wb = new WebBrowser()
            {
                ScriptErrorsSuppressed = true
            };
            wb.Navigate("www.google.com");
            wb.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tb);
            tb.Controls.Add(wb);
         

        }
    }
}
