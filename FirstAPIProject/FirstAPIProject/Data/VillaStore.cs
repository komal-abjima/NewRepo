using FirstAPIProject.Models.Dto;

namespace FirstAPIProject.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto> {
            new VillaDto {Id=1, Name = "Pool View", Occupacy=3, sqft=2 },
            new VillaDto {Id=2, Name="Beach View", Occupacy=4, sqft=1 }
    };
   }
}
