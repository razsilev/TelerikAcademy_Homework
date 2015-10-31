using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Http.Cors;
using BugLogger.DataLayer;
using BugLogger.Repositories;

namespace BugLogger.RestApi.Controllers
{
    public class BugsController : ApiController
    {
        private IRepository<Bug> repo;

        public BugsController()
            : this(new DbBugsRepository(new BugLoggerDbContext()))
        {
        }

        public BugsController(IRepository<Bug> repository)
        {
            this.repo = repository;
        }

        [EnableCors("*", "*", "*")]
        public IQueryable<Bug> GetAll()
        {
            var bugs = this.repo.All();
            return bugs;
        }

        public IQueryable<Bug> GetCount(int count)
        {
            return this.GetAll()
                    .Take(count);
        }

        public IQueryable<Bug> GetAfter(DateTime date)
        {
            return this.GetAll()
                    .Where(b => b.LogDate > date);
        }

        public IQueryable<Bug> GetByStatus(Status type)
        {
            return this.GetAll()
                    .Where(b => b.Status == type);
        }

        public HttpResponseMessage PostBug(Bug bug)
        {
            if (string.IsNullOrEmpty(bug.Text))
            {
                var ex = new ArgumentException();
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            bug.LogDate = DateTime.Now;
            bug.Status = Status.Pending;
            this.repo.Add(bug);
            this.repo.Save();

            var response = this.Request.CreateResponse(HttpStatusCode.Created, bug);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = bug.Id }));
            return response;
        }

        public HttpResponseMessage PutBug(int id, Status status)
        {
            var bug = this.repo.All().FirstOrDefault(b => b.Id == id);

            if (bug == null)
            {
                var responseNotFaund = this.Request.CreateResponse(HttpStatusCode.NotFound, id);
                return responseNotFaund;
            }

            bug.Status = status;
            this.repo.Save();

            var response = this.Request.CreateResponse(HttpStatusCode.OK, bug);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = bug.Id }));
            
            return response;
        }
    }
}
