using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Dtos.OfferDtos;
using RealEstate.API.Repositories.OfferRepository;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferRepository _offerRepository;

        public OfferController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOffers()
        {
            var offers = await _offerRepository.GetResultOfferAsync();
            return Ok(offers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOffer(int id)
        {
            try
            {
                var offer = await _offerRepository.GetOfferByIdAsync(id);
                return Ok(offer);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid offer ID.");
                }

                _offerRepository.DeleteOfferAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffer(CreateOfferDto offer)
        {
            if (offer == null)
            {
                return BadRequest("Offer cannot be null.");
            }
            try
            {
                _offerRepository.CreateOfferAsync(offer);
                return Ok("Offer created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOffer(UpdateOfferDto offer)
        {
            if (offer == null)
            {
                return BadRequest("Offer cannot be null.");
            }
            try
            {
                _offerRepository.UpdateOfferAsync(offer);
                return Ok("Offer updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
