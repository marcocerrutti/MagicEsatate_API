using Microsoft.AspNetCore.Mvc;
using static MagicEstate_Utility.SD;

namespace MagicEstate_Web.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string Token { get; set; }
    }
}
