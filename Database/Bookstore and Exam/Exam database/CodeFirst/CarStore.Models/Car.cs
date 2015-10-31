namespace CarStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Car
    {
        public int CarID { get; set; }

        [Required]
        [StringLength(20)]
        public string Model { get; set; }

        [Required]
        public TransmitionType Transmission { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int DealerID { get; set; }

        [Required]
        public virtual Dealer Dealer { get; set; }

        [Required]
        public int ManufacturerID { get; set; }

        [Required]
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
