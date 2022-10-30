namespace AspNetCoreDI.Models
{
    public class Repository
    {
        public Repository()
        {
        }

        public List<string> List()
        {
            return
                new List<string>() { "a", "b", "c", "d" };
        }
    }
}