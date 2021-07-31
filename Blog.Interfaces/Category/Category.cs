using Blog.Interfaces.Base;

namespace Blog.Interfaces.Category
{
    public class Category : BaseEntity
    {
        public string NameResourceKey { get; set; }
        public string DescriptionResourceKey { get; set; }
    }
}