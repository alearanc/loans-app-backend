namespace API.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateOnly CreationDate { get; set; }
        public virtual ICollection<Thing> Things { get; } = new HashSet<Thing>();
    }
}
