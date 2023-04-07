using System.Reflection;
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

    [HttpPost]
    public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
    {
      if (villaDTO == null)
      {
        return BadRequest(villaDTO);
      }

      if (VillaStore.getVillas().Find(villa => villa.Name.ToLower() == villaDTO.Name.ToLower()) != null)
      {
        ModelState.AddModelError("message", "Villa already exist");
        return BadRequest(ModelState);
      }

      return VillaStore.Create(villaDTO);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteVilla(int id)
    {

      var villa = VillaStore.getVillas().Find(villa => villa.Id == id);

      if (villa == null)
      {
        return NotFound("the villa you are trying to delete does not exist");
      }

      VillaStore.getVillas().Remove(villa);

      return NoContent();
    }

    [HttpPatch("{id:int}")]
    public IActionResult patchVilla(int id, [FromBody] UpdateVillaDto patchVilla)
    {

      if (id != patchVilla.Id)
      {
        return BadRequest("you are trying to update the wrong villa");
      }

      VillaDTO villa = VillaStore.getVillas().FirstOrDefault(villa => villa.Id == id);

      if (villa == null)
      {
        return NotFound("could not found the villa");
      }

      foreach (PropertyInfo prop in patchVilla.GetType().GetProperties())
      {

        var newValue = patchVilla.GetType().GetProperty(prop.Name).GetValue(patchVilla);

        if (newValue != null)
        {
          villa[prop.Name] = newValue;
        }

      }

      return Ok(villa);
    }
  }

}