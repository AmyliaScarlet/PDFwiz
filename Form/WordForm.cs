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
using PDFwiz.Customize;
using HZH_Controls;
using System.Runtime.InteropServices;

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
            FormComm.Instance.AddListenner(this.Name, this);

            parentForm = mParentForm;
            formCommand = mFormCommand;

            parentForm.Hide();

            if (formCommand.FormCommandType == FormCommandType.Open)
            {
                ApplicationStateMachine.Instance.NextState(ApplicationState.onOpenWord);
                LoadWordByDocument(formCommand.CommandArgs);
            }
            if (formCommand.FormCommandType == FormCommandType.New)
            {
                ApplicationStateMachine.Instance.NextState(ApplicationState.onNew);
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

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            int msg = m.Msg;
            switch (msg) 
            {
                case Global.WndProc_Comm_HideWindow:
                    this.Hide();
                    break;
                case Global.WndProc_Comm_CloseWindow:
                    this.Close();
                    break;


            }
            base.WndProc(ref m);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Hide();
        }

        /// <summary>
        /// 发送消息到指定窗口
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄。如果此参数为HWND_BROADCAST，则消息将被发送到系统中所有顶层窗口，
        /// 包括无效或不可见的非自身拥有的窗口、被覆盖的窗口和弹出式窗口，但消息不被发送到子窗口</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(int hWnd, int msg, IntPtr wParam, IntPtr lParam);//窗口句柄、、

        /// <summary>
        /// 获取窗体句柄
        /// </summary>
        /// <param name="lpClassName">指向一个指定了类名的空结束字符串，或一个标识类名字符串的成员的指针。假设该參数为一个成员，
        /// 则它必须为前次调用theGlobafAddAtom函数产生的全局成员。该成员为16位，必须位于IpClassName的低 16位，高位必须为 0</param>
        /// <param name="lpWindowName">指向一个指定了窗体名（窗体标题）的空结束字符串。假设该參数为空，则为全部窗体全匹配</param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);

        

        public void mSendMassage(int nMessage) 
        {
            int WINDOW_HANDLER = FindWindow(null, this.Name);
            if (WINDOW_HANDLER == 0)
            {
                throw new Exception("Could not find Main window!");//找不到主窗口
            }
            long result = SendMessage(WINDOW_HANDLER, nMessage, new IntPtr(0), new IntPtr(301)).ToInt64();

        }

        void wordApp_DocumentBeforeClose(WordLib.Document Doc, ref bool Cancel)
        {
            mSendMassage(Global.WndProc_Comm_HideWindow);
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
                mSendMassage(Global.WndProc_Comm_CloseWindow);
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

            ApplicationHelper.PutHistory(docModel);

        }


        private void WordForm_SizeChanged(object sender, EventArgs e)
        {
            


        }


     

        protected override void OnClosed(EventArgs e)
        {
            TryQuitWordApplication();

            
            //parentForm.Show();


            ApplicationStateMachine.Instance.NextState();
           
            base.OnClosed(e);

        }
    }
}
