using MagicEsatate_WebApi.Data;
using MagicEsatate_WebApi.Models;
using MagicEsatate_WebApi.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



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
        public async Task<ActionResult<IEnumerable<EstateDTO>>> GetEstates()
        {
            
            return Ok(await _db.Estates.ToListAsync());
            
        }
       
        [HttpGet("{id:int}", Name ="GetEstate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
       // [ProducesResponseType(200, Type = typeof(EstateDTO))]
       
        public async Task<ActionResult<EstateDTO>> GetEstates(int id)
        {
            if(id ==0)
            {
                
                return BadRequest();
            }
            var estate = await _db.Estates.FirstOrDefaultAsync(u => u.Id == id);
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

        public async Task<ActionResult<EstateDTO>> CreateEstate([FromBody]EstateCreateDTO estateDTO)
        {
           /*
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */
           //custom validation
           if(await _db.Estates.FirstOrDefaultAsync(u => u.Name.ToLower()==estateDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("CustomError", "Estate already Exists!");
                return BadRequest(ModelState);
            }
            if(estateDTO== null)
            {
                return BadRequest(estateDTO);
            }
            /*
            if(estateDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            */

            Estate model = new()
            {
                Amenity= estateDTO.Amenity,
                Details= estateDTO.Details,
                ImageUrl = estateDTO.ImageUrl,
                Name= estateDTO.Name,
                Occupancy= estateDTO.Occupancy,
                Rate = estateDTO.Rate,
                Sqft = estateDTO.Sqft
            };
           
            await _db.Estates.AddAsync(model);
            await _db.SaveChangesAsync();

            
            return CreatedAtRoute("GetEstate", new { id = model.Id }, model);
        }

        [HttpDelete("{id:int}", Name = "DeleteEstate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEstate(int id)
        {
            //Using IActionResult you do not define the return type
            if(id == 0)
            {
                return BadRequest();
            }
            var estate =await _db.Estates.FirstOrDefaultAsync(u =>u.Id == id);
            if(estate == null)
            {
                return NotFound();
            }
             _db.Estates.Remove(estate);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateEstate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEstate(int id, [FromBody]EstateUpdateDTO estateDTO)

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
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialEstate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialEstate(int id, JsonPatchDocument<EstateUpdateDTO> patchDTO)
        {
            if(patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var estate = await _db.Estates.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);


            EstateUpdateDTO estateDTO = new()
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
            await _db.SaveChangesAsync();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
        

    }
}
