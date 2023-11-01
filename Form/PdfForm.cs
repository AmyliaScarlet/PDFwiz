using System;
using System.Windows.Forms;
using PDFwiz.Constants;
using PDFwiz.Customize;
using PDFwiz.Entity;
using PDFwiz.Helper;
using static System.Windows.Forms.AxHost;

namespace PDFwiz
{
    public partial class PdfForm : Form
    {
        Form parentForm;

        public PdfForm(Form mParentForm, FormCommand mFormCommand)
        {
            InitializeComponent();
            FormComm.Instance.AddListenner(this.Name, this);

            ApplicationStateMachine.Instance.NextState(ApplicationState.onOpenPdf);

            parentForm = mParentForm;
            parentForm.Hide();
            if (mFormCommand.FormCommandType == FormCommandType.Open)
            {
                LoadPdfByDocument(mFormCommand.CommandArgs);
            }

          

        }

        protected override void OnClosed(EventArgs e)
        {
            this.SizeChanged -= PdfForm_SizeChanged;

            //parentForm.Show();

            ApplicationStateMachine.Instance.NextState();

            base.OnClosed(e);
        }

        public void LoadPdfByDocument(string fileName)
        {


            mPdfViewer.LoadFromFile(fileName);

            FileModel pdfModel = FileHelper.CreateFileModel(fileName);

            ApplicationHelper.PutHistory(pdfModel);



            //创建一个PDFView控件
            //PdfViewer pdfViewer1 = new PdfViewer();
            //设置位置和大小
            //mPdfViewer.Location = new Point(5, 5);
            //mPdfViewer.Size = new Size(200, 300);
            //mPdfViewer.Dock = DockStyle.Fill;
            //mPdfViewer.ShowBookmarks = true;

            ////将控件添加到界面上
            ////this.Controls.Add(mPdfViewer);
            ////加载PDF文档
            //mPdfViewer.Document = PdfDocument.Load(fileName);

        }

        private void PdfForm_SizeChanged(object sender, EventArgs e)
        {
            if (mPdfViewer != null) 
            {
                mPdfViewer.Width = this.Width;
                mPdfViewer.Height = this.Height;
            }
        }
    }
}
