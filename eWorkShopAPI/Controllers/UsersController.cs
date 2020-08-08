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
  public class UsersController : ApiController
  {
    private readonly eWorkShop123Entities db = new eWorkShop123Entities();

    // GET: api/Users
    public IEnumerable<User> GetUsers()
    {
      return db.Users
        .Where(x => x.IsArchived == false && x.UserTypeId == (int)EUserTypes.Customer)
        .ToList();
    }

    // GET: api/Users/5
    [ResponseType(typeof(User))]
    public IHttpActionResult GetUserByUserId(long id)
    {
      User user = db.Users.Find(id);
      if (user == null)
      {
        return NotFound();
      }

      return Ok(user);
    }

    // PUT: api/Users/5
    [HttpPost]
    public IHttpActionResult UpdateUser(long id, User user)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != user.UserID)
      {
        return BadRequest();
      }

      db.Entry(user).State = EntityState.Modified;

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(id))
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

    // POST: api/Users
    [HttpPost]
    public IHttpActionResult SaveUser(User user)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      user.CreatedDate = DateTime.Now;
      user.CreatedBy = 1;
      user.UpdatedDate = DateTime.Now;
      user.UpdatedBy = DateTime.Now;
      user.IsArchived = false;
      user.UserTypeId = (int)EUserTypes.Customer;

      db.Users.Add(user);
      db.SaveChanges();

      return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
    }

    // DELETE: api/Users/5
    [HttpPost]
    public IHttpActionResult DeleteUser(long id)
    {
      User user = db.Users.Find(id);
      if (user == null)
      {
        return NotFound();
      }

      db.Users.Remove(user);
      db.SaveChanges();

      return Ok(user);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool UserExists(long id)
    {
      return db.Users.Count(e => e.UserID == id) > 0;
    }
  }
}