using AutoMapper;
using MagicEsatate_Web.Models;
using MagicEsatate_Web.Models.Dto;
using MagicEstate_Web.Models.VM;
using MagicEstate_Web.Services;
using MagicEstate_Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MagicEstate_Web.Controllers
{
    public class EstateNumberController : Controller
    {
        private readonly IEstateNumberService _estateNumberService;
        private readonly IEstateService _estateService;
        private readonly IMapper _mapper;

        public EstateNumberController(IEstateNumberService estateNumberService, IMapper mapper, IEstateService estateService)
        {
            _estateNumberService = estateNumberService;
            _estateService= estateService;  
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
            EstateNumberCreateVM estateNumberVM = new();
            var response = await _estateService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                estateNumberVM.EstateList = JsonConvert.DeserializeObject<List<EstateDTO>>
                    (Convert.ToString(response.Result)).Select(i=> new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
            }
            return View(estateNumberVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEstateNumber(EstateNumberCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _estateNumberService.CreateAsync<APIResponse>(model.EstateNumber);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexEstateNumber));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }

            }
            
            var resp = await _estateService.GetAllAsync<APIResponse>();
            if(resp != null && resp.IsSuccess)
            {
                model.EstateList = JsonConvert.DeserializeObject<List<EstateDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
           
            return View(model);
        }
    }
}
