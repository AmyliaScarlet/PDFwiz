using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFwiz
{

    public enum FormCommandType
    {
        /// <summary>
        /// 无
        /// </summary>
        None,
        /// <summary>
        /// 打开文档
        /// </summary>
        Open,
        /// <summary>
        /// 新建文档
        /// </summary>
        New,
        /// <summary>
        /// 转化文档
        /// </summary>
        Convert
    }

    public enum FileType
    { 
        Word,
        Excel,
        Pdf,
        Pdfw,
        Icon,
        Other 
    }


    public enum ApplicationState
    { 
        onStart,
        onNew,
        onOpenWord,
        onOpenPdf,
        onOpenPdfw,
        onClose

    }

}
