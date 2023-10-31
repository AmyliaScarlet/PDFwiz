using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDFwiz.Entity;
using PDFwiz.Helper;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using WordLib = Microsoft.Office.Interop.Word;
using PDFwiz.Constants;

namespace PDFwiz
{
    public partial class WordForm : Form
    {
        private WordLib.Application myWordApp = null;
        Form parentForm;
        FormCommand formCommand;

        public WordForm(Form mParentForm, FormCommand mFormCommand)
        {
            InitializeComponent();


            parentForm = mParentForm;
            formCommand = mFormCommand;


            if (formCommand.FormCommandType == FormCommandType.Open)
            {
                LoadWordByDocument(formCommand.CommandArgs);
            }
            if (formCommand.FormCommandType == FormCommandType.New)
            {
                CreateWordDocument(formCommand.CommandArgs);
            }


            this.Hide();

        }

        private void CreateWordDocument(string commandArgs)
        {
            string fileName = commandArgs;
            if (myWordApp == null)
                myWordApp = new WordLib.Application();
            Document doc = myWordApp.Documents.Add();
            doc.SaveAs2(FileName: fileName);

            LoadWordByDocument(fileName);

        }



        public void LoadWordByDocument(string fileName)
        {
            if (myWordApp == null)
                myWordApp = new WordLib.Application();

          
            object missing = System.Type.Missing;
            object readOnly = false;
            object confirm = false;

            try
            {
                WordLib.Document wordDoc =
                myWordApp.Documents.Open(fileName, ref confirm, ref readOnly, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing);


                
                //设置修订模式
                //wordDoc.TrackRevisions = true;
                //显示修订模式
                //wordDoc.ShowRevisions = true;

                //WordLib.WdWindowState wsw = myWordApp.ActiveWindow.WindowState;
                //将WORD应用窗口最大化，即设置为最当前
                myWordApp.ActiveWindow.WindowState = WordLib.WdWindowState.wdWindowStateMaximize;

                //关联：文件关闭事件
                myWordApp.DocumentBeforeClose += new WordLib.ApplicationEvents4_DocumentBeforeCloseEventHandler(wordApp_DocumentBeforeClose);
                //关联：文件保存事件
                myWordApp.DocumentBeforeSave += new WordLib.ApplicationEvents4_DocumentBeforeSaveEventHandler(wordApp_DocumentBeforeSave);

                myWordApp.DocumentChange += new WordLib.ApplicationEvents4_DocumentChangeEventHandler(wordApp_DocumentChange);

                ((ApplicationEvents4_Event)myWordApp).NewDocument += new ApplicationEvents4_NewDocumentEventHandler(wordApp_NewDocument);

                myWordApp.DocumentBeforePrint += new WordLib.ApplicationEvents4_DocumentBeforePrintEventHandler(wordApp_DocumentBeforePrint);

                Global.WORD_APP_PATH = myWordApp.Path;
                
                //打开word.exe并显示
                myWordApp.Visible = true;
                myWordApp.StatusBar = "该文档由应用监控中";
                myWordApp.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void wordApp_DocumentBeforePrint(Document Doc, ref bool Cancel)
        {
            

        }

        private void wordApp_NewDocument(Document Doc)
        {
            

        }

        private void wordApp_DocumentChange()
        {
            //NewDocument会先进一次wordApp_DocumentChange

        }

        private void TryQuitWordApplication() 
        {
            //检查，是否需退出word应用
            if (myWordApp != null && myWordApp.Documents != null && myWordApp.Documents.Count == 0)
            {
                myWordApp.Application.Quit();
                myWordApp = null;
            }
        }

        void wordApp_DocumentBeforeClose(WordLib.Document Doc, ref bool Cancel)
        {
            try
            {
                string docPath = Doc.FullName;



                ConvertPdfAndPdfw(docPath, Doc);

                //FileHelper.SavePdfw(FileHelper.ChangeFilePathExt(path,FileType.Pdfw),path);

                

                
            }
            catch (Exception ex)
            {
                string str = string.Format("关闭文档{0}错误,错误信息{1}", Doc.Name, ex.Message);
                MessageBox.Show(str);
            }
            finally {

                TryQuitWordApplication();

                //this.Close();
            }

            
        }
    

        void wordApp_DocumentBeforeSave(WordLib.Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            //文件没有修改过，直接返回
            if (Doc.Saved) return;
            string path = Doc.FullName;
            Doc.Save();

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="docPath"></param>
        /// <param name="Doc"></param>
        private void ConvertPdfAndPdfw(string docPath, Document doc)
        {
            string pdfPath = FileHelper.ChangeFilePathExt(docPath, FileType.Pdf);
            string pdfwPath = FileHelper.ChangeFilePathExt(docPath, FileType.Pdfw);

            FileModel docModel = FileHelper.CreateFileModel(docPath);
            
            bool result = WordToPDFHelper.WordToPDF(docPath, pdfPath,wordApplication:myWordApp,wordDocument: doc);
            if (result) 
            {
                docModel.Stream = FileHelper.ReadFileBytes(docPath);

                FileModel pdfModel = FileHelper.CreateFileModel(pdfPath);
                pdfModel.Stream = FileHelper.ReadFileBytes(pdfPath);

                FileModel pdfwModel = FileHelper.CreatePdfwModel(docModel, pdfModel);
                
                FileHelper.SaveFileModelToFile(pdfwPath, pdfwModel);

                //byte[] pdfwBytes = Encoding.GetEncoding(Global.GET_ENCODING).GetBytes(JsonConvert.SerializeObject(pdfwModel));

                //FileHelper.WriteBytesFile(pdfwBytes, FileHelper.ChangeFilePathExt(docPath, FileType.Pdfw));

            }

            HistoryItem historyItem = new HistoryItem()
            {
                Name = docModel.Name,
                Path = docModel.Path,
                Date = DateTime.Now,
                Image = ApplicationHelper.GetIconFromFile(docModel.FullName)
            };
            AppConfigHelper.GetHistoryList().PutItem(historyItem);

        }


        private void WordForm_SizeChanged(object sender, EventArgs e)
        {
            


        }

     

        protected override void OnClosed(EventArgs e)
        {
            TryQuitWordApplication();

            
            parentForm.Show();
            //base.OnClosed(e);

        }
    }
}
