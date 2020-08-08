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
using eWorkShopAPI.Entity;

namespace eWorkShopAPI.Controllers
{
  public class CustomerGroupsController : ApiController
  {
    private readonly eWorkShop123Entities db = new eWorkShop123Entities();

    [HttpGet]
    public IEnumerable<CustomerGroup> GetCustomerGroups()
    {
      return db.CustomerGroups
        .Where(x => x.CustomerGroupID != 1 && x.IsArchived == false)
        .ToList();
    }

    [HttpGet]
    public IHttpActionResult GetCustomerGroupByCustomerGroupId(long id)
    {
      CustomerGroup customerGroup = db.CustomerGroups.Find(id);
      if (customerGroup == null)
      {
        return NotFound();
      }

      return Ok(customerGroup);
    }

    [HttpPost] 
    public IHttpActionResult UpdateCustomerGroup(long id, CustomerGroup customerGroup)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != customerGroup.CustomerGroupID)
      {
        return BadRequest();
      }

      db.Entry(customerGroup).State = EntityState.Modified;

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CustomerGroupExists(id))
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
    public IHttpActionResult SaveCustomerGroup(CustomerGroup customerGroup)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      customerGroup.CreatedDate = DateTime.Now;
      customerGroup.CreatedBy = 1;
      customerGroup.UpdatedDate = DateTime.Now;
      customerGroup.UpdatedBy = 1;
      customerGroup.IsArchived = false;

      db.CustomerGroups.Add(customerGroup);
      db.SaveChanges();

      return CreatedAtRoute("DefaultApi", new { id = customerGroup.CustomerGroupID }, customerGroup);
    }

    [HttpGet]
    public IHttpActionResult DeleteCustomerGroup(long id)
    {
      CustomerGroup customerGroup = db.CustomerGroups.Find(id);
      if (customerGroup == null)
      {
        return NotFound();
      }

      db.CustomerGroups.Remove(customerGroup);
      db.SaveChanges();

      return Ok(customerGroup);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool CustomerGroupExists(long id)
    {
      return db.CustomerGroups.Count(e => e.CustomerGroupID == id) > 0;
    }
  }
}