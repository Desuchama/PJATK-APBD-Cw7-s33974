using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33974.DTOs;
using PJATK_APBD_Cw7_s33974.Exceptions;
using PJATK_APBD_Cw7_s33974.Infrastructure;
using PJATK_APBD_Cw7_s33974.Models;

namespace PJATK_APBD_Cw7_s33974.Services;

public class PCsService(AppDbContext ctx) : IPCsService
{
	
	public async Task<IEnumerable<PCResponseDto>> GetAllAsync()
	{
		return await ctx.PCs.Select(pc => new PCResponseDto(
			pc.Id,
			pc.Name,
			pc.Weight,
			pc.Warranty,
			pc.CreatedAt,
			pc.Stock
		)).ToListAsync();
	}

	public async Task<PCDetailedResponseDto> GetByIdAsync(int id)
	{
		return await ctx.PCs
			       .Where(pc => pc.Id == id)
			       .Select(pc => new PCDetailedResponseDto(
				       pc.Id,
				       pc.Name,
				       pc.Weight,
				       pc.Warranty,
				       pc.CreatedAt,
				       pc.Stock,
				       pc.PCComponents.Select(pcom => new PCComponentsDto(
					       pcom.Amount,
					       new ComponentDto(
						       pcom.Components.Code,
						       pcom.Components.Name,
						       pcom.Components.Description,
						       new ComponentManufacturersDto(
                                   pcom.Components.ComponentManufacturers.Id,
                                   pcom.Components.ComponentManufacturers.Abbreviation,
                                   pcom.Components.ComponentManufacturers.FullName,
                                   pcom.Components.ComponentManufacturers.FoundationDate
	                            ),
						       new ComponentTypesDto(
							       pcom.Components.ComponentTypes.Id,
							       pcom.Components.ComponentTypes.Abbreviation,
							       pcom.Components.ComponentTypes.Name
							    )
					       )
				       ))
					       .ToList()
				       )
			       )
			       .FirstOrDefaultAsync()
			  //      .Where(pc => pc.Id == id)
					// .Select(pc => new PCDetailedResponseDto(
					// 	 pc.Id,
					// 	 pc.Name,
					// 	 pc.Weight,
					// 	 pc.Warranty,
					// 	 pc.CreatedAt,
					// 	 pc.Stock,
				 //        ctx.PCComponents
					//         .Where(pcom => pcom.PCId == pc.Id)
					//         .Select(pcom => new PCComponentsDto(
					//         pcom.Amount,
					//         ctx.Components.Select(com => new ComponentDto(
					// 			 com.Code,
					// 			 com.Name,
					// 			 com.Description,
					// 			 ctx.ComponentManufacturers
					// 			 	.Where(man => man.Id == com.ComponentsManufacturersId)
					// 			 	.Select(man => new ComponentManufacturersDto(
					// 			 		   man.Id,
					// 			 		   man.Abbreviation,
					// 			 		   man.FullName,
					// 			 		   man.FoundationDate
					// 			 		)
					// 			 	)
					// 			 .FirstOrDefault(),
					// 			 ctx.ComponentTypes
					// 			 	.Where(typ => typ.Id == com.ComponentsTypeId)
					// 			 	.Select(typ => new ComponentTypesDto(
					// 			 			typ.Id,
					// 			 		    typ.Abbreviation,
					// 			 		    typ.Name
					// 			 		)
					// 			 	)
					// 			 .FirstOrDefault()
					// 	)))).ToList()
			  //  )).FirstOrDefaultAsync()
		       ?? throw new NotFoundException($"PC with ID {id} not found");
	}

	public async Task<PCResponseDto> AddAsync(PCUpdateDto request)
	{
		var pc = new PCs
		{
			Name = request.Name,
			Weight = request.Weight,
			Warranty = request.Warranty,
			CreatedAt = request.CreatedAt,
			Stock = request.Stock
		};
		ctx.PCs.Add(pc);
		await ctx.SaveChangesAsync();

		return new PCResponseDto(
			pc.Id,
			pc.Name,
			pc.Weight,
			pc.Warranty,
			pc.CreatedAt,
			pc.Stock);
	}

	public async Task UpdateAsync(int id, PCUpdateDto request)
	{
		int affectedRows = await ctx.PCs.Where(pc => pc.Id == id)
			.ExecuteUpdateAsync(set => set
				.SetProperty(pc => pc.Name, request.Name)
				.SetProperty(pc => pc.Weight, request.Weight)
				.SetProperty(pc => pc.Warranty, request.Warranty)
				.SetProperty(pc => pc.CreatedAt, request.CreatedAt)
				.SetProperty(pc => pc.Stock, request.Stock)
			);
		if (affectedRows == 0)
			throw new NotFoundException($"PC with ID {id} not found");
	}

	public async Task DeleteAsync(int id)
	{
		int affectedRows = await ctx.PCs
			.Where(pc => pc.Id == id)
			.ExecuteDeleteAsync();
        
		if (affectedRows == 0)
			throw new NotFoundException($"PC with ID {id} not found");
	}
}