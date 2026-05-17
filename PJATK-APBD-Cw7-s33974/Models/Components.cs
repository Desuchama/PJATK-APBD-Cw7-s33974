using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PJATK_APBD_Cw7_s33974.Models;

[Table("Components")]
public class Components
{
	[Key]
	[Column(TypeName = "char(10)")]
	public string Code { get; set; }
	[MaxLength(300)]
	public string Name { get; set; }
	[MaxLength]
	public string Description { get; set; }
	public int ComponentsManufacturersId { get; set; }
	public int ComponentsTypeId { get; set; }

	[ForeignKey(nameof(ComponentsManufacturersId))]
	public ComponentManufacturers ComponentManufacturers { get; set; } = null!;

	[ForeignKey(nameof(ComponentsTypeId))] public ComponentTypes ComponentTypes { get; set; } = null!;

	public IEnumerable<PCComponents> PCComponents { get; set; } = new List<PCComponents>();
}