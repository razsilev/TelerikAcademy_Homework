namespace CarStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class City
    {
        public int CityID { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [StringLength(11)]
        //[MaxLength(11)]
        public string Name { get; set; }
    }
}
