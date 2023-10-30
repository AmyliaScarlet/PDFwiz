using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFwiz
{
    public class Global
    {
        /// <summary>
        /// WORD文档应用路径
        /// </summary>
        public static string WORD_APP_PATH = "";

        /// <summary>
        /// PDF文档应用路径
        /// </summary>
        public static string PDF_APP_PATH = "";

        /// <summary>
        /// 本应用可执行程序路径
        /// </summary>
        public static string ExecutablePath = System.Windows.Forms.Application.ExecutablePath;
        /// <summary>
        /// 本应用可执行程序路径 不包括文件名
        /// </summary>
        public static string StartupPath = System.Windows.Forms.Application.StartupPath;
        /// <summary>
        /// 左侧补0数字的总长度
        /// </summary>
        public static int ZERO_PADDING_LENTH = 10;
        /// <summary>
        /// 转换编码
        /// </summary>
        public static string GET_ENCODING = "utf-8";
        /// <summary>
        /// 分隔符
        /// </summary>
        public static byte[] SPLITE_BYTES = Encoding.GetEncoding(GET_ENCODING).GetBytes("这是一个分隔符");

        public static byte[] KEY_64 = { 19, 77, 12, 02, 19, 76, 06, 03 };

        public static byte[] IV_64 = { 19, 76, 06, 03, 19, 77, 12, 02 };

        public static string Org_EditableDoc = "Org_EditableDoc";
        public static string EditableDoc = "EditableDoc";
        public static string PdfDoc = "PdfDoc";

    }
}
