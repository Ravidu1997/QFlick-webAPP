using Microsoft.EntityFrameworkCore;
using QFlick.Domain.Entities.Client;
using QFlick.Domain.Entities.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Infrastructure.DbContexts
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<QueueDetail> QueueDetail { get; set; }

    }
}
