using Villa_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Villa_VillaAPI.Store
{
  public static class VillaStore
  {

    private static List<VillaDTO> villaStore = new List<VillaDTO>{
      new VillaDTO{Id=1, Name="first"},
      new VillaDTO{Id=2, Name="second"},
    };
    public static List<VillaDTO> getVillas()
    {
      return villaStore;
    }

    public static ActionResult<VillaDTO> Create(VillaDTO villaDto)
    {
      villaDto.Id = villaStore.Last().Id + 1;

      villaStore.Add(villaDto);

      return villaDto;
    }
  }
}