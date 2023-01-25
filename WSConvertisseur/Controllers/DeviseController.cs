using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviseController : ControllerBase
    {
        private List<Devise> lesDevises;

        public List<Devise> LesDevises
        {
            get
            {
                return lesDevises;
            }

            set
            {
                lesDevises = value;
            }
        }

        public DeviseController()
        {
            this.LesDevises = new List<Devise>() { new Devise(1, "Dollar", 1.08), new Devise(2, "Franc Suisse", 1.07), new Devise(3, "Yen", 120) };
            
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return (IEnumerable<Devise>)this.LesDevises;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name ="GetDevise")]
        public ActionResult<Devise> GetById(int id)
        {
            Devise? devise = this.LesDevises.FirstOrDefault((d) => d.Id == id);

            if (devise == null)
            {
                return NotFound();
            }


            return devise;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
