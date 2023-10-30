using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFwiz.Entity
{
    [Serializable]
    public class FileModel
    {
        private string _name;
        private string _shortName;
        private string _path;
        private string _fullName;
        private string _ext;
        private FileType _type;
        private byte[] _stream;
        private bool _bOriginal;
        private DateTime _createDate;
        private DateTime _updateDate;
        private object _accessoryObject;

        /// <summary>
        /// 文件名 带后缀
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 文件名 不带后缀
        /// </summary>
        public string ShortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { _path = value != null ? value.Replace("\\", "/"):""; }
        }
        /// <summary>
        /// 文件路径 + 文件名
        /// </summary>
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value != null ? value.Replace("\\", "/") : ""; }
        }
        /// <summary>
        /// 扩展名
        /// </summary>
        public string Ext
        {
            get { return _ext; }
            set { _ext = value; }
        }
        /// <summary>
        /// 文件类型
        /// </summary>
        public FileType Type
        {
            get
            {
                switch (this.Ext)
                {
                    case ".doc":
                        return FileType.Word;
                    case ".docx":
                        return FileType.Word;
                    case ".xls":
                        return FileType.Excel;
                    case ".xlsx":
                        return FileType.Excel;
                    case ".pdf":
                        return FileType.Pdf;
                    case ".pdfw":
                        return FileType.Pdfw;
                    default:
                        return FileType.Other;
                }
            }
        }
        /// <summary>
        /// 文件流数据
        /// </summary>
        public byte[] Stream
        {
            get { return _stream; }
            set { _stream = value; }
        }
        /// <summary>
        /// 是否原始件
        /// </summary>
        public bool bOriginal
        {
            get { return _bOriginal; }
            set { _bOriginal = value; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        /// <summary>
        /// 最近更新日期
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
        /// <summary>
        /// 与实体相关的对象
        /// </summary>
        public object AccessoryObject
        {
            get { return _accessoryObject; }
            set { _accessoryObject = value; }
        }


        // override object.Equals
        public override bool Equals(object obj)
        {
            return obj is FileModel fileModel &&
                    _fullName == fileModel.FullName;
        }
    }
}
