using System.ComponentModel.DataAnnotations;

namespace Villa_VillaAPI.Models.DTO
{

  public class UpdateVillaDto
  {

    [Required]
    public int Id { get; set; }
    public string Name { get; set; }

  }

}