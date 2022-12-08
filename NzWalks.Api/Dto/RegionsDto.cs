using NzWalks.Api.Models.Domain;

namespace NzWalks.Api.Dto
{
    public class RegionsDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }


        ////Navigation Property Of One to Many.
        //public IEnumerable<Walk> Walks { get; set; }
    }
}
