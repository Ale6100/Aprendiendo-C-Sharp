using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Beer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BeerID { get; set; }
        public string Name { get; set; }
        public int BrandID { get; set; } // En estas tres líneas especificamos que BrandID es una foreing key
        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }
    }
}
