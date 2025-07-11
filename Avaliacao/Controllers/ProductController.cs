using Avaliacao.Models;
using Avaliacao.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Controllers;

public class ProductController : ControllerBase
{
    [HttpGet("Get/Product")]
    public ActionResult<Product> Get([FromQuery]int idProduct)
    {
        var product = ProductRepository.GetProduct(idProduct);

        if (product == null)
        {
            return BadRequest("Produto não encontrado");
        }

        return Ok(product);
    }

    [HttpPost("Post/Product")]
    public ActionResult<Product> Post([FromBody]Product product)
    {
        ProductRepository.AddProduct(product);
        return Ok(product);
    }

    [HttpPut("Put/ProductQuantity")]
    public ActionResult PutQuantity([FromQuery]int productId, [FromQuery] int newQuantity)
    {
        var product = ProductRepository.GetProduct(productId);

        if (product == null)
        {
            return BadRequest("Produto não encontrado");
        }

        ProductRepository.UpdateQuantity(productId, newQuantity);
        return Ok();
    }

    [HttpPut("Put/SellProduct")]
    public ActionResult SellProduct([FromQuery] int productId, [FromQuery] int amount)
    {
        var product = ProductRepository.GetProduct(productId);

        if (product == null)
        {
            return BadRequest("Produto não encontrado");
        }

        ProductRepository.SellProduct(productId, amount);

        return Ok();
    }

    [HttpDelete("Delete/Product")]
    public ActionResult DeleteProduct([FromQuery] int productId)
    {
        var product = ProductRepository.GetProduct(productId);

        if (product == null)
        {
            return BadRequest("Produto não encontrado");
        }

        ProductRepository.RemoveProduct(productId);

        return Ok();
    }
}
