namespace RealEstate.API.Dtos.WhoWeAreDtos
{
    public class GetWhoWeAreByIdDto
    {
        public int WhoWeAreID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
