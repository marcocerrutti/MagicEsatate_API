using MagicEsatate_WebApi.Models.Dto;

namespace MagicEsatate_WebApi.Data
{
    public static class EstateStore
    {
        public static List<EstateDTO> estateList = new List<EstateDTO>
        {
            new EstateDTO{ Id = 1, Name = "Pool View", Sqft=100, Occupancy=4},
            new EstateDTO{ Id = 2, Name = "Beach View", Sqft=300, Occupancy=3}
        };
    }
}
