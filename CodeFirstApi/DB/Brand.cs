using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Brand
    {
        [Key] // Especificamos que BrandID es la primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indicamos que es autoincremental
        public int BrandID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Beer> Beers { get; set; }
    }
}
