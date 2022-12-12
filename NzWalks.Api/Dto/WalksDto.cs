using NzWalks.Api.Models.Domain;

namespace NzWalks.Api.Dto
{
    public class WalksDto
    {

        public Guid Id{ get; set; }
        public string Name { get; set; }
        public double Length { get; set; }

        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

    }
}
