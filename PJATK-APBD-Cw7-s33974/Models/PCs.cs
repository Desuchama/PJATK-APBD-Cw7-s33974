using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s33974.Models;

[Table("PCs")]
public class PCs
{
	[Key]
	public int Id { get; set; }
	[MaxLength(50)]
	public string Name { get; set; }
	[Column(TypeName = "decimal(5,2)")]
	public decimal Weight { get; set; }
	public int Warranty { get; set; }
	public DateTime CreatedAt { get; set; }
	public int Stock { get; set; }

	public IEnumerable<PCComponents> PCComponents { get; set; } = [];
}