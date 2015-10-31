namespace Template.Data
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Repositories;
using Template.Models;

    public interface ITemplateData
    {
        IRepository<User> Users { get; }

        // Add other entitis from database
        //IRepository<User> Games { get; set; }

        int SaveChanges();
    }
}
