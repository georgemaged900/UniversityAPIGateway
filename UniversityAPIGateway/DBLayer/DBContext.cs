using System.Data.Entity;
using UniversityAPIGateway.Models;

namespace UniversityAPIGateway.DBLayer
{
    public class DBContext : DbContext
    {
        public DbSet<Student> students { get; set; }
    }
}
