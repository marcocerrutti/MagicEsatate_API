﻿using AutoMapper;
using MagicEsatate_WebApi.Models;
using MagicEsatate_WebApi.Models.Dto;
using MagicEsatate_WebApi.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace MagicEsatate_WebApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/EstateNumberAPI")]
    [ApiController]
    [ApiVersion("1.0")]
    //[ApiVersion("1.0", Deprecated =true)]

    public class EstateNumberAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IEstateRepository _dbEstate;
        private readonly IMapper _mapper;
        private readonly IEstateNumberRepository _dbEstateNumber;

        public EstateNumberAPIController(IEstateNumberRepository dbEstateNumber, IEstateRepository dbEstate, IMapper mapper)
        {
            _dbEstateNumber = dbEstateNumber;
            _dbEstate = dbEstate;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet("GetString")]
        public IEnumerable<string> Get()
        {
            return new string[] { "string1", "string2" };
        }



        [HttpGet]
        //[MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        //using ActionResult you define the return type which in this case is EstateDTO
        public async Task<ActionResult<APIResponse>> GetEstateNumbers()
        {
            try
            {


                IEnumerable<EstateNumber> estateNumberList = await _dbEstateNumber.GetAllAsync(includeProperties: "Estate");
                _response.Result = _mapper.Map<List<EstateNumberDTO>>(estateNumberList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpGet("{id:int}", Name = "GetEstateNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetEstateNumber(int id)
        {
            try
            {


                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var estateNumber = await _dbEstateNumber.GetAsync(u => u.EstateNo == id);
                if (estateNumber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<EstateNumberDTO>(estateNumber);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<APIResponse>> CreateEstateNumber([FromBody] EstateNumberCreateDTO createDTO)
        {
            try
            {


                /*
                 if(!ModelState.IsValid)
                 {
                     return BadRequest(ModelState);
                 }
                 */
                //custom validation
                if (await _dbEstateNumber.GetAsync(u => u.EstateNo == createDTO.EstateNo) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Estate Number already Exists!");
                    return BadRequest(ModelState);
                }
                if (await _dbEstate.GetAsync(u => u.Id == createDTO.EstateID) == null)
                {
                    ModelState.AddModelError("CustomError", "Estate ID is Invalid");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                //create the conversion
                EstateNumber estateNumber = _mapper.Map<EstateNumber>(createDTO);

                await _dbEstateNumber.CreateAsync(estateNumber);
                _response.Result = _mapper.Map<EstateNumberDTO>(estateNumber);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetEstate", new { id = estateNumber.EstateNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id:int}", Name = "DeleteEstateNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteEstateNumber(int id)
        {
            try
            {


                //Using IActionResult you do not define the return type
                if (id == 0)
                {
                    return BadRequest();
                }
                var estateNumber = await _dbEstateNumber.GetAsync(u => u.EstateNo == id);
                if (estateNumber == null)
                {
                    return NotFound();
                }
                await _dbEstateNumber.RemoveAsync(estateNumber);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id:int}", Name = "UpdateEstateNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateEstateNumber(int id, [FromBody] EstateNumberUpdateDTO updateDTO)
        {
            try
            {


                if (updateDTO == null || id != updateDTO.EstateNo)
                {
                    return BadRequest();
                }

                if (await _dbEstate.GetAsync(u => u.Id == updateDTO.EstateID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Estate ID is Invalid");
                    return BadRequest(ModelState);
                }

                EstateNumber model = _mapper.Map<EstateNumber>(updateDTO);

                await _dbEstateNumber.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        /*
        [HttpPatch("{id:int}", Name = "UpdatePartialEstateNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialEstate(int id, JsonPatchDocument<EstateNumberUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var estateNumber = await _dbEstateNumber.GetAsync(u => u.EstateNo == id, tracked: false);

            EstateUpdateDTO estateDTO = _mapper.Map<EstateUpdateDTO>(estateNumber);

           

            if (estateNumber == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(estateDTO, ModelState);
            EstateNumber model = _mapper.Map<EstateNumber>(estateDTO);


            await _dbEstateNumber.UpdateAsync(estateNumber);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
        */

    }
}
