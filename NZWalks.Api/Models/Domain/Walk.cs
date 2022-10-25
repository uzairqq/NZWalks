namespace NZWalks.Api.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }


        public Guid RegionId { get; set; }
        public Guid WalkDifficulty { get; set; }

        //Navigation Properties
        public Region Region { get; set; }
        public WalkDifficulty WalkDifficultyies { get; set; }

    }
}
