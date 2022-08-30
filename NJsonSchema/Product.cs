using System.ComponentModel.DataAnnotations;

namespace NJsonSchema
{
    //
    [Obsolete]
    public class Product
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Required] 
        public int CategoryId { get; set; }
        [Required]
        public double MaxRetailPrice { get;set; }
        [Required]
        public double UnitPrice { get; set; }
    }
}
