using System.Collections.Generic;

namespace WuxiPostal.Models
{
    public class PostalCode
    {
        public string Code { get; set; }

        public IEnumerable<string> Addresses { get; set; }

        public PostalCode(string code = "")
        {
            
        }
    }

    public class PostCodeSearchResult
    {
        public string Code { get; set; }

        public string Address { get; set; }
    }
}
