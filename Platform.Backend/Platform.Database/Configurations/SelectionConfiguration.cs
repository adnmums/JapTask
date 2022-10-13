using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platform.Core.Entities;

namespace Platform.Database.Configurations
{
    public class SelectionConfiguration : IEntityTypeConfiguration<Selection>
    {
        public void Configure(EntityTypeBuilder<Selection> builder)
        {
            builder.HasData(
                new Selection
                {
                   Id = Guid.Parse("4c2b95e0-2022-4a8f-b537-eb3a32786b06"),
                   Title = "Selection Curabitur",
                   StartDate = new DateTime(2022-13-01),
                   EndDate = new DateTime(2023-13-01),
                   Status = SelectionStatus.Active,
                   ProgramId = Guid.Parse("b950ddf5-e9ad-47ff-9d2a-57259014fae6")
                });
        }
    }
}
