using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PDFwiz.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDFwiz.Helper
{
    internal static class AppConfigHelper
    {
        /// <summary>  
        /// 写入值，增加的内容写在appSettings段下 
        /// </summary>  
        /// <param name="key">key值</param>  
        /// <param name="value">value值</param>  
        internal static void Appconfig_SetValue(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件   
        }

        /// <summary>  
        /// 读取指定key的值  
        /// </summary>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        internal static string Appconfig_GetValue(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[key] == null)
                return "";
            else
                return config.AppSettings.Settings[key].Value;
        }

        internal static void SetHistoryList(List<HistoryItem> historyItems)
        {
            string key = "historyItems";
            JsonCloneSettings j = new JsonCloneSettings();

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string json = JsonConvert.SerializeObject(historyItems, settings);

            string value = DataHelper.GetDESEncrypt(json);

            Appconfig_SetValue(key, value);
        }

        internal static List<HistoryItem> GetHistoryList()
        {
            string key = "historyItems";
            
            string value = Appconfig_GetValue(key);

            if (string.IsNullOrEmpty(value)) 
            {
                return new List<HistoryItem>();
            }

            string json = DataHelper.GetDESDecrypt(value);

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            List<HistoryItem> historyItems = JsonConvert.DeserializeObject<List<HistoryItem>>(json, settings);

            return historyItems;
        }
    }
}
