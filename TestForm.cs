using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDFwiz.Entity;
using PDFwiz.Helper;

namespace PDFwiz
{
    public partial class TestForm : Form
    {
        public TestForm(string[] args)
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str = "{qweq:\"qwqwqwqwqwqwqwqwqwqwqqwqw\"}";

            String str2 = "dh8329yhr8279ry12heui1e1";
            byte[] b1 = Encoding.GetEncoding(Global.GET_ENCODING).GetBytes(str2);
            byte[] b2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string spath = @"C:\cc.pdfw";
            string dpath = @"C:\cc.docx";


            //FileHelper.SavePdfw(spath,dpath);

            //FileModel fileModel1 = new FileModel();
            //byte[] bb = FileHelper.ReadPdfw(spath, ref fileModel1);


            //    string content = Encoding.UTF8.GetString(bytes);

            //    textBox1.Text = content;
            //}


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
