using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        [MaxLength(20, ErrorMessage = "Category Name must be less than 20 characters.")]
        [DisplayName("Category Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Display Order must be greater than 0.")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
