namespace BunyCraft.Services.Controllers
{
    using BunnyCraft.Data.Repositories;
    using BunnyCraft.Models;
    using BunyCraft.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Linq.Expressions;
    using BunnyCraft.Data;

    public class AirCraftController : ApiController
    {
        private IBunniesData data;

        public AirCraftController()
            : this(new BunniesData())
        {
        }

        public AirCraftController(IBunniesData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var aircrafts = this.data.Aircrafts.All().Select(AirCraftModel.FromAirCraft);

            return Ok(aircrafts);
        }

        [HttpPost]
        public IHttpActionResult Create(AirCraftModel aircraft)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAircraft = new AirCraft
            {
                Model = aircraft.Model
            };

            this.data.Aircrafts.Add(newAircraft);
            this.data.SaveChanges();

            aircraft.Id = newAircraft.Id;
            //this.aircrafts.Save

            return Ok(aircraft);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AirCraftModel airCraft)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existAirCraft = this.data.Aircrafts.All().FirstOrDefault(a => a.Id == id);

            if (existAirCraft == null)
            {
                return BadRequest("Such aircraft does not exist!");
            }

            existAirCraft.Model = airCraft.Model;
            airCraft.Id = existAirCraft.Id;

            this.data.SaveChanges();

            return Ok(airCraft);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existAirCraft = this.data.Aircrafts.All().FirstOrDefault(a => a.Id == id);

            if (existAirCraft == null)
            {
                return BadRequest("Such aircraft does not exist!");
            }

            this.data.Aircrafts.Delete(existAirCraft);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddBunny(int id, int bunnyId)
        {
            var airCraft = this.data.Aircrafts.All().FirstOrDefault(a => a.Id == id);

            if (airCraft == null)
            {
                return BadRequest("Such aircraft does not exist!");
            }

            var bunny = this.data.Bunnies.All().FirstOrDefault(b => b.Id == bunnyId);

            if (bunny == null)
            {
                return BadRequest("Such bunny does not exist!");
            }

            airCraft.Bunnies.Add(bunny);

            this.data.SaveChanges();

            return Ok();
        }
    }
}
