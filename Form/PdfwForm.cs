﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDFwiz.Entity;
using PDFwiz.Helper;
using PDFwiz.Properties;
using PDFwiz.Constants;
using PDFwiz.Customize;

namespace PDFwiz
{
    public partial class PdfwForm : Form
    {
        Form parentForm;

        public PdfwForm(Form mParentForm, FormCommand mFormCommand)
        {
            InitializeComponent();
            FormComm.Instance.AddListenner(this.Name, this);
            ApplicationStateMachine.Instance.NextState(ApplicationState.onOpenPdfw);
            parentForm = mParentForm;
            parentForm.Hide();
            if (mFormCommand.FormCommandType == FormCommandType.Open)
            {
        
                //LoadPdfwByDocument(mFormCommand.CommandArgs);

                string pdfwPath = mFormCommand.CommandArgs;
                string pdfPath = FileHelper.ChangeFilePathExt(pdfwPath, FileType.Pdf);
                string docPath = FileHelper.ChangeFilePathExt(pdfwPath, FileType.Word);

                FileModel pdfwModel = FileHelper.ReadFileToFileModel(pdfwPath);
                pdfwModel.Name = Path.GetFileName(pdfwPath);
                pdfwModel.FullName = pdfwPath;
                pdfwModel.Path = Path.GetDirectoryName(pdfwPath);

                string sDicJson = JsonConvert.SerializeObject(pdfwModel.AccessoryObject);

                Dictionary<string, FileModel> dic = JsonConvert.DeserializeObject<Dictionary<string, FileModel>>(sDicJson);
                FileModel pdfModel = dic[Global.PdfDoc];


                //FileHelper.WriteBytesFile(docBytes, docPath);

                //WordToPDFHelper.WordToPDF(docPath, pdfPath);

                ApplicationHelper.PutHistory(pdfwModel);

                mPdfViewer.LoadFromStream(DataHelper.BytesToStream(pdfModel.Stream));
            }



        }

        /// <summary>
        /// 暂时停用
        /// </summary>
        /// <param name="fileName"></param>
        private void LoadPdfwByDocument(string fileName)
        {
            byte[] pdfwBytes = FileHelper.ReadFileBytes(fileName);
            FileModel pdfwModel = JsonConvert.DeserializeObject<FileModel>(Encoding.GetEncoding(Global.GET_ENCODING).GetString(pdfwBytes));
            Dictionary<string, FileModel> dic = pdfwModel.AccessoryObject as Dictionary<string, FileModel>;

            FileModel pdfModel = dic["Org_PdfDoc"];

            byte[] pdfBytes = pdfModel.Stream;
            string pdfPath = FileHelper.ChangeFilePathExt(fileName, FileType.Pdf);
            FileHelper.WriteBytesFile(pdfBytes, pdfPath);

            mPdfViewer.LoadFromFile(fileName);
        }


        protected override void OnClosed(EventArgs e)
        {
            this.SizeChanged -= PdfwForm_SizeChanged;

            //parentForm.Show();

            ApplicationStateMachine.Instance.NextState();

            base.OnClosed(e);

            FormComm.Instance.SendMessage("", "", "ApplicationExit");
        }

        private void ucBtnEdit_BtnClick(object sender, EventArgs e)
        {

        }

        private void PdfwForm_SizeChanged(object sender, EventArgs e)
        {
            if (mPdfViewer != null) 
            {
                mPdfViewer.Width = this.Width;
                mPdfViewer.Height = this.Height - ucBtnEdit.Height;

            }
        }
    }
}
