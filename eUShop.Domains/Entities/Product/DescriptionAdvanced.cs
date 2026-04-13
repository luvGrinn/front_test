using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUShop.Domains.Entities.Product
{
    public class DescriptionAdvanced
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int H { get; set; }
        public int W { get; set; }
        public int L { get; set; }
    }
}
