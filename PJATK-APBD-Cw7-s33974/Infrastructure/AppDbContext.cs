using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33974.Models;

namespace PJATK_APBD_Cw7_s33974.Infrastructure;

public class AppDbContext(DbContextOptions opt) : DbContext(opt)
{
	public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }
	public DbSet<ComponentTypes> ComponentTypes { get; set; }
	public DbSet<Components> Components { get; set; }
	public DbSet<PCComponents> PCComponents { get; set; }
	public DbSet<PCs> PCs { get; set; }
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<ComponentManufacturers>().HasData(
			[
				new ComponentManufacturers
				{
					Id = 1,
					Abbreviation = "AMD",
					FullName = "Advanced Micro Devices",
					FoundationDate = DateOnly.Parse("1969-05-01"),
				},
				new ComponentManufacturers
				{
					Id = 2,
					Abbreviation = "NV",
					FullName = "NVIDIA Corporation",
					FoundationDate = DateOnly.Parse("1993-04-05"),
				},
				new ComponentManufacturers
				{
					Id = 3,
					Abbreviation = "COR",
					FullName = "Corsair Gaming Inc.",
					FoundationDate = DateOnly.Parse("1994-01-01"),
				}
			]
		);
		modelBuilder.Entity<ComponentTypes>().HasData(
			[
				new ComponentTypes
				{
					Id = 1,
					Abbreviation = "CPU",
					Name = "Processor"
				},
				new ComponentTypes
				{
					Id = 2,
					Abbreviation = "GPU",
					Name = "Graphics Card"
				},
				new ComponentTypes
				{
					Id = 3,
					Abbreviation = "RAM",
					Name = "Memory"
				}
			]
		);
		modelBuilder.Entity<Components>().HasData(
			[
				new Components
				{
					Code = "CPU0000001",
					Name = "Ryzen 7 7800X3D",
					Description = "8-core gaming processor",
					ComponentsManufacturersId = 1,
					ComponentsTypeId = 1
				},
				new Components
				{
					Code = "GPU0000001",
					Name = "RTX 4080 Super",
					Description = "High-end gaming graphics card",
					ComponentsManufacturersId = 2,
					ComponentsTypeId = 2
				},
				new Components
				{
					Code = "RAM0000001",
					Name = "Corsair Vengeance DDR5 16GB",
					Description = "DDR5 RAM module 16GB",
					ComponentsManufacturersId = 3,
					ComponentsTypeId = 3
				}
			]
		);

		modelBuilder.Entity<PCs>().HasData(
			[
				new PCs
				{
					Id = 1,
					Name = "Gaming Beast X",
					Weight = (decimal)12.5,
					Warranty = 36,
					Stock = 5
				},
				new PCs
				{
					Id = 2,
					Name = "Office Mini Pro",
					Weight = (decimal)4.2,
					Warranty = 24,
					Stock = 12
				},
				new PCs
				{
				Id = 3,
				Name = "Gaming Beast XII",
				Weight = (decimal)15.0,
				Warranty = 12,
				Stock = 1
				}
			]
		);
		modelBuilder.Entity<PCComponents>().HasData(
			[
				new PCComponents
				{
					PCId = 1,
					ComponentCode = "CPU0000001",
					Amount = 1
				},
				new PCComponents
				{
					PCId = 1,
					ComponentCode = "GPU0000001",
					Amount = 1
				},
				new PCComponents
				{
					PCId = 1,
					ComponentCode = "RAM0000001",
					Amount = 2
				},
				new PCComponents
				{
					PCId = 2,
					ComponentCode = "RAM0000001",
					Amount = 1
				},
				new PCComponents
				{
					PCId = 3,
					ComponentCode = "RAM0000001",
					Amount = 4
				},
				new PCComponents
				{
					PCId = 3,
					ComponentCode = "CPU0000001",
					Amount = 2
				},
				new PCComponents
				{
					PCId = 3,
					ComponentCode = "GPU0000001",
					Amount = 2
				},
			]
		);
	}
}