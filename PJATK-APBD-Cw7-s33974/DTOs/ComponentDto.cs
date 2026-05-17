namespace PJATK_APBD_Cw7_s33974.DTOs;

public class ComponentDto
{
	public string Code { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public ComponentManufacturersDto ComponentManufacturersDto { get; set; }
	public ComponentTypesDto ComponentTypesDto { get; set; }
}