using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Model.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name  { get; set; }
        [DisplayName("Display Order")]
        
        [Range(1, 100,ErrorMessage ="You can enter odrder from 1-100")]
       
        public int DisplayOrder { get; set; } 
    }
}
