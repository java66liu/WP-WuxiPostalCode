using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using MVVMSidekick.Utilities;
using WuxiPostal.Models;

namespace WuxiPostal.Repository
{
    public class WuXiPostalContext
    {
        #region Singleton

        private static volatile WuXiPostalContext _instance;
        private static readonly object ObjLock = new Object();

        private WuXiPostalContext()
        {
            InitData();
        }

        public static WuXiPostalContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (ObjLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new WuXiPostalContext();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion

        public IEnumerable<District> Districts { get; set; }

        public IEnumerable<PostalCode> PostalCodes { get; set; }

        private void InitData()
        {
            string districtsXml = GetXmlFromEmbeddedResourceAsync("WuxiPostal.Data.Districts.xml");
            var districtsDoc = XDocument.Parse(districtsXml);

            string postalcodeXml = GetXmlFromEmbeddedResourceAsync("WuxiPostal.Data.PostalCodes.xml");
            var postalcodeDoc = XDocument.Parse(postalcodeXml);


            var postCodes = from p in postalcodeDoc.Descendants("PostalCode")
                            select new PostalCode()
                            {
                                Code = (string)p.Attribute("Code"),
                                Addresses = from a in p.Descendants("Address")
                                            select (string)a.Attribute("Info")
                            };

            PostalCodes = postCodes.ToList();

            var districts = from p in districtsDoc.Descendants("District")
                            select new District()
                            {
                                Id = (string)p.Attribute("Id"),
                                Name = (string)p.Attribute("Name"),
                                PostalCodes = this.PostalCodes.Where(pc => p.Descendants("PostalCodeRefernce")
                                                                            .Attributes("PostalCode")
                                                                            .Any(a => (string)a == pc.Code))
                                                              .ToObservableCollection()
                            };

            Districts = districts.ToList();
        }

        private string GetXmlFromEmbeddedResourceAsync(string resource)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(resource);

            if (stream == null)
            {
                throw new FileNotFoundException("Could not find embedded mappings resource file.", resource);
            }

            var reader = new StreamReader(stream);
            string s = reader.ReadToEnd();
            return s;
        }
    }
}
