using Hotel_reservations_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hotel_reservations_Api.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly ApplicationDbContext db;
        public UsersController()
        {
            db = new ApplicationDbContext();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetUsers()
        {
            var users = await db.Users.Where(u => u.IsHotel == false).ToListAsync();
            return Ok(users);
        }
    }
}
