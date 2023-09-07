using System.ComponentModel.DataAnnotations;
namespace ProductMVCCRUD.Models
{
    public class Category
    {
        [Key]
        [Display(Name ="Category Id")]
       public int cId { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string? cName { get; set; }
    }

}
