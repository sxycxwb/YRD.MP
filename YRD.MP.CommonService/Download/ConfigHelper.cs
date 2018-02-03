using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using System.Web;
using YRD.MP.CommonService.Utilities;
using YRD.MP.CommonService.Download;

namespace YRD.MP.CommonServic.Download
{
    public class ConfigHelper
    {
        //Key：guid，Value：<QrCodeId,Version>
        public static Dictionary<string, CodeRecord> CodeCollection = new Dictionary<string, CodeRecord>(StringComparer.OrdinalIgnoreCase);
        public static object Lock = new object();


#if NET45
        private HttpContextBase _context;

        public ConfigHelper(HttpContextBase context)
        {
            _context = context;
        }
#else
        private HttpContext _context;

        public ConfigHelper(HttpContext context)
        {
            _context = context;
        }
#endif

        private string GetDatabaseFilePath()
        {
#if NET45
            return _context.Server.MapPath("~/App_Data/Document/Config.xml");
#else
            return Server.GetMapPath("~/App_Data/Document/Config.xml");

#endif
        }

        private XDocument GetXDocument()
        {
            var doc = XDocument.Load(GetDatabaseFilePath());
            return doc;
        }

        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Config GetConfig()
        {
            var doc = GetXDocument();
            var config = new Config()
            {
                QrCodeId = int.Parse(doc.Root.Element("QrCodeId").Value),
                DownloadCount = int.Parse(doc.Root.Element("DownloadCount").Value),
                Versions = doc.Root.Element("Versions").Elements("Version").Select(z => z.Value).ToList(),
                WebVersions = doc.Root.Element("WebVersions").Elements("Version").Select(z => z.Value).ToList()
            };
            return config;
        }

        /// <summary>
        /// 获取一个二维码场景标示（自增，唯一）
        /// </summary>
        /// <returns></returns>
        public int GetQrCodeId()
        {
            lock (Lock)
            {
                var config = GetConfig();
                config.QrCodeId++;
                Save(config);
                return config.QrCodeId;
            }
        }

        public void Save(Config config)
        {
            var doc = GetXDocument();
            doc.Root.Element("QrCodeId").Value = config.QrCodeId.ToString();
            doc.Root.Element("DownloadCount").Value = config.DownloadCount.ToString();
            doc.Root.Element("Versions").Elements().Remove();
            foreach (var version in config.Versions)
            {
                doc.Root.Element("Versions").Add(new XElement("Version", version));
            }
            doc.Save(GetDatabaseFilePath());

        }

        public string Download(string version,bool isWebVersion)
        {
            lock (Lock)
            {
                var config = GetConfig();
                config.DownloadCount++;
                Save(config);
            }

            return _context.Server.MapPath(string.Format("~/App_Data/Document/Files/Senparc.Weixin{0}-v{1}.rar",isWebVersion?"-Web":"", version));
        }
    }
}
