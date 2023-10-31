using Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PDFwiz.Entity;
using static System.Windows.Forms.AxHost;
using PDFwiz.Constants;

namespace PDFwiz.Helper
{
    public static class FileHelper
    {
        public static FileModel CreateFileModel(string filename) 
        {

            FileModel fileModel = new FileModel();
            fileModel.bOriginal = true;
            fileModel.CreateDate = DateTime.Now;
            fileModel.FullName = filename;
            fileModel.Path = Path.GetDirectoryName(filename); //获取文件路径
            fileModel.Name = Path.GetFileName(filename); //获取文件名
            fileModel.Ext = Path.GetExtension(filename); //获取文件扩展名
            fileModel.ShortName = Path.GetFileNameWithoutExtension(filename);

            return fileModel;
        }

        /// <summary>
        /// 移动文件到指定位置
        /// </summary>
        /// <param name="oldPath">原文件位置+文件名(例如E:\TEST\1.txt)</param>
        /// <param name="newPath">移动文件位置+文件名(例如E:\TEST\File\1.txt)</param>
        internal static void MoveFile(string oldPath, string newPath)
        {
            string path = Path.GetDirectoryName(newPath);
            try
            {
                //判断移动的文件夹是否存在,不存在则创建
                if (Directory.Exists(path))
                {
                    //先删除再移动
                    File.Delete(newPath);
                    File.Move(oldPath, newPath);
                    Console.WriteLine(oldPath + "文件成功移动到" + newPath);
                }
                else
                {
                    Directory.CreateDirectory(path);
                    File.Move(oldPath, newPath);
                    Console.WriteLine(oldPath + "文件成功移动到" + newPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("文件移动失败:" + ex.ToString());
            }
        }

        internal static void RenameFile(string sourceFile, string newName) 
        {
            try
            {
                FileSystem.RenameFile(sourceFile, newName);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        internal static string ChangeFilePathExt(string path, FileType fileType)
        {
            string ext = "";
            switch (fileType)
            {
                case FileType.Word:
                    ext = "docx";
                    break;
                case FileType.Excel:
                    ext = "xlsx";
                    break;
                case FileType.Pdf:
                    ext = "pdf";
                    break;
                case FileType.Pdfw:
                    ext = "pdfw";
                    break;
                case FileType.Icon:
                    ext = "ico";
                    break;
                default:
                    break;
            }
            string rpath = Path.GetDirectoryName(path) + "/" + Path.GetFileNameWithoutExtension(path) + "." + ext;
            return rpath.Replace("\\","/");
        }

        internal static FileModel CreatePdfwModel(FileModel fileModel, FileModel pdfModel)
        {
            FileModel pdfwModel = new FileModel();
            pdfwModel.Name = fileModel.ShortName;
            pdfwModel.CreateDate = DateTime.Now;
            pdfwModel.bOriginal = fileModel.bOriginal;
            pdfwModel.Ext = "pdfw";

            Dictionary<string,FileModel> dic = new Dictionary<string,FileModel>();

            if (fileModel.bOriginal) 
            {
                dic.Add(Global.Org_EditableDoc, fileModel);
            }
            dic.Add(Global.EditableDoc, fileModel);
            dic.Add(Global.PdfDoc, pdfModel);

            pdfwModel.AccessoryObject = dic;

            return pdfwModel;
        }

        internal static void WriteBytesFile(byte[] pdfwBytes, string path)
        {
            FileStream fileStream = new FileStream(path,FileMode.Create);
            using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
            {
                binaryWriter.Write(pdfwBytes);
            }

          
        }
        internal static byte[] ReadFileBytes(string filename)
        {
            byte[] buffer;
            using (FileStream fsRead = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (BinaryReader binaryReader = new BinaryReader(fsRead))
                {

                    buffer = binaryReader.ReadBytes((int)fsRead.Length);

                }
            }
            return buffer;
        }


        internal static void SavePdfw(string savePath, string docPath) 
        {
            using (BinaryWriter bBinaryWriter = new BinaryWriter(File.Open(savePath, FileMode.Create)))
            {
                FileModel file = FileHelper.CreateFileModel(docPath);
                string json1 = JsonConvert.SerializeObject(file);
                byte[] jsonbytes = Encoding.GetEncoding(Global.GET_ENCODING).GetBytes(json1);

                int llen = jsonbytes.Length;

                bBinaryWriter.Write(DataHelper.GetZeroPaddingStr(llen.ToString(), Global.ZERO_PADDING_LENTH));
                bBinaryWriter.Write(jsonbytes);

                byte[] bb = FileHelper.ReadFileBytes(docPath);
                bBinaryWriter.Write(bb);

            }
        }



        internal static byte[] ReadPdfw(string savePath, ref FileModel fileModel)
        {
            byte[] bytes = FileHelper.ReadFileBytes(savePath);
            int indexs = DataHelper.GetZeroPaddingNum(Encoding.GetEncoding(Global.GET_ENCODING).GetString(bytes.Skip(1).Take(Global.ZERO_PADDING_LENTH).ToArray()));

            byte[] jbytes = bytes.Skip(Global.ZERO_PADDING_LENTH + 1).Take(indexs).ToArray();
            string json = Encoding.GetEncoding(Global.GET_ENCODING).GetString(jbytes);

            fileModel = JsonConvert.DeserializeObject<FileModel>(json);

            byte[] fbytes = bytes.Skip(indexs + Global.ZERO_PADDING_LENTH + 1).ToArray();

            return fbytes;
        }

        internal static void SaveFileModelToFile(string savePath, FileModel fileModel)
        {
            string json = JsonConvert.SerializeObject(fileModel);

            using (FileStream fileStream = new FileStream(savePath, FileMode.Create))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    json = DataHelper.GetDESEncrypt(json);
                    byte[] b1 = DataHelper.CompressBytes(json.Encode2Bytes());
                    binaryWriter.Write(b1);
                }
            }
        }
        internal static FileModel ReadFileToFileModel(string savePath)
        {
            string json = "";
            FileModel fileModel;
            using (FileStream fileStream = new FileStream(savePath, FileMode.Open))
            {
                using (BinaryReader binaryReader = new BinaryReader(fileStream))
                {
                    byte[] b1 = binaryReader.ReadBytes((int)fileStream.Length);

                    json = DataHelper.DecompressBytes(b1).Encode2String();

                    json = DataHelper.GetDESDecrypt(json);
                }
            }

            fileModel = JsonConvert.DeserializeObject<FileModel>(json);

            return fileModel;
        }
    }
}
