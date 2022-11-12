using MagicEsatate_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

    namespace MagicEstate_Web.Models.VM
    {
        public class EstateNumberCreateVM
        {
            public EstateNumberCreateVM()
            {
                EstateNumber = new EstateNumberCreateDTO();
            }

            public EstateNumberCreateDTO EstateNumber { get; set; }
            [ValidateNever]
            public IEnumerable<SelectListItem> EstateList { get; set; }
        }
    }

