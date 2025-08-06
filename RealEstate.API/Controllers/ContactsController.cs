using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Dtos.ContactDtos;
using RealEstate.API.Repositories.ContactRepository;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _contactRepository.GetContactsAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpGet("GetLastFourContact")]
        public async Task<IActionResult> GetLastFourContacts()
        {
            var contacts = await _contactRepository.GetLast4Contact();
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactDto contactDto)
        {
            if (contactDto == null)
            {
                return BadRequest("Contact cannot be null");
            }
            _contactRepository.CeateContact(contactDto);
            return Ok("Contact created successfully");
        }
    }
}
