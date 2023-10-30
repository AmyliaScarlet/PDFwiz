namespace PDFwiz
{
    partial class PdfForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mPdfViewer = new Spire.PdfViewer.Forms.PdfViewer();
            this.SuspendLayout();
            // 
            // mPdfViewer
            // 
            this.mPdfViewer.FindTextHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))), ((int)(((byte)(218)))));
            this.mPdfViewer.FormFillEnabled = false;
            this.mPdfViewer.IgnoreCase = false;
            this.mPdfViewer.IsToolBarVisible = true;
            this.mPdfViewer.Location = new System.Drawing.Point(12, 12);
            this.mPdfViewer.MultiPagesThreshold = 60;
            this.mPdfViewer.Name = "mPdfViewer";
            this.mPdfViewer.OnRenderPageExceptionEvent = null;
            this.mPdfViewer.Size = new System.Drawing.Size(776, 426);
            this.mPdfViewer.TabIndex = 0;
            this.mPdfViewer.Text = "pdfViewer1";
            this.mPdfViewer.Threshold = 60;
            this.mPdfViewer.ViewerBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            // 
            // PdfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mPdfViewer);
            this.Name = "PdfForm";
            this.Text = "PdfForm";
            this.SizeChanged += new System.EventHandler(this.PdfForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private Spire.PdfViewer.Forms.PdfViewer mPdfViewer;
    }
}