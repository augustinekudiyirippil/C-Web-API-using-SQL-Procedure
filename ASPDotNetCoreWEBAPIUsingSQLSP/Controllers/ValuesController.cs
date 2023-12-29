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


        string sqlConnectionString = "Server=DEMOLAPTOP; Database=DBForWebAPI;Integrated Security = true;";

        //         Server=DEMOLAPTOP;Database=Master;User Id = sa; Password=Hanrahan1;

        SqlConnection sqlConnection = new SqlConnection("Server=DEMOLAPTOP; Database=DBForWebAPI;Integrated Security = true;");

        




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
        public string Post(Employee employee)
        {
            string resultMsg = "";

            if(employee !=null)
            {
                SqlCommand sqlcommand = new SqlCommand("usp_AddEmployee", sqlConnection);
                sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.Parameters.AddWithValue("@empName", employee.empName);
                sqlcommand.Parameters.AddWithValue("@empAge", employee.empAge);
                sqlcommand.Parameters.AddWithValue("@empActive", employee.empActive);
                sqlConnection.Open();
                int i = sqlcommand.ExecuteNonQuery();
                sqlConnection.Close();

                if(i>0)
                {
                    resultMsg= "New eployee added";
                }
                else
                {
                    resultMsg= "Error";

                }

            }

            return resultMsg;

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
