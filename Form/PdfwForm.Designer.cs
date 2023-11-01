namespace PDFwiz
{
    partial class PdfwForm
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
            this.ucBtnEdit = new HZH_Controls.Controls.UCBtnExt();
            this.SuspendLayout();
            // 
            // mPdfViewer
            // 
            this.mPdfViewer.FindTextHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))), ((int)(((byte)(218)))));
            this.mPdfViewer.FormFillEnabled = false;
            this.mPdfViewer.IgnoreCase = false;
            this.mPdfViewer.IsToolBarVisible = true;
            this.mPdfViewer.Location = new System.Drawing.Point(12, 61);
            this.mPdfViewer.MultiPagesThreshold = 60;
            this.mPdfViewer.Name = "mPdfViewer";
            this.mPdfViewer.OnRenderPageExceptionEvent = null;
            this.mPdfViewer.Size = new System.Drawing.Size(776, 377);
            this.mPdfViewer.TabIndex = 1;
            this.mPdfViewer.Text = "pdfViewer1";
            this.mPdfViewer.Threshold = 60;
            this.mPdfViewer.ViewerBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            // 
            // ucBtnEdit
            // 
            this.ucBtnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.ucBtnEdit.BtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.ucBtnEdit.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnEdit.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnEdit.BtnText = "编 辑";
            this.ucBtnEdit.ConerRadius = 2;
            this.ucBtnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnEdit.EnabledMouseEffect = false;
            this.ucBtnEdit.FillColor = System.Drawing.Color.Silver;
            this.ucBtnEdit.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnEdit.IsRadius = true;
            this.ucBtnEdit.IsShowRect = true;
            this.ucBtnEdit.IsShowTips = false;
            this.ucBtnEdit.Location = new System.Drawing.Point(12, 9);
            this.ucBtnEdit.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnEdit.Name = "ucBtnEdit";
            this.ucBtnEdit.RectColor = System.Drawing.SystemColors.ButtonShadow;
            this.ucBtnEdit.RectWidth = 1;
            this.ucBtnEdit.Size = new System.Drawing.Size(118, 49);
            this.ucBtnEdit.TabIndex = 2;
            this.ucBtnEdit.TabStop = false;
            this.ucBtnEdit.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnEdit.TipsText = "";
            this.ucBtnEdit.BtnClick += new System.EventHandler(this.ucBtnEdit_BtnClick);
            // 
            // PdfwForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucBtnEdit);
            this.Controls.Add(this.mPdfViewer);
            this.Name = "PdfwForm";
            this.Text = "PdfwForm";
            this.SizeChanged += new System.EventHandler(this.PdfwForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private Spire.PdfViewer.Forms.PdfViewer mPdfViewer;
        private HZH_Controls.Controls.UCBtnExt ucBtnEdit;
    }
}