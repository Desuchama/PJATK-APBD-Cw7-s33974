using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s33974.Models;

[Table("ComponentTypes")]
public class ComponentTypes
{
	[Key]
	public int Id { get; set; }
	[MaxLength(30)]
	public string Abbreviation { get; set; }
	[MaxLength(300)]
	public string Name { get; set; }

	public IEnumerable<Components> Components { get; set; } = [];
}