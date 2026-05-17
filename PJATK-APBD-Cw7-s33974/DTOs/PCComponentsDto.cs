namespace PJATK_APBD_Cw7_s33974.DTOs;

public class PCComponentsDto
{
	public int PCId { get; set; }
	public IEnumerable<ComponentDto> Components { get; set; } = [];
}