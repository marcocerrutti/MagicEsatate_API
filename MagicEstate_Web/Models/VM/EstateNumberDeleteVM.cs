using MagicEsatate_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicEstate_Web.Models.VM
{
    public class EstateNumberDeleteVM
    {
        public EstateNumberDeleteVM()
        {
            EstateNumber = new EstateNumberDTO();
        }

        public EstateNumberDTO EstateNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> EstateList { get; set; }
    }
}

