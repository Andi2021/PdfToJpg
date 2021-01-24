
namespace Pdf2Jpg
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.picBitmap = new System.Windows.Forms.PictureBox();
            this.sld = new System.Windows.Forms.HScrollBar();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.chkDoExtract = new System.Windows.Forms.CheckBox();
            this.lnkExtractPath = new System.Windows.Forms.LinkLabel();
            this.lnkPdf = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picBitmap)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(12, 40);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(100, 50);
            this.btnStartStop.TabIndex = 3;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnPdf
            // 
            this.btnPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPdf.Location = new System.Drawing.Point(854, 12);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(25, 25);
            this.btnPdf.TabIndex = 2;
            this.btnPdf.Text = "...";
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // picBitmap
            // 
            this.picBitmap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBitmap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBitmap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBitmap.Location = new System.Drawing.Point(12, 140);
            this.picBitmap.Name = "picBitmap";
            this.picBitmap.Size = new System.Drawing.Size(867, 487);
            this.picBitmap.TabIndex = 4;
            this.picBitmap.TabStop = false;
            // 
            // sld
            // 
            this.sld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sld.Location = new System.Drawing.Point(9, 115);
            this.sld.Name = "sld";
            this.sld.Size = new System.Drawing.Size(873, 22);
            this.sld.TabIndex = 7;
            this.sld.TabStop = true;
            this.sld.Visible = false;
            this.sld.ValueChanged += new System.EventHandler(this.sld_ValueChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(12, 96);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(155, 19);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "Page 1 of X";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo.Visible = false;
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // chkDoExtract
            // 
            this.chkDoExtract.Checked = true;
            this.chkDoExtract.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDoExtract.Location = new System.Drawing.Point(118, 47);
            this.chkDoExtract.Name = "chkDoExtract";
            this.chkDoExtract.Size = new System.Drawing.Size(75, 20);
            this.chkDoExtract.TabIndex = 4;
            this.chkDoExtract.Text = "Extract to";
            this.chkDoExtract.UseVisualStyleBackColor = true;
            this.chkDoExtract.CheckedChanged += new System.EventHandler(this.chkDoExtract_CheckedChanged);
            // 
            // lnkExtractPath
            // 
            this.lnkExtractPath.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lnkExtractPath.LinkVisited = true;
            this.lnkExtractPath.Location = new System.Drawing.Point(118, 70);
            this.lnkExtractPath.Name = "lnkExtractPath";
            this.lnkExtractPath.Size = new System.Drawing.Size(559, 20);
            this.lnkExtractPath.TabIndex = 5;
            this.lnkExtractPath.TabStop = true;
            this.lnkExtractPath.Text = "linkLabel1";
            this.lnkExtractPath.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lnkExtractPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkExtractPath_LinkClicked);
            // 
            // lnkPdf
            // 
            this.lnkPdf.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lnkPdf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkPdf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lnkPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPdf.LinkVisited = true;
            this.lnkPdf.Location = new System.Drawing.Point(12, 12);
            this.lnkPdf.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lnkPdf.Name = "lnkPdf";
            this.lnkPdf.Size = new System.Drawing.Size(836, 25);
            this.lnkPdf.TabIndex = 8;
            this.lnkPdf.TabStop = true;
            this.lnkPdf.Text = "Use Drag And Drop to select a PDF file...";
            this.lnkPdf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkPdf.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lnkPdf.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPdf_LinkClicked);
            // 
            // FormMain
            // 
            this.AcceptButton = this.btnStartStop;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 639);
            this.Controls.Add(this.lnkPdf);
            this.Controls.Add(this.lnkExtractPath);
            this.Controls.Add(this.chkDoExtract);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.sld);
            this.Controls.Add(this.picBitmap);
            this.Controls.Add(this.btnPdf);
            this.Controls.Add(this.btnStartStop);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "FormMain";
            this.Text = "PDF to JPG converter";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.picBitmap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.PictureBox picBitmap;
        private System.Windows.Forms.HScrollBar sld;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.CheckBox chkDoExtract;
        private System.Windows.Forms.LinkLabel lnkExtractPath;
        private System.Windows.Forms.LinkLabel lnkPdf;
    }
}

