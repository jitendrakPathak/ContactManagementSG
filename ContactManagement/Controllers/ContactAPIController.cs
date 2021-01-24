using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactManagement.Models;
using ContactManagement.Repository;


namespace ContactManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactAPIController : ControllerBase
    {
        private readonly IAsyncRepository<ContactModel> asyncRepository;

        public ContactAPIController(IAsyncRepository<ContactModel> _asyncRepository)
        {
            asyncRepository = _asyncRepository;
        }

        // GET: api/ContactAPI
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return new JsonResult(await asyncRepository.ListAsync());

        }

        // GET: api/ContactAPI/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult> Get(int id)
        {
            if (id == 0) return BadRequest();
            ContactModel conatct = await asyncRepository.GetByIdAsync(id);

            if (conatct != null) return Ok(conatct);
            
            else return NotFound();
        }

        // POST: api/ContactAPI
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContactModel contact)
        {
            if (contact == null) return BadRequest();

            if (await asyncRepository.AddAsync(contact) > 0) return Ok(true);

            else return NotFound();
        }

        // PUT: api/ContactAPI/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ContactModel contact)
        {
            if (contact == null) return BadRequest();

            if (await asyncRepository.UpdateAsync(contact) > 0) return Ok(true);

            else return NotFound();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();

            if (await asyncRepository.DeleteAsync(id) > 0) return Ok(true);

            else return NotFound();
        }
    }
}
