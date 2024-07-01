using CRUDOperationsWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUDOperationsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUD_API_Controller : ControllerBase
    {
        private readonly ApplicationContext _context;
        public CRUD_API_Controller(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetDetails")]
        public IActionResult GetDetails()
        {
            var Info = _context.EmployeeData.ToList();
            return Ok(Info);
        }

        [HttpGet]
        [Route("GetDetailsById")]
        public IActionResult GetDetailsById(int id)
        {
            var Info = _context.EmployeeData.FirstOrDefault(x => x.Id == id);
            return Ok(Info);
        }

        [HttpPost]
        [Route("CreateDetails")]
        public IActionResult CreateDetails(EmpDetails data)
        {
            var Info = _context.EmployeeData.Add(data);
            _context.SaveChanges();
            return Ok("successfully created!");
        }

        [HttpPut]
        [Route("EditDetails")]
        public IActionResult EditDetailsById(EmpDetails data, int id)
        {
            var Details = _context.EmployeeData.Where(x => x.Id == id).FirstOrDefault();
            if (Details == null)
            {
                return NotFound();
            };
            Details.Name = data.Name;
            Details.Address = data.Address;

            _context.SaveChanges();
            return Ok("successfully Updated!");
        }

        //Product prodItem = DbContext.Products.Where(p => p.ProductId == productItem.ProductId).FirstOrDefault();
        //    if (prodItem != null)
        //    {
        //        prodItem.ProductName = productItem.ProductName;
        //        prodItem.Quantity = productItem.Quantity;
        //        prodItem.Price = productItem.Price;
        //        DbContext.SaveChanges();
        //    }


        [HttpDelete]
        [Route("DeleteDetailsById")]
        public IActionResult DeleteDetailsById(int id)
        {
            var Info = _context.EmployeeData.FirstOrDefault(x => x.Id == id);
            _context.EmployeeData.Remove(Info);
            _context.SaveChanges();
            return Ok("successfully Deleted!");
        }
    }
}

