using System.ComponentModel.DataAnnotations;

namespace CRUDOperationsWebAPI.Models
{
    public class EmpDetails
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
