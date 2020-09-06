using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using eWorkShopAPI.Common;
using eWorkShopAPI.Entity;

namespace eWorkShopAPI.Controllers
{
  public class ProductsController : ApiController
  {
    private eWorkShop123Entities db = new eWorkShop123Entities();

    public IQueryable<Product> GetProducts()
    {
      return db.Products;
    }

    // GET: api/Products/5
    [HttpGet]
    public IHttpActionResult GetProduct(long id)
    {
      Product product = db.Products.Find(id);
      if (product == null)
      {
        return NotFound();
      }

      return Ok(product);
    }

   [HttpPost]
    public IHttpActionResult UpdateProduct(long id, Product product)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != product.ProductID)
      {
        return BadRequest();
      }

      db.Entry(product).State = EntityState.Modified;

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ProductExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return StatusCode(HttpStatusCode.NoContent);
    }

    [HttpPost]
    public IHttpActionResult SaveProduct(Product product)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      product.CreatedDate = DateTime.Now;
      product.CreatedBy = (int)EUserTypes.Admin;
      product.UpdatedDate = DateTime.Now;
      product.UpdatedBy = (int)EUserTypes.Admin;
      product.IsArchived = false;

      db.Products.Add(product);
      db.SaveChanges();

      return Ok(product);
    }

   [HttpGet]
    public IHttpActionResult DeleteProduct(long id)
    {
      Product product = db.Products.Find(id);
      if (product == null)
      {
        return NotFound();
      }

      db.Products.Remove(product);
      db.SaveChanges();

      return Ok(product);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool ProductExists(long id)
    {
      return db.Products.Count(e => e.ProductID == id) > 0;
    }
  }
}