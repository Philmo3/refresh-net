using System.ComponentModel.DataAnnotations;

namespace Villa_VillaAPI.Models
{

  public class Villa
  {
    public int Id { get; set; }

    public string Name { get; set; }
    public DateTime CreatedDateTime { get; set; }
  }

}