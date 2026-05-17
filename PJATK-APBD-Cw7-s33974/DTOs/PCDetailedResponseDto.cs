using PJATK_APBD_Cw7_s33974.Models;

namespace PJATK_APBD_Cw7_s33974.DTOs;

public class PCDetailedResponseDto
{
	public int id { get; set; }
	public string Name { get; set; }
	public decimal Weight { get; set; }
	public int Warranty { get; set; }
	public DateTime CreatedAt { get; set; }
	public int Stock { get; set; }

	public IEnumerable<PCComponentsDto> PCComponentsDtos { get; set; } = [];
}