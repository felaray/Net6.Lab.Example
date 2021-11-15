namespace Net6.Lab.Example.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
