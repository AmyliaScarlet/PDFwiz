using HZH_Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFwiz.Entity
{
    
    public class HistoryItemControl: UserControl
    {
        private Label lbName;
        private PictureBox pbImage;
        private Label lbPath;
        private Label lbDate;

        public HistoryItemControl() {

            InitializeComponent();

        }

        private void InitializeComponent()
        {
            this.lbName = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lbPath = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(160, 34);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(71, 12);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(22, 25);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(100, 100);
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            //if (Image != null)
            //{
            //    this.pbImage.Image = Image.ToBitmap();
            //}
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(160, 58);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(29, 12);
            this.lbPath.TabIndex = 2;
            this.lbPath.Text = "Path";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(160, 104);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(29, 12);
            this.lbDate.TabIndex = 3;
            this.lbDate.Text = "Date";// this.Date.ToString("yyyy/MM/dd");
            // 
            // HistoryItemControl
            // 
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbPath);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lbName);
            this.Name = "HistoryItemControl";
            this.Size = new System.Drawing.Size(469, 150);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
