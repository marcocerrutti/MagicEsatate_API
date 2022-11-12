using AutoMapper;
using MagicEsatate_Web.Models;
using MagicEsatate_Web.Models.Dto;
using MagicEstate_Web.Models;
using MagicEstate_Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MagicEstate_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEstateService _estateService;
        private readonly IMapper _mapper;

        public HomeController(IEstateService estateService, IMapper mapper)
        {
            _estateService = estateService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<EstateDTO> list = new();

            var response = await _estateService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EstateDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

    }
}