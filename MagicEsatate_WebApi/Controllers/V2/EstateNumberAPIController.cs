using AutoMapper;
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

namespace MagicEsatate_WebApi.Controllers.V2
{
    [Route("api/v{version:apiVersion}/EstateNumberAPI")]
    [ApiController]
    [ApiVersion("2.0")]
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
        //[MapToApiVersion("2.0")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Uche", "Dotnet" };
        }




    }
}
