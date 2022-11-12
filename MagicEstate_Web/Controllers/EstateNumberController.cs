using AutoMapper;
using MagicEsatate_Web.Models;
using MagicEsatate_Web.Models.Dto;
using MagicEstate_Web.Services;
using MagicEstate_Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicEstate_Web.Controllers
{
    public class EstateNumberController : Controller
    {
        private readonly IEstateNumberService _estateNumberService;
        private readonly IMapper _mapper;

        public EstateNumberController(IEstateNumberService estateNumberService, IMapper mapper)
        {
            _estateNumberService = estateNumberService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexEstateNumber()
        {
            List<EstateNumberDTO> list = new();

            var response = await _estateNumberService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EstateNumberDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

      

        public async Task<IActionResult> UpdateEstateNumber(int estateId)
        {
            var response = await _estateNumberService.GetAsync<APIResponse>(estateId);
            if (response != null && response.IsSuccess)
            {
                EstateDTO model = JsonConvert.DeserializeObject<EstateDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<EstateUpdateDTO>(model));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEstate(EstateNumberUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _estateNumberService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexEstateNumber));
                }

            }
            return View(model);
        }

        public async Task<IActionResult> DeleteEstateNumber(int estateId)
        {
            var response = await _estateNumberService.GetAsync<APIResponse>(estateId);
            if (response != null && response.IsSuccess)
            {
                EstateNumberDTO model = JsonConvert.DeserializeObject<EstateNumberDTO>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEstateNumber(EstateNumberDTO model)
        {
            var response = await _estateNumberService.DeleteAsync<APIResponse>(model.EstateNo);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexEstateNumber));
            }

            return View(model);
        }
        public async Task<IActionResult> CreateEstateNumber()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEstateNumber(EstateNumberCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _estateNumberService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexEstateNumber));
                }

            }
            return View(model);
        }
    }
}
