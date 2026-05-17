using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_s33974.DTOs;
using PJATK_APBD_Cw7_s33974.Exceptions;
using PJATK_APBD_Cw7_s33974.Services;

namespace PJATK_APBD_Cw7_s33974.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PCsController(IPCsService service) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		return Ok(await service.GetAllAsync());
	}
    
	[HttpGet("{id:int}/components")]
	public async Task<IActionResult> GetById([FromRoute] int id)
	{
		try
		{
			return Ok(await service.GetByIdAsync(id));
		}
		catch (NotFoundException e)
		{
			return NotFound(e.Message);
		}
	}
    
	[HttpPost]
	public async Task<IActionResult> Add([FromBody] PCUpdateDto request)
	{
		var pcResponseDto = await service.AddAsync(request);
		return CreatedAtAction(nameof(GetById), new { id = pcResponseDto.Id }, pcResponseDto);
	}
    
	[HttpPut("{id:int}")]
	public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PCUpdateDto request)
	{
		try
		{
			await service.UpdateAsync(id, request);
			return NoContent();
		}
		catch (NotFoundException e)
		{
			return NotFound(e.Message);
		}
	}
    
	[HttpDelete("{id:int}")]
	public async Task<IActionResult> Delete([FromRoute] int id)
	{
		try
		{
			await service.DeleteAsync(id);
			return NoContent();
		}
		catch (NotFoundException e)
		{
			return NotFound(e.Message);
		}
	}

}