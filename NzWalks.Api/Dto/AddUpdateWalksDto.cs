namespace NzWalks.Api.Dto
{
    public class AddUpdateWalksDto
    {
        public string Name { get; set; }
        public double Length { get; set; }

        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
    }
}
