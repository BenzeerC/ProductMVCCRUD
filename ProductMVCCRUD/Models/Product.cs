using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMVCCRUD.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        
        [NotMapped]
        public string? Imageurl { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        [Display(Name ="Catgory Name")]
        public int cId { get; set; }
        [Display(Name = "Catgory Name")]
        public string? cName { get; set; }
    }
}
