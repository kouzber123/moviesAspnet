using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tomtest.Data.DTOs.CharacterDTOs
{
  public class UpdateCharacterDto
  {
    public string FullName { get; set; }
    public string Alias { get; set; }
    public string Gender { get; set; }
    public string PictureUrl { get; set; }
  }
}