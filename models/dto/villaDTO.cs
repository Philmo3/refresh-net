using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace Villa_VillaAPI.Models.DTO
{
  public class VillaDTO
  {
    public int Id { get; set; }

    [Required]
    [MaxLength(45)]
    public string Name { get; set; }

    public object this[string propertyName]
    {
      get
      {
        Type villaDTO = typeof(VillaDTO);
        PropertyInfo property = villaDTO.GetProperty(propertyName);

        if (property != null)
        {
          return property.GetValue(this, null);
        }

        return null;
      }
      set
      {
        Type villaDTO = typeof(VillaDTO);
        PropertyInfo property = villaDTO.GetProperty(propertyName);

        if (property != null)
        {
          property.SetValue(this, value, null);
        }
      }
    }
  }
}