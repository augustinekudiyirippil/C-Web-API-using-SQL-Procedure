using ASPDotNetCoreWEBAPIUsingSQLSP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPDotNetCoreWEBAPIUsingSQLSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {





        //MyDBConnection

        //string myDb1ConnectionString = _configuration.GetConnectionString("MyDBConnection");


        string sqlConnectionString = "Server=DEMOLAPTOP; Database=Master;Integrated Security = true;";

        //         Server=DEMOLAPTOP;Database=Master;User Id = sa; Password=Hanrahan1;

        SqlConnection sQLConnection = new SqlConnection("Server=DEMOLAPTOP; Database=Master;Integrated Security = true;");

        




        Employee emp = new Employee();



        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(Employee employee)
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
