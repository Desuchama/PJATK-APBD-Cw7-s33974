using System.ComponentModel.DataAnnotations;

namespace PJATK_APBD_Cw7_s33974.DTOs;

public record PCUpdateDto
(
	[Required]
	[MaxLength(50)]
	 string Name,
	 [Required]
	 decimal Weight,
	 [Required]
	 int Warranty,
	 [Required]
	 DateTime CreatedAt,
	 [Required]
	 int Stock
);