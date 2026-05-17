using PJATK_APBD_Cw7_s33974.DTOs;

namespace PJATK_APBD_Cw7_s33974.Services;

public interface IPCsService
{
	Task<IEnumerable<PCResponseDto>> GetAllAsync();
	Task<PCDetailedResponseDto> GetByIdAsync(int id);
	Task<PCResponseDto> AddAsync(PCUpdateDto request);
	Task UpdateAsync(int id, PCUpdateDto request);
	Task DeleteAsync(int id);
}