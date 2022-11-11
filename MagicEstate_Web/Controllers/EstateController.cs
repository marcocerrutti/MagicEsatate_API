﻿using AutoMapper;
using MagicEsatate_Web.Models;
using MagicEsatate_Web.Models.Dto;
using MagicEstate_Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace MagicEstate_Web.Controllers
{
    public class EstateController : Controller
    {

        private readonly IEstateService _estateService;
        private readonly IMapper _mapper;

        public EstateController(IEstateService estateService, IMapper mapper)
        {
            _estateService = estateService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexEstate()
        {
            List<EstateDTO> list = new();

            var response = await _estateService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EstateDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> CreateEstate()
        {
           
            return View();
        }

        public async Task<IActionResult> UpdateEstate(int estateId)
        {
            var response = await _estateService.GetAsync<APIResponse>(estateId);
            if (response != null && response.IsSuccess)
            {
                EstateDTO model = JsonConvert.DeserializeObject<EstateDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<EstateUpdateDTO>(model));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEstate(EstateUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _estateService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexEstate));
                }

            }
            return View(model);
        }

        public async Task<IActionResult> DeleteEstate(int estateId)
        {
            var response = await _estateService.GetAsync<APIResponse>(estateId);
            if (response != null && response.IsSuccess)
            {
                EstateDTO model = JsonConvert.DeserializeObject<EstateDTO>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEstate(EstateDTO model)
        {
                var response = await _estateService.DeleteAsync<APIResponse>(model.Id);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexEstate));
                }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEstate(EstateCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _estateService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexEstate));
                }
               
            }
            return View(model);
        }

     
    }
}