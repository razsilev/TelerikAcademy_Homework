namespace StudentSystem.WebApi.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;

    using StudentSystem.Data;
    using StudentSystem.Models;

    public class HomeworkController : ApiController
    {
        private StudentSystemDbContext db = new StudentSystemDbContext();

        // GET: api/Homework
        public IQueryable<Homework> GetHomework()
        {
            return db.Homework;
        }

        // GET: api/Homework/5
        [ResponseType(typeof(Homework))]
        public IHttpActionResult GetHomework(int id)
        {
            Homework homework = db.Homework.Find(id);
            if (homework == null)
            {
                return NotFound();
            }

            return Ok(homework);
        }

        // PUT: api/Homework/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHomework(int id, Homework homework)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != homework.Id)
            {
                return BadRequest();
            }

            db.Entry(homework).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeworkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Homework
        [ResponseType(typeof(Homework))]
        public IHttpActionResult PostHomework(Homework homework)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Homework.Add(homework);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = homework.Id }, homework);
        }

        // DELETE: api/Homework/5
        [ResponseType(typeof(Homework))]
        public IHttpActionResult DeleteHomework(int id)
        {
            Homework homework = db.Homework.Find(id);
            if (homework == null)
            {
                return NotFound();
            }

            db.Homework.Remove(homework);
            db.SaveChanges();

            return Ok(homework);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HomeworkExists(int id)
        {
            return db.Homework.Count(e => e.Id == id) > 0;
        }
    }
}