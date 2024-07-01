using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CRUDOperationsWebAPI.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options):base(options)
        
        { 
        }
        public DbSet<EmpDetails> EmployeeData { get; set; }   
    }
}
