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

            

            FillHistoryList();
        }

        private void FillHistoryList()
        {
            OrderedDictionary historyList = Settings.Default.HistoryList;
            //historyList
            //ucHistoryListView.SetList()
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

                this.Hide();
            }


        }

        private void OpenFile(string fileName) 
        {
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
            string PM = Interaction.InputBox("", "新建文档", "", 100, 100);
            if (PM.Length > 0) 
            {
                string fileName = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + PM + ".doc";
                FormCommand formCommand = new FormCommand(FormCommandType.New, fileName);
                WordForm wordForm = new WordForm(this, formCommand);
                wordForm.Show();
            }
        }

        private void ucBtnImgClose_BtnClick(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void ucHistoryListView_Load(object sender, EventArgs e)
        {
            
        }
    }
}
