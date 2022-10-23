namespace WebApi.Giris.Models
{
    public class CategoryRepository
    {
        public List<Category> List()
        {

            List<Category> categories = new List<Category>();
            categories.Add(new Category { Id = 1, Name = "A Kategorisi" });
            categories.Add(new Category { Id = 2, Name = "B Kategorisi" });
            categories.Add(new Category { Id = 3, Name = "C Kategorisi" });
            categories.Add(new Category { Id = 4, Name = "D Kategorisi" });
            categories.Add(new Category { Id = 5, Name = "E Kategorisi" });
            categories.Add(new Category { Id = 6, Name = "F Kategorisi" });
            
            return categories;
        }
    }
}