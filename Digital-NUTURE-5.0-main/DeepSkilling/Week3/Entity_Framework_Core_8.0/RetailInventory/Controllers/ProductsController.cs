using Microsoft.AspNetCore.Mvc;
using RetailInventory.Data;
using RetailInventory.Models;

namespace RetailInventory.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly RetailDbContext _context;

    public ProductsController(RetailDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();

        return Ok(product);
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_context.Products.ToList());
    }
}