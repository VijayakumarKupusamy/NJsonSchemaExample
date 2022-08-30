using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace NJsonSchema
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase 
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                
            })
            .ToArray();
        } 

        [HttpPost(Name = "/validate/products")]
        public async Task<IActionResult> CreateValidProduct([FromBody]Object product)
        {
            //var schema = JsonSchema.FromType<JObject>();
            var validateSchema = await JsonSchema.FromFileAsync($"schema/product.json"); 
            var jsonString= product.ToString();
            var errors = validateSchema.Validate(jsonString);

     
            if (errors.Count > 0)
            {
                return BadRequest(errors.Where(x=>x.HasLineInfo).Select(x=> { return x.Path; }));
            } 
            return Ok(product);
        }
    }
}
