using System.Collections.ObjectModel;

namespace WuxiPostal.Models
{
    public class District
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ObservableCollection<PostalCode> PostalCodes { get; set; }

        public District()
        {
            
        }
    }
}
