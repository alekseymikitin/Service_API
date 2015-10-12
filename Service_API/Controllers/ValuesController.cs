using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service_API.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        //$format=json
        [HttpGet]
        public DataTable conn_DB()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            return instance.GetDataSources();

        }
        public string GetServer(string s)
        {
            return s;
        }


        string connStr = @"Data Source =(local)\SQLEXPRESS; Initial Catalog=Material; Integrated Security=True";
        SqlConnection con;
        List<string> table = new List<string>();
        public void Connect()
        {
            con = new SqlConnection(connStr);
            con.Open();
        }

        // GET api/values 
        public IEnumerable<string> Get()
        {
            Connect();
            string result = string.Empty;
            string SQL_Command_Get_Table = "SELECT TABLE_NAME FROM information_schema.TABLES";
            SqlCommand comm = new SqlCommand(SQL_Command_Get_Table, con);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                table.Add(reader.GetString(0));
            }
            con.Close();
            con.Dispose();
            return table;
        } 

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
