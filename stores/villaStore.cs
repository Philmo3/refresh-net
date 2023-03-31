using Villa_VillaAPI.Models.DTO;
namespace Villa_VillaAPI.Store
{
  public static class VillaStore
  {
    public static IEnumerable<VillaDTO> getVillas()
    {
      VillaDTO[] villas = {
        new VillaDTO{Id=1, Name="first"},
        new VillaDTO{Id=2, Name="second"},
      };

      return villas;
    }
  }
}