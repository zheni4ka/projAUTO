namespace AUTO.Data.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public IEnumerable<Auto> Autos { get; set; }
        public Company() { }
    }
}
