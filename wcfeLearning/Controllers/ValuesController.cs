using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace wcfeLearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        int status = 0;
        MySqlDataReader reader = null;
        string constr =
            ConfigurationManager.ConnectionStrings["constr"].ConnectionString;


        // GET api/values/id
        [HttpGet("{U}/{p}")]
        public ActionResult<IEnumerable<string>> Get(String U, String p) //
        {
           // U = "test@test.com";
           // p = "abc";
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("select count(*) from tbluser where UserID='"+U+"' and Password='"+p+"'", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@u", U);
                        cmd.Parameters.AddWithValue("@p", p);
                        con.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            status = reader.GetInt16(0);
                        }
                    }
                }
            }
            finally
            {
                reader.Close();
            }



            return new string[] { status.ToString() };// new string[] { "value1", "value2" };
        }

     /*   // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
        }*/
    }
}
