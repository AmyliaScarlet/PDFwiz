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
            historyItems.Add(item);

            AppConfigHelper.SetHistoryList(historyItems);
        }
    }
}
