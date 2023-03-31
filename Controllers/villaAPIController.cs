using Microsoft.AspNetCore.Mvc;
using Villa_VillaAPI.Models.DTO;
using Villa_VillaAPI.Store;

namespace Villa_VillaAPI.Controllers
{

  [Route("villa")]
  [ApiController]
  public class VillaAPIController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<VillaDTO>> GetVillas()
    {
      return Ok(VillaStore.getVillas());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VillaDTO> GetVilla(int id)
    {
      if (id == 0)
      {
        return BadRequest();
      }

      var villa = VillaStore.getVillas().FirstOrDefault((villa) => villa.Id == id);

      if (villa == null)
      {
        return NotFound("no villas found with this Id");
      }

      return Ok(villa);
    }
  }

}