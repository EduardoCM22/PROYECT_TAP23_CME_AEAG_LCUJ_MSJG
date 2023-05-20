using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
     public class Category
    {
        public int CategoryId { get; set; }
        public String CategoryName { get; set; }
        public String Description{ get; set; }

        public Category(int categoryId, String categoryName, String description)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Description = description;
        }
    }
}
