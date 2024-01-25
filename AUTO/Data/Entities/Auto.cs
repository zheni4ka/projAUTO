namespace AUTO.Data.Entities
{
    public class Auto
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int YearRelease { get; set; }
        public int Price { get; set; }
        public int CompanyId { get; set; }
        public string ImgURL { get; set; }
        public Auto() { }

    }
}
