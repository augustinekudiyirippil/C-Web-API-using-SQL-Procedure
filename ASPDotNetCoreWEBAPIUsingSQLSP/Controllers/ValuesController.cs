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
        public List<Employee>Get()
        {


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("usp_GetAllEmployees", sqlConnection);
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            List<Employee> listEmployee = new List<Employee>();
            if(dataTable.Rows.Count>0)
            {
                for(int i=0; i<dataTable.Rows.Count;i++)
                {

                    Employee employee = new Employee();
                    employee.empID = (int)dataTable.Rows[i]["empID"];
                    employee.empName = (string)dataTable.Rows[i]["empName"];
                    employee.empAge = (int)dataTable.Rows[i]["empAge"];
                    employee.empActive = (int)dataTable.Rows[i]["empActive"];
                    listEmployee.Add(employee);

                }


             

            }
            if (listEmployee.Count > 0)
            {

                return listEmployee;
            }
            else
            {
                return null;

            }



        }





        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
           

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("usp_GetAllEmployees", sqlConnection);
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@empID",id);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            Employee employee = new Employee();
            if (dataTable.Rows.Count > 0)
            {
        
                   
                    employee.empID = (int)dataTable.Rows[0]["empID"];
                    employee.empName = (string)dataTable.Rows[0]["empName"];
                    employee.empAge = (int)dataTable.Rows[0]["empAge"];
                    employee.empActive = (int)dataTable.Rows[0]["empActive"];
                    
                  }
            if (employee!=null)
            {

                return employee;
            }
            else
            {
                return null;

            }
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
