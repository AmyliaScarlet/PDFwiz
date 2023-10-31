using HZH_Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public string vName
        {
            get { return lbName.Text; }
            set { lbName.Text = value; }
        }

        public string vPath
        {
            get { return lbPath.Text; }
            set { lbPath.Text = value; }
        }
        public string vDate
        {
            get { return lbDate.Text; }
            set { lbDate.Text = value; }
        }
        public Image vImage
        {
            get { return pbImage.Image; }
            set { pbImage.Image = value; }
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
            this.lbName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.ForeColor = System.Drawing.Color.White;
            this.lbName.Location = new System.Drawing.Point(57, 8);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(39, 16);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(5, 5);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(40, 40);
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            this.pbImage.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.ForeColor = System.Drawing.Color.Gray;
            this.lbPath.Location = new System.Drawing.Point(58, 25);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(29, 12);
            this.lbPath.TabIndex = 2;
            this.lbPath.Text = "Path";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.ForeColor = System.Drawing.Color.White;
            this.lbDate.Location = new System.Drawing.Point(195, 12);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(29, 12);
            this.lbDate.TabIndex = 3;
            this.lbDate.Text = "Date";
            // 
            // HistoryItemControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbPath);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lbName);
            this.DoubleBuffered = true;
            this.Name = "HistoryItemControl";
            this.Size = new System.Drawing.Size(300, 55);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void pbImage_Click(object sender, EventArgs e)
        {

        }


    }
}
