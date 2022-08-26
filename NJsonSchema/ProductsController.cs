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
        public IEnumerable<Products> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Products
            {
                
            })
            .ToArray();
        }

        [HttpPost(Name = "Products")]
        public async Task<IActionResult> CreateProduct([FromBody] JObject jObect)
        {
            var schema = JsonSchema.FromType<Products>();
            var schemaData = schema.ToJson();
            var errors = schema.Validate(jObect.ToString());

            foreach (var error in errors)
                Console.WriteLine(error.Path + ": " + error.Kind);
            if (errors.Count > 0)
            {
                return BadRequest(errors);
            }
            schema = await JsonSchema.FromJsonAsync(schemaData);
            return Ok(schema);
        }
    }
}
