using MagicEsatate_WebApi.Data;
using MagicEsatate_WebApi.Models;
using MagicEsatate_WebApi.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicEsatate_WebApi.Controllers
{
    //[Route("Api/[controller]")]
    [Route("api/EstateAPI")]
    [ApiController]
    public class EstateAPIController: ControllerBase
    {

        private readonly ApplcationDbContext _db;
        public EstateAPIController(ApplcationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        //using ActionResult you define the return type which in this case is EstateDTO
        public ActionResult<IEnumerable<EstateDTO>> GetEstates()
        {
            
            return Ok(_db.Estates);
            
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
                
                return BadRequest();
            }
            var estate = _db.Estates.FirstOrDefault(u => u.Id == id);
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
           if(_db.Estates.FirstOrDefault(u => u.Name.ToLower()==estateDTO.Name.ToLower())!=null)
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

            Estate model = new()
            {
                Amenity= estateDTO.Amenity,
                Details= estateDTO.Details,
                Id= estateDTO.Id,
                ImageUrl = estateDTO.ImageUrl,
                Name= estateDTO.Name,
                Occupancy= estateDTO.Occupancy,
                Rate = estateDTO.Rate,
                Sqft = estateDTO.Sqft
            };
           
            _db.Estates.Add(model);
            _db.SaveChanges();

            
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
            var estate = _db.Estates.FirstOrDefault(u =>u.Id == id);
            if(estate == null)
            {
                return NotFound();
            }
            _db.Estates.Remove(estate);
            _db.SaveChanges();
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
            //var estate = EstateStore.estateList.FirstOrDefault(u => u.Id == id);
            //estate.Name = estateDTO.Name;
            //estate.Sqft = estateDTO.Sqft;
            //estate.Occupancy = estateDTO.Occupancy;

            Estate model = new()
            {
                Amenity = estateDTO.Amenity,
                Details = estateDTO.Details,
                Id = estateDTO.Id,
                ImageUrl = estateDTO.ImageUrl,
                Name = estateDTO.Name,
                Occupancy = estateDTO.Occupancy,
                Rate = estateDTO.Rate,
                Sqft = estateDTO.Sqft
            };
            _db.Estates.Update(model);
            _db.SaveChanges();
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
            var estate = _db.Estates.AsNoTracking().FirstOrDefault(u => u.Id == id);


            EstateDTO estateDTO = new()
            {
                Amenity = estate.Amenity,
                Details = estate.Details,
                Id = estate.Id,
                ImageUrl = estate.ImageUrl,
                Name = estate.Name,
                Occupancy = estate.Occupancy,
                Rate = estate.Rate,
                Sqft = estate.Sqft
            };
            if(estate == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(estateDTO, ModelState);
            Estate model = new Estate()
            {
                Amenity = estateDTO.Amenity,
                Details = estateDTO.Details,
                Id = estateDTO.Id,
                ImageUrl = estateDTO.ImageUrl,
                Name = estateDTO.Name,
                Occupancy = estateDTO.Occupancy,
                Rate = estateDTO.Rate,
                Sqft = estateDTO.Sqft
            };
            _db.Estates.Update(model);
            _db.SaveChanges();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
        

    }
}
