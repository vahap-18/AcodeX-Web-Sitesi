using APILayer.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult UsersList()
        {
            using var c = new Context();
            var values = c.Users.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult UserAdd(User user)
        {
            using var c = new Context();
            c.Add(user);
            c.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult UserGet(int id)
        {
            using var c = new Context();
            var user = c.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult UserDelete(int id)
        {
            using var c = new Context();
            var user = c.Users.Find(id);
            if (user == null)
                return NotFound();
            else
            {
                c.Remove(user);
                c.SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult UserUpdate(User user)
        {
            using var c = new Context();
            var value = c.Find<User>(user.Id);
            if(user == null)
                return NotFound();
            else
            {
                value.Name = user.Name;
                c.Update(value);
                c.SaveChanges();
                return Ok();
            }


        }
    }
}
