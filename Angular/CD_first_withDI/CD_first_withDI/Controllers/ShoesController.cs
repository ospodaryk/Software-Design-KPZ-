using CD_first_withDI.CustomerData;
using CD_first_withDI.Models;
using CD_first_withDI.ShoesData;
using CD_first_withDI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CD_first_withDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
            private IShoesData shoesdata;
            public ShoesController(IShoesData data)
            {
                shoesdata = data;
            }

            [HttpGet]
            [Route("api/[controller]")]
            public IActionResult GetPairofShoesList()
            {
                return Ok(shoesdata.GetPairofShoesList());
            }


            [HttpPost]
            [Route("api/[controller]")]
            public IActionResult AddShoes(ShoesViewModel customer)
            {
                shoesdata.AddShoes(customer);

                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                    HttpContext.Request.Path + '/' + customer.IdShoes, customer);
            }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetShoes(int id)
        {
            var employee = shoesdata.GetShoes(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Shoes with id {id} was not found");
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteShoes(int id)
        {
            var cus = shoesdata.GetShoes(id);
            if (cus != null)
            {
                shoesdata.DeleteShoes(id);
                return Ok();
            }
            return NotFound($"Cannot find the shoes with Id: {id}");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditShoes(int id, ShoesViewModel customer)
        {
            var cus = shoesdata.GetShoes(id);
            if (cus != null)
            {
                customer.IdShoes = cus.IdShoes;
                var cust = shoesdata.EditShoes(customer);
                return Ok(cust);
            }
            return NotFound($"Cannot find the shoes with Id: {id}");
        }
    }
}
