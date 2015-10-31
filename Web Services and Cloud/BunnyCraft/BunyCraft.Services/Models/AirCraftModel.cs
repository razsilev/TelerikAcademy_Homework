namespace BunyCraft.Services.Models
{
    using BunnyCraft.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Linq.Expressions;

    public class AirCraftModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Model { get; set; }

        public static Expression<Func<AirCraft, AirCraftModel>> FromAirCraft
        { 
            get
            {
                return a => new AirCraftModel
                {
                    Id = a.Id,
                    Model = a.Model
                };
            }
        }
    }
}