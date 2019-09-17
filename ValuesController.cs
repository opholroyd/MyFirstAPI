using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public SqlConnectionClass repo;
        /*public SqlConnectionClass sqlClass;*/

        // GET api/values
        [HttpGet]
        public ActionResult<List<AppointmentSlot>> Get()
        {
            repo = new SqlConnectionClass();
            repo.Read();
            return repo.data;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<List<AppointmentSlot>> Get(int id)
        {
            repo = new SqlConnectionClass();
            repo.Read();
            return repo.data;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] DataHandler data)
        {
            repo = new SqlConnectionClass();
            repo.AddToTable(data);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
         /*   repo = new DatabaseRepo();
            repo.Read();
            foreach (AppointmentSlot slot in repo.data)
            {
                if (id == slot.SessionID)
                {
                    string completeSlot = slot.Time + "" + slot.PatientName + " " + slot.Reason + " " + slot.Notes;
                    return completeSlot;
                }
            }
            return "value";*/
        }
    }
}
