using MagicEsatate_WebApi.Data;
using MagicEsatate_WebApi.Logging;
using MagicEsatate_WebApi.Models;
using MagicEsatate_WebApi.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicEsatate_WebApi.Controllers
{
    //[Route("Api/[controller]")]
    [Route("api/EstateAPI")]
    [ApiController]
    public class EstateAPIController: ControllerBase
    {
        private readonly ILogging _logger;

        public EstateAPIController(ILogging logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        //using ActionResult you define the return type which in this case is EstateDTO
        public ActionResult<IEnumerable<EstateDTO>> GetEstates()
        {
            _logger.Log("Getting all estates", "");
            return Ok( EstateStore.estateList);
            
        }
       
        [HttpGet("{id:int}", Name ="GetEstate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
       // [ProducesResponseType(200, Type = typeof(EstateDTO))]
       
        public ActionResult<EstateDTO> GetEstates(int id)
        {
            if(id ==0)
            {
                _logger.Log("Get Estate Error with Id" + id, "error");
                return BadRequest();
            }
            var estate = EstateStore.estateList.FirstOrDefault(u => u.Id == id);
            if(estate == null)
            {
                return NotFound();
            }
            return Ok(estate);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<EstateDTO> CreateEstate([FromBody]EstateDTO estateDTO)
        {
           /*
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */
           //custom validation
           if(EstateStore.estateList.FirstOrDefault(u => u.Name.ToLower()==estateDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("CustomError", "Estate already Exists!");
                return BadRequest(ModelState);
            }
            if(estateDTO== null)
            {
                return BadRequest(estateDTO);
            }
            if(estateDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            estateDTO.Id = EstateStore.estateList.OrderByDescending(u=>u.Id).FirstOrDefault().Id + 1;
            EstateStore.estateList.Add(estateDTO);
            
            return CreatedAtRoute("GetEstate", new { id = estateDTO.Id }, estateDTO);
        }

        [HttpDelete("{id:int}", Name = "DeleteEstate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEstate(int id)
        {
            //Using IActionResult you do not define the return type
            if(id == 0)
            {
                return BadRequest();
            }
            var estate = EstateStore.estateList.FirstOrDefault(u =>u.Id == id);
            if(estate == null)
            {
                return NotFound();
            }
            EstateStore.estateList.Remove(estate);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateEstate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEstate(int id, [FromBody]EstateDTO estateDTO)

        {
            if(estateDTO == null || id != estateDTO.Id)
            {
                return BadRequest();
            }
            var estate = EstateStore.estateList.FirstOrDefault(u => u.Id == id);
            estate.Name = estateDTO.Name;
            estate.Sqft = estateDTO.Sqft;
            estate.Occupancy = estateDTO.Occupancy;

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialEstate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialEstate(int id, JsonPatchDocument<EstateDTO> patchDTO)
        {
            if(patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var estate = EstateStore.estateList.FirstOrDefault(u => u.Id == id);
            if(estate == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(estate, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
        

    }
}
