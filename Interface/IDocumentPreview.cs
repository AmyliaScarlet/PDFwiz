using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFwiz
{
    //
    // 摘要:
    //     文档预览接口
    public interface IDocumentPreview
    {
        //
        // 摘要:
        //     文档预览
        //
        // 参数:
        //   fileFullName:
        //     文件完整名称(含路径)
        //
        //   dicParam:
        //     自定义参数列表
        void Preview(string fileFullName, Dictionary<string, string> dicParam = null);
    }
}
