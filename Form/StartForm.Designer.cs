namespace PDFwiz
{
    partial class StartForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.mHistoryList = new HZH_Controls.Controls.UCListExt();
            this.btnNewPdfw = new HZH_Controls.Controls.UCBtnExt();
            this.btnOpen = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtnImgClose = new HZH_Controls.Controls.UCBtnImg();
            this.label1 = new System.Windows.Forms.Label();
            this.ucHistoryListView = new HZH_Controls.Controls.UCListExt();
            this.SuspendLayout();
            // 
            // mHistoryList
            // 
            this.mHistoryList.AutoScroll = true;
            this.mHistoryList.AutoSelectFirst = true;
            this.mHistoryList.ItemBackColor = System.Drawing.Color.White;
            this.mHistoryList.ItemForeColor = System.Drawing.Color.Black;
            this.mHistoryList.ItemForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.mHistoryList.ItemHeight = 60;
            this.mHistoryList.ItemSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.mHistoryList.ItemSelectedForeColor = System.Drawing.Color.White;
            this.mHistoryList.ItemSelectedForeColor2 = System.Drawing.Color.White;
            this.mHistoryList.Location = new System.Drawing.Point(12, 70);
            this.mHistoryList.Name = "mHistoryList";
            this.mHistoryList.SelectedCanClick = false;
            this.mHistoryList.Size = new System.Drawing.Size(383, 368);
            this.mHistoryList.SplitColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.mHistoryList.TabIndex = 0;
            this.mHistoryList.Title2Font = new System.Drawing.Font("微软雅黑", 14F);
            this.mHistoryList.TitleFont = new System.Drawing.Font("微软雅黑", 15F);
            // 
            // btnNewPdfw
            // 
            this.btnNewPdfw.BackColor = System.Drawing.Color.Transparent;
            this.btnNewPdfw.BtnBackColor = System.Drawing.Color.Transparent;
            this.btnNewPdfw.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewPdfw.BtnForeColor = System.Drawing.Color.White;
            this.btnNewPdfw.BtnText = "新  建";
            this.btnNewPdfw.ConerRadius = 5;
            this.btnNewPdfw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewPdfw.EnabledMouseEffect = false;
            this.btnNewPdfw.FillColor = System.Drawing.SystemColors.WindowFrame;
            this.btnNewPdfw.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnNewPdfw.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnNewPdfw.IsRadius = true;
            this.btnNewPdfw.IsShowRect = true;
            this.btnNewPdfw.IsShowTips = false;
            this.btnNewPdfw.Location = new System.Drawing.Point(567, 86);
            this.btnNewPdfw.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewPdfw.Name = "btnNewPdfw";
            this.btnNewPdfw.RectColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnNewPdfw.RectWidth = 1;
            this.btnNewPdfw.Size = new System.Drawing.Size(184, 60);
            this.btnNewPdfw.TabIndex = 1;
            this.btnNewPdfw.TabStop = false;
            this.btnNewPdfw.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnNewPdfw.TipsText = "";
            this.btnNewPdfw.BtnClick += new System.EventHandler(this.btnNewPdfw_BtnClick);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnOpen.BtnBackColor = System.Drawing.Color.Transparent;
            this.btnOpen.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpen.BtnForeColor = System.Drawing.Color.White;
            this.btnOpen.BtnText = "打  开";
            this.btnOpen.ConerRadius = 5;
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.EnabledMouseEffect = false;
            this.btnOpen.FillColor = System.Drawing.SystemColors.WindowFrame;
            this.btnOpen.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnOpen.IsRadius = true;
            this.btnOpen.IsShowRect = true;
            this.btnOpen.IsShowTips = false;
            this.btnOpen.Location = new System.Drawing.Point(567, 156);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(0);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.RectColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnOpen.RectWidth = 1;
            this.btnOpen.Size = new System.Drawing.Size(184, 60);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.TabStop = false;
            this.btnOpen.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnOpen.TipsText = "";
            this.btnOpen.BtnClick += new System.EventHandler(this.btnOpen_BtnClick);
            // 
            // ucBtnImgClose
            // 
            this.ucBtnImgClose.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnImgClose.BtnBackColor = System.Drawing.Color.Transparent;
            this.ucBtnImgClose.BtnFont = new System.Drawing.Font("微软雅黑", 40F);
            this.ucBtnImgClose.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ucBtnImgClose.BtnText = "";
            this.ucBtnImgClose.ConerRadius = 5;
            this.ucBtnImgClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnImgClose.EnabledMouseEffect = false;
            this.ucBtnImgClose.FillColor = System.Drawing.SystemColors.WindowFrame;
            this.ucBtnImgClose.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnImgClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ucBtnImgClose.Image = ((System.Drawing.Image)(resources.GetObject("ucBtnImgClose.Image")));
            this.ucBtnImgClose.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ucBtnImgClose.ImageFontIcons = ((object)(resources.GetObject("ucBtnImgClose.ImageFontIcons")));
            this.ucBtnImgClose.IsRadius = true;
            this.ucBtnImgClose.IsShowRect = true;
            this.ucBtnImgClose.IsShowTips = false;
            this.ucBtnImgClose.Location = new System.Drawing.Point(749, 9);
            this.ucBtnImgClose.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnImgClose.Name = "ucBtnImgClose";
            this.ucBtnImgClose.RectColor = System.Drawing.SystemColors.ButtonShadow;
            this.ucBtnImgClose.RectWidth = 1;
            this.ucBtnImgClose.Size = new System.Drawing.Size(40, 40);
            this.ucBtnImgClose.TabIndex = 3;
            this.ucBtnImgClose.TabStop = false;
            this.ucBtnImgClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ucBtnImgClose.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnImgClose.TipsText = "";
            this.ucBtnImgClose.BtnClick += new System.EventHandler(this.ucBtnImgClose_BtnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 35);
            this.label1.TabIndex = 5;
            this.label1.Text = "最近访问的文件";
            // 
            // ucHistoryListView
            // 
            this.ucHistoryListView.AutoScroll = true;
            this.ucHistoryListView.AutoSelectFirst = true;
            this.ucHistoryListView.ItemBackColor = System.Drawing.Color.White;
            this.ucHistoryListView.ItemForeColor = System.Drawing.Color.Black;
            this.ucHistoryListView.ItemForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucHistoryListView.ItemHeight = 60;
            this.ucHistoryListView.ItemSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucHistoryListView.ItemSelectedForeColor = System.Drawing.Color.White;
            this.ucHistoryListView.ItemSelectedForeColor2 = System.Drawing.Color.White;
            this.ucHistoryListView.Location = new System.Drawing.Point(12, 70);
            this.ucHistoryListView.Name = "ucHistoryListView";
            this.ucHistoryListView.SelectedCanClick = false;
            this.ucHistoryListView.Size = new System.Drawing.Size(336, 368);
            this.ucHistoryListView.SplitColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ucHistoryListView.TabIndex = 6;
            this.ucHistoryListView.Title2Font = new System.Drawing.Font("微软雅黑", 14F);
            this.ucHistoryListView.TitleFont = new System.Drawing.Font("微软雅黑", 15F);
            this.ucHistoryListView.Load += new System.EventHandler(this.ucHistoryListView_Load);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucHistoryListView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucBtnImgClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnNewPdfw);
            this.Controls.Add(this.mHistoryList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartForm";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HZH_Controls.Controls.UCListExt mHistoryList;
        private HZH_Controls.Controls.UCBtnExt btnNewPdfw;
        private HZH_Controls.Controls.UCBtnExt btnOpen;
        private HZH_Controls.Controls.UCBtnImg ucBtnImgClose;
        private System.Windows.Forms.Label label1;
        private HZH_Controls.Controls.UCListExt ucHistoryListView;
    }
}

