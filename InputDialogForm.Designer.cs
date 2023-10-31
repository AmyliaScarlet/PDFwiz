namespace PDFwiz
{
    partial class InputDialogForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new HZH_Controls.Controls.UCBtnExt();
            this.btnCancel = new HZH_Controls.Controls.UCBtnExt();
            this.tbDocName = new HZH_Controls.Controls.TextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "新建文档";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BtnBackColor = System.Drawing.Color.Transparent;
            this.btnOK.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.BtnForeColor = System.Drawing.Color.White;
            this.btnOK.BtnText = "确  认";
            this.btnOK.ConerRadius = 2;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.EnabledMouseEffect = false;
            this.btnOK.FillColor = System.Drawing.SystemColors.WindowFrame;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnOK.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnOK.IsRadius = true;
            this.btnOK.IsShowRect = true;
            this.btnOK.IsShowTips = false;
            this.btnOK.Location = new System.Drawing.Point(39, 165);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.RectColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnOK.RectWidth = 1;
            this.btnOK.Size = new System.Drawing.Size(110, 30);
            this.btnOK.TabIndex = 7;
            this.btnOK.TabStop = false;
            this.btnOK.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnOK.TipsText = "";
            this.btnOK.BtnClick += new System.EventHandler(this.btnOK_BtnClick);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BtnBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.BtnForeColor = System.Drawing.Color.White;
            this.btnCancel.BtnText = "取  消";
            this.btnCancel.ConerRadius = 2;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.EnabledMouseEffect = false;
            this.btnCancel.FillColor = System.Drawing.SystemColors.WindowFrame;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnCancel.IsRadius = true;
            this.btnCancel.IsShowRect = true;
            this.btnCancel.IsShowTips = false;
            this.btnCancel.Location = new System.Drawing.Point(220, 165);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RectColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCancel.RectWidth = 1;
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.TabStop = false;
            this.btnCancel.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnCancel.TipsText = "";
            this.btnCancel.BtnClick += new System.EventHandler(this.btnCancel_BtnClick);
            // 
            // tbDocName
            // 
            this.tbDocName.DecLength = 2;
            this.tbDocName.InputType = HZH_Controls.TextInputType.NotControl;
            this.tbDocName.Location = new System.Drawing.Point(117, 97);
            this.tbDocName.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.tbDocName.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.tbDocName.MyRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tbDocName.Name = "tbDocName";
            this.tbDocName.OldText = null;
            this.tbDocName.PromptColor = System.Drawing.Color.Gray;
            this.tbDocName.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbDocName.PromptText = "";
            this.tbDocName.RegexPattern = "";
            this.tbDocName.Size = new System.Drawing.Size(185, 21);
            this.tbDocName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(50, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "文档名称：";
            // 
            // InputDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(376, 227);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDocName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputDialogForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private HZH_Controls.Controls.UCBtnExt btnOK;
        private HZH_Controls.Controls.UCBtnExt btnCancel;
        private HZH_Controls.Controls.TextBoxEx tbDocName;
        private System.Windows.Forms.Label label2;
    }
}