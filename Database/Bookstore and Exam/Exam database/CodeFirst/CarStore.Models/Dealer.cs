namespace CarStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Dealer
    {
        private ICollection<City> citys;

        public Dealer()
        {
            this.citys = new HashSet<City>();
        }

        public int DealerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public virtual ICollection<City> Citys 
        { 
            get
            {
                return this.citys;
            }

            set
            {
                this.citys = value;
            }
        }
    }
}
