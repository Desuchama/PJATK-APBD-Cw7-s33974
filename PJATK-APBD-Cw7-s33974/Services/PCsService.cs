using PJATK_APBD_Cw7_s33974.DTOs;
using PJATK_APBD_Cw7_s33974.Infrastructure;

namespace PJATK_APBD_Cw7_s33974.Services;

public class PCsService(AppDbContext ctx) : IPCsService
{
	public Task<IEnumerable<PCResponseDto>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<PCDetailedResponseDto> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<PCResponseDto> AddAsync(PCUpdateDto request)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(int id, PCUpdateDto request)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}
}