using HZH_Controls.Controls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDFwiz.Entity;
using PDFwiz.Helper;
using PDFwiz.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Microsoft.VisualBasic;
using Spire.Xls.Core;
using Microsoft.Office.Interop.Word;
using System.IO;
using PDFwiz.Constants;
using Newtonsoft.Json;

namespace PDFwiz
{
    public partial class StartForm : Form
    {
        public StartForm(string[] args)
        {
            InitializeComponent();

            if (args.Length >= 2) 
            {
                OpenFile(args[1]);
            }

            

         
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            FillHistoryList();

            btnNewPdfw.Focus();
        }

        private void FillHistoryList()
        {
            historyListBox.DrawMode = DrawMode.OwnerDrawVariable;

            List<HistoryItem> historyItems = AppConfigHelper.GetHistoryList();
            historyItems = historyItems.OrderByDescending(i => i.Date).ToList();
            //HistoryItemControl historyItemControl = new HistoryItemControl();
            //List<HistoryItemControl> historyItemControls = new List<HistoryItemControl>();
            //historyItemControl.get
            //historyItemControls.Add(historyItemControl);

            foreach (HistoryItem item in historyItems)
            {
                HistoryItemControl itemControl = new HistoryItemControl();
                itemControl.vName = item.Name;
                itemControl.vPath = item.Path;

                if (item.Image != null) 
                {
                    itemControl.vImage = DataHelper.Base64ToBitmap(item.Image);
                }
                itemControl.vDate = item.Date.ToString("yyyy/MM/dd");

                historyListBox.Items.Add(itemControl);
            }

            historyListBox.Height = (int)(new HistoryItemControl().Height * historyItems.Count);
            historyListBox.Width = new HistoryItemControl().Width;
        }

        private void btnOpen_BtnClick(object sender, EventArgs e)
        {

            string sDesktopDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//获取系统桌面目录路径。

            OpenFileDialog openFileDialog = new OpenFileDialog();

            //设置对话框标题
            openFileDialog.Title = "选择文件";
            //设置文件类型
            openFileDialog.Filter = "文档文件|*.pdfw;*.pdf;*.doc;*.docx";
            //默认加载目录
            openFileDialog.InitialDirectory = sDesktopDirectory;
            //记忆之前打开的对话框
            openFileDialog.RestoreDirectory = true;
            //多选
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                OpenFile(fileName);  
            }


        }

        private void OpenFile(string fileName) 
        {
            this.Hide();
            FormCommand formCommand = new FormCommand(FormCommandType.Open, fileName);
            string ext = fileName.Substring(fileName.IndexOf('.') + 1, fileName.Length - (fileName.IndexOf('.') + 1));
            if (ext == "doc" || ext == "docx")
            {
                WordForm wordForm = new WordForm(this, formCommand);
                wordForm.Show();
            }
            else if (ext == "pdf")
            {
                PdfForm pdfForm = new PdfForm(this, formCommand);
                pdfForm.Show();
            }
            else if (ext == "pdfw")
            {
                PdfwForm pdfwForm = new PdfwForm(this, formCommand);
                pdfwForm.Show();
            }
            
        }

        private void btnNewPdfw_BtnClick(object sender, EventArgs e)
        {
            using (InputDialogForm inputDialog = new InputDialogForm())
            {
                if (inputDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string userInput = inputDialog.UserInput;
                    if (userInput.Length>0) 
                    {
                        string fileName = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + userInput + ".docx";
                        FormCommand formCommand = new FormCommand(FormCommandType.New, fileName);
                        WordForm wordForm = new WordForm(this, formCommand);
                        wordForm.Show();
                    }
                   
                }
            }
        }

        private void ucBtnImgClose_BtnClick(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        //调用系统API
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int VM_NCLBUTTONDOWN = 0XA1;//定义鼠标左键按下
        public const int HTCAPTION = 0x0002; //HTCAPTION=2 鼠标在标题栏中
        private void StartForm_MouseDown(object sender, MouseEventArgs e)
        {
            //为当前应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息 让系统误以为在标题栏上按下鼠标
            SendMessage((IntPtr)this.Handle, VM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void btnNewPdfw_MouseEnter(object sender, EventArgs e)
        {
            ((UCBtnExt)sender).FillColor = Color.Gray;
        }

        private void btnNewPdfw_MouseLeave(object sender, EventArgs e)
        {
            ((UCBtnExt)sender).FillColor = SystemColors.WindowFrame;
        }

        private void btnOpen_MouseEnter(object sender, EventArgs e)
        {
            ((UCBtnExt)sender).FillColor = Color.Gray;
        }

        private void btnOpen_MouseLeave(object sender, EventArgs e)
        {
            ((UCBtnExt)sender).FillColor = SystemColors.WindowFrame;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0 && e.Index < historyListBox.Items.Count)
            {
                // 获取要绘制的自定义UserControl
                HistoryItemControl control = (HistoryItemControl)historyListBox.Items[e.Index];
                // 创建一个大小与自定义UserControl相同的Bitmap
                Bitmap bitmap = new Bitmap(control.Width, control.Height);
                // 将自定义UserControl绘制到Bitmap中
                control.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, control.Width, control.Height));
                // 绘制Bitmap到ComboBox中
                e.Graphics.DrawImage(bitmap, e.Bounds);

                // 绘制选中项获取焦点时的矩形区域
                e.DrawFocusRectangle();
            }
        }

        private void historyListBox_DrawItem(object sender, DrawItemEventArgs e)
        {

            if (e.Index >= 0 && e.Index < historyListBox.Items.Count)
            {
                // 获取要绘制的自定义UserControl
                HistoryItemControl control = (HistoryItemControl)historyListBox.Items[e.Index];
                // 创建一个大小与自定义UserControl相同的Bitmap
                Bitmap bitmap = new Bitmap(control.Width, control.Height);
                // 将自定义UserControl绘制到Bitmap中
                control.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, control.Width, control.Height));
                // 绘制Bitmap到ComboBox中
                e.Graphics.DrawImage(bitmap, e.Bounds);

                // 绘制选中项获取焦点时的矩形区域
                e.DrawFocusRectangle();
            }

        }

        private void historyListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // 获取要测量的自定义UserControl
            HistoryItemControl control = (HistoryItemControl)historyListBox.Items[e.Index];
            // 设置项的高度为自定义UserControl的高度
            e.ItemHeight = control.Height;
        }

        private void historyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HistoryItemControl control = (HistoryItemControl)historyListBox.SelectedItem;
            string filename = Path.Combine(control.vPath,control.vName);
            OpenFile(filename);
            
        }

        //private void historyListBox_MouseHover(object sender, EventArgs e)
        //{
        //    //var screenMousePos = Cursor.Position;
        //    ////var chartMousePos = historyListBox.PointToClient(screenMousePos);

        //    //HistoryItemControl control = (HistoryItemControl)((ListBox)sender).GetChildAtPoint(screenMousePos, GetChildAtPointSkip.None);
        //    //if (control != null)
        //    //    control.BackColor = Color.White;

        //}
    }
}
