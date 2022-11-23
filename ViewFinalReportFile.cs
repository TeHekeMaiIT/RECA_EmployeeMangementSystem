using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LeaveMangementForm
{
    public partial class ViewFinalReportFile : Form
    {
        public ViewFinalReportFile()
        {
            InitializeComponent();
        }
        public string Bath;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void ViewFinalReportFile_Load(object sender, EventArgs e)
        {
                    ViewFinalReportFile VFF = new ViewFinalReportFile();
                    VFF.Text = VFF.Text + " "+ Bath;
               
                    RenderPdf(Bath);   // opens the file in webBrowser window
        }
        private void RenderPdf(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                webBrowser1.Navigate(@filePath);
            }
        }
    }
}
