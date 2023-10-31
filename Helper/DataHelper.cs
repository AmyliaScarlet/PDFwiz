using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Reflection;
using System.Data;

namespace PDFwiz.Helper
{
    public static class DataHelper
    {
        /// <summary>
        /// List泛型转换DataTable.
        /// </summary>
        public static DataTable ModelsToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }
            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                tb.Rows.Add(values);
            }
            return tb;
        }
        /// <summary>
        /// 如果类型可空，则返回基础类型，否则返回类型
        /// </summary>
        private static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        /// <summary>
        /// 指定类型是否可为空
        /// </summary>
        private static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// 压缩字节数组
        /// </summary>
        /// <param name="str"></param>
        public static byte[] CompressBytes(byte[] inputBytes)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                using (GZipStream zipStream = new GZipStream(outStream, CompressionMode.Compress, true))
                {
                    zipStream.Write(inputBytes, 0, inputBytes.Length);
                    zipStream.Close();
                    return outStream.ToArray();
                }
            }
        }

        /// <summary>
        /// 解压缩字节数组
        /// </summary>
        /// <param name="str"></param>
        public static byte[] DecompressBytes(byte[] inputBytes)
        {

            using (MemoryStream inputStream = new MemoryStream(inputBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (GZipStream zipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        zipStream.CopyTo(outStream);
                        zipStream.Close();
                        return outStream.ToArray();
                    }
                }

            }
        }


        /// <summary>
        /// 返回源序列中首个与指定匹配序列相同的子序列后的第一个字节在源序列中的索引，没有匹配返回-1
        /// </summary>
        /// <param name="source">源序列</param>
        /// <param name="match">匹配序列</param>
        /// <returns></returns>
        public static int IndexAfter(IEnumerable<byte> source, IEnumerable<byte> match)
        {
            if (null == source || null == match)
                throw new ArgumentNullException();

            if (false == source.Any() || false == match.Any())
                throw new ArgumentException("源序列与匹配序列都须包含数据");

            int sLen = source.Count(), mLen = match.Count();
            if (sLen < mLen)
                throw new ArgumentException("匹配序列长度大于源序列长度");

            bool matched = false;
            int idx = 0, offset = 0;
            var lst = source.ToList();
            while (sLen - offset >= mLen)
            {
                idx = lst.IndexOf(match.ElementAt(0), offset);

                if (-1 == idx)
                    break;

                if (sLen - idx >= mLen)
                {
                    matched = true;
                    for (int jdx = 1; jdx < mLen; jdx++)
                    {
                        if (source.ElementAt(idx + jdx) != match.ElementAt(jdx))
                        {
                            matched = false;
                            break;
                        }
                    }

                    if (false == matched)
                        offset = idx + 1;
                    else
                        break;
                }
                else
                    break;
            }

            return matched ? (idx + mLen) : -1;
        }
        /// <summary>
        /// 结构体转byte数组
        /// </summary>
        /// <param name="data">数据对象</param>
        /// <param name="_type">数据类型</param>
        /// <returns></returns>
        public static byte[] StructToBytes(object data, Type _type)
        {
            //计算对象长度
            int iAryLen = Marshal.SizeOf(_type);
            //根据长度定义一个数组
            byte[] databytes = new byte[iAryLen];

            //在非托管内存中分配一段iAryLen大小的空间
            IntPtr ptr = Marshal.AllocHGlobal(iAryLen);
            //将托管内存的东西发送给非托管内存上
            Marshal.StructureToPtr(data, ptr, true);
            //将bytes组数Copy到Ptr对应的空间中
            Marshal.Copy(ptr, databytes, 0, iAryLen);
            //释放非托管内存
            Marshal.FreeHGlobal(ptr);
            return databytes;
        }
        /// <summary>
        /// byte数组转结构体
        /// </summary>
        /// <param>byte数组</param>
        /// <param>结构体类型</param>
        /// <returns>转换后的结构体</returns>
        public static object BytesToStuct(byte[] bytes, Type type)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(type);
            //byte数组长度小于结构体的大小
            if (size > bytes.Length)
            {
                //返回空
                return null;
            }
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回结构体
            return obj;
        }
        /// <summary>
        /// 将一个object对象序列化，返回一个byte[]
        /// </summary>
        /// <param name="obj">能序列化的对象</param>
        /// <returns></returns>
        public static byte[] ObjectToBytes(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Position = 0;
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                return ms.GetBuffer();
            }
        }

        /// <summary>
        /// 将一个序列化后的byte[]数组还原
        /// </summary>
        /// <param name="Bytes"></param>
        /// <returns></returns>
        public static object BytesToObject(byte[] Bytes)
        {
            using (MemoryStream ms = new MemoryStream(Bytes))
            {
                IFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(ms);
            }
        }

        public static string GetZeroPaddingStr(string numStr, int len)
        {
            while (numStr.Length < len)
            {
                numStr = "0" + numStr;
            }
            return numStr;
        }
        public static int GetZeroPaddingNum(string paddedStr)
        {
            return Convert.ToInt32(paddedStr);
        }
        public static String GetDESEncrypt(String value)
        {
            if (value != "")
            {
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(Global.KEY_64, Global.IV_64), CryptoStreamMode.Write);
                StreamWriter sw = new StreamWriter(cs);
                sw.Write(value);
                sw.Flush();
                cs.FlushFinalBlock();
                ms.Flush();

                string s = Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
                return s;
            }
            return "-1";
        }

        public static String GetDESDecrypt(String value)
        {
            try
            {

                if (value != "")
                {
                    DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

                    //从字符串转换为字节组

                    byte[] buffer = Convert.FromBase64String(value);

                    MemoryStream ms = new MemoryStream(buffer);

                    CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(Global.KEY_64, Global.IV_64), CryptoStreamMode.Read);

                    StreamReader sr = new StreamReader(cs);

                    string s = sr.ReadToEnd();
                    return s;

                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

            return "-1";

        }
        /// <summary> 
        /// 将 Stream 转成 byte[] 
        /// </summary> 
        public static byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始 
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// <summary> 
        /// 将 byte[] 转成 Stream 
        /// </summary> 
        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        } 
    }
}
