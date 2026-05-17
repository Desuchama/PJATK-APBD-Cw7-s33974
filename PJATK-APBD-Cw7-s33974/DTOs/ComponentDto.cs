namespace PJATK_APBD_Cw7_s33974.DTOs;

public record ComponentDto
(
	string Code,
	string Name,
	string Description,
	ComponentManufacturersDto? ComponentManufacturersDto,
	ComponentTypesDto? ComponentTypesDto
);