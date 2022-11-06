using AutoMapper;
using MagicEsatate_WebApi.Data;
using MagicEsatate_WebApi.Models;
using MagicEsatate_WebApi.Models.Dto;
using MagicEsatate_WebApi.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly IMapper _mapper;
        private readonly IEstateRepository _dbEstate;
        public EstateAPIController(IEstateRepository dbEstate, IMapper mapper)
        {
            _dbEstate = dbEstate;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        //using ActionResult you define the return type which in this case is EstateDTO
        public async Task<ActionResult<IEnumerable<EstateDTO>>> GetEstates()
        {
            IEnumerable<Estate> estateList = await _dbEstate.GetAllAsync();
            return Ok(_mapper.Map<List<EstateDTO>>(estateList));
            
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
            var estate = await _dbEstate.GetAsync(u => u.Id == id);
            if(estate == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EstateDTO>(estate));

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<EstateDTO>> CreateEstate([FromBody]EstateCreateDTO createDTO)
        {
           /*
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */
           //custom validation
           if(await _dbEstate.GetAsync(u => u.Name.ToLower()== createDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("CustomError", "Estate already Exists!");
                return BadRequest(ModelState);
            }
            if(createDTO== null)
            {
                return BadRequest(createDTO);
            }
            /*
            if(estateDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            */
            //create the conversion
            Estate model = _mapper.Map<Estate>(createDTO);

            //Estate model = new()
            //{
            //    Amenity= createDTO.Amenity,
            //    Details= createDTO.Details,
            //    ImageUrl = createDTO.ImageUrl,
            //    Name= createDTO.Name,
            //    Occupancy= createDTO.Occupancy,
            //    Rate = createDTO.Rate,
            //    Sqft = createDTO.Sqft
            //};
           
            await _dbEstate.CreateAsync(model);

            
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
            var estate =await _dbEstate.GetAsync(u =>u.Id == id);
            if(estate == null)
            {
                return NotFound();
            }
            await _dbEstate.RemoveAsync(estate);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateEstate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEstate(int id, [FromBody]EstateUpdateDTO updateDTO)

        {
            if(updateDTO == null || id != updateDTO.Id)
            {
                return BadRequest();
            }
            //var estate = EstateStore.estateList.FirstOrDefault(u => u.Id == id);
            //estate.Name = estateDTO.Name;
            //estate.Sqft = estateDTO.Sqft;
            //estate.Occupancy = estateDTO.Occupancy;


            Estate model = _mapper.Map<Estate>(updateDTO);
            //Estate model = new()
            //{
            //    Amenity = updateDTO.Amenity,
            //    Details = updateDTO.Details,
            //    Id = updateDTO.Id,
            //    ImageUrl = updateDTO.ImageUrl,
            //    Name = updateDTO.Name,
            //    Occupancy = updateDTO.Occupancy,
            //    Rate = updateDTO.Rate,
            //    Sqft = updateDTO.Sqft
            //};
            await _dbEstate.UpdateAsync(model);
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
            var estate = await _dbEstate.GetAsync(u => u.Id == id, tracked:false);

            EstateUpdateDTO estateDTO = _mapper.Map<EstateUpdateDTO>(estate);
            
            //EstateUpdateDTO estateDTO = new()
            //{
            //    Amenity = estate.Amenity,
            //    Details = estate.Details,
            //    Id = estate.Id,
            //    ImageUrl = estate.ImageUrl,
            //    Name = estate.Name,
            //    Occupancy = estate.Occupancy,
            //    Rate = estate.Rate,
            //    Sqft = estate.Sqft
            //};

            if(estate == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(estateDTO, ModelState);
            Estate model = _mapper.Map<Estate>(estateDTO);

            //Estate model = new Estate()
            //{
            //    Amenity = estateDTO.Amenity,
            //    Details = estateDTO.Details,
            //    Id = estateDTO.Id,
            //    ImageUrl = estateDTO.ImageUrl,
            //    Name = estateDTO.Name,
            //    Occupancy = estateDTO.Occupancy,
            //    Rate = estateDTO.Rate,
            //    Sqft = estateDTO.Sqft
            //};

            await _dbEstate.UpdateAsync(model);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
        

    }
}
