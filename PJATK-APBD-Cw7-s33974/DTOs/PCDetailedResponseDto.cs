using PJATK_APBD_Cw7_s33974.Models;

namespace PJATK_APBD_Cw7_s33974.DTOs;

public record PCDetailedResponseDto
(
	int Id,
	string Name,
	decimal Weight,
	int Warranty,
	DateTime CreatedAt,
	int Stock,
	IEnumerable<PCComponentsDto>? ComponentsDtos
);