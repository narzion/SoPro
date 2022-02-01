using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class BookmarkVM
    {
        public int ID { get; set; }

        public string URL { get; set; }

        public string ShortDescription { get; set; }

        public int? CategoryId { get; set; }

        public CategoryVM Category { get; set; }

        public List<CategoryVM> Categories { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
