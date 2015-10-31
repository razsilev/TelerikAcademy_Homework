namespace BunyCraft.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using BunnyCraft.Models;

    public class BynnyOutPutModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Health { get; set; }

        public int? AirCraftId { get; set; }

        public ColorType ColorType { get; set; }
    }
}