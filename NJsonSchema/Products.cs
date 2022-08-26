using System.ComponentModel.DataAnnotations;

namespace NJsonSchema
{
    public class Products
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ProductCategoryId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public double MaxRetailPrice { get;set; }
        [Required]
        public double UnitPrice { get; set; }
    }
}
