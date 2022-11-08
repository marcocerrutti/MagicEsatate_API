using MagicEsatate_Web.Models;
using MagicEstate_Web.Models;

namespace MagicEstate_Web.Services.IService
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest aPIRequest);
    }
}
