using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Windows.Data.Pdf;
using Windows.Foundation;
using Windows.Storage.Streams;




namespace Pdf2Jpg
{
    public partial class FormMain : Form
    {
        protected PdfExtractor  _extractor;


        public FormMain(string[] args)
        {
            InitializeComponent();

            if ( args.Length > 0 )
            {
                lnkPdf.Text = args[0];
            }

            _extractor = new PdfExtractor();
        }


        ToolTip t = new ToolTip();
        private void FormMain_Load(object sender, EventArgs e)
        {
           
            //t.SetToolTip(this, "Use Drag and Drop from the explorer");
            t.ShowAlways = true;
            t.Show("Use Drag and Drop from the explorer", this);
         }


        /// <summary>Select a PDF document</summary>
        private void btnPdf_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.RestoreDirectory = true;
            dlg.Multiselect      = false;


            dlg.Title  = "Select a PDF document";
            dlg.Filter = "PDF (*.PDF)|*.PDF";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lnkPdf.Text = dlg.FileName;
                btnStartStop_Click(null,null);
            }
        }

        /// <summary>Show Path in explorer</summary>
        private void lnkExtractPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", lnkExtractPath.Text);
        }



        /// <summary>Select a PDF document</summary>
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            _extractor.PdfFileName = lnkPdf.Text;

            if ( _extractor.IsRunning() )
            {
                _extractor.Stop();
            }
            else
            {
                _extractor.PdfFileName = lnkPdf.Text;
                _extractor.DoExtract   = chkDoExtract.Checked;
                _extractor.ExtractPath = lnkExtractPath.Text;
                _extractor.Start();
            }


        }


        /// <summary>Refresh the view</summary>
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            int count = _extractor.Bitmaps.Count;

            if ( count > 0 )
            {
                sld.Minimum     = 0;
                sld.Maximum     = count -1;

                sld.SmallChange = 1;
                sld.LargeChange = 1;

                int i = sld.Value;

                if ( picBitmap.BackgroundImage == null )
                {
                    picBitmap.BackgroundImage   = _extractor.Bitmaps[i] as Bitmap;
                }

                sld.Visible         = true;
                lblInfo.Visible     = true;
                lblInfo.Text        = String.Format("Page {0} of {1}",   i + 1,   count);
            }
            else
            {
                picBitmap.Image     = null;

                sld.Visible         = false;
                lblInfo.Visible     = false;
            }

            btnStartStop.Enabled = ( _extractor.PdfFileName != null );


            if ( _extractor.IsRunning() )
            {
                btnStartStop.Text = "Stop";
            }
            else
            {
                btnStartStop.Text = "Start";
            }


            lnkExtractPath.Text = _extractor.ExtractPath;
        }





        /// <summary>Set the PictureBox</summary>
        private void sld_ValueChanged(object sender, EventArgs e)
        {
            int count   = _extractor.Bitmaps.Count;
            int i       = sld.Value;

            if ( i < count )
            {
                picBitmap.BackgroundImage   = _extractor.Bitmaps[i] as Bitmap;
                lblInfo.Text                = String.Format("Page {0} of {1}", i+1, count);
            }
            else
            {
                picBitmap.BackgroundImage = null;
            }

        }

 





        private void        FormMain_DragEnter  (object sender, DragEventArgs e)
        {
            if ( GetPdfFilename(e) == null )
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void        FormMain_DragDrop   (object sender, DragEventArgs e)
        {
            string pdf = GetPdfFilename(e);

            if (pdf != null )
            {
                lnkPdf.Text = pdf;
                _extractor.Stop();
                btnStartStop_Click(null,null);
            }

        }

        /// <summary>Returns null or the valid pdf filename for Drag and Drop</summary>
        protected string    GetPdfFilename      (DragEventArgs e)
        {
            string[] sa = e.Data.GetData(DataFormats.FileDrop) as string[];

            if(sa != null)
            {
                if(sa.Length == 1)
                {
                    FileInfo fi = new FileInfo(sa[0]);
                    if(fi.Extension.ToLower() == ".pdf")
                    {
                        return sa[0];   // -->
                    }
                }
            }

            return null;
        }

        private void chkDoExtract_CheckedChanged(object sender, EventArgs e)
        {
            _extractor.DoExtract = chkDoExtract.Checked;
        }

        private void lnkPdf_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", lnkPdf.Text);
        }
    }
}