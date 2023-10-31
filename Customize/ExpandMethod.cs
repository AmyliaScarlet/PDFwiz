using PDFwiz.Entity;
using PDFwiz.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PDFwiz.Constants
{
    internal static class ExpandMethod
    {
        internal static void PutItem(this List<HistoryItem> historyItems, HistoryItem item)
        {
            UniqueList<HistoryItem> uHistoryItems = new UniqueList<HistoryItem>(historyItems,5);
            uHistoryItems.Add(item);
   
            AppConfigHelper.SetHistoryList(uHistoryItems.ToList());
        }

        internal static void AddToMax<T>(this List<T> list, T item, int maxNum)
        {
            if (list.Count < maxNum)
            {
                list.Add(item);
            }
            else
            {
                list.RemoveAt(0);
                list.Add(item);
            }
        }

        internal static string Encode2String(this byte[] data)
        {
            return Encoding.GetEncoding(Global.GET_ENCODING).GetString(data);
        }
        internal static byte[] Encode2Bytes(this string data)
        {
            return Encoding.GetEncoding(Global.GET_ENCODING).GetBytes(data);
        }
    }
}
