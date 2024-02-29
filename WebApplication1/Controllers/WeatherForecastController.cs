using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Repair.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "UserRegister")]
        public string UserRegister(UserRegistration request)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-FLR9DN0\\SQLEXPRESS; Initial Catalog=Repair_01;Integrated Security=True;";
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@username", request.name);
            cmd.Parameters.AddWithValue("@email", request.email);
            cmd.Parameters.AddWithValue("@password", request.password);
            cmd.Parameters.AddWithValue("@address", request.address);
            cmd.CommandText = "insert into Registraton(username,email,password,isactive,address) values(@username,@email,@password,1,@address);";
            con.Open();

            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                dt = new DataTable("table1");
                dt.Load(sdr);
            }
            con.Close();
            cmd.Dispose();
            return "asfd";
        }

        [HttpPost(Name = "UserLogin")]
        public IActionResult UserLogin(UserLoginRequest request)
        {
            UserDetails userDetails = new UserDetails();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-FLR9DN0\\SQLEXPRESS; Initial Catalog=Repair_01;Integrated Security=True;";
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@email", request.Email);
            cmd.Parameters.AddWithValue("@password", request.Password);
            cmd.CommandText = "select 1 isVerified, UserName, Email from Registraton where email = @email and password = @password;";
            con.Open();

            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                dt = new DataTable("table1");
                dt.Load(sdr);
            }
            con.Close();
            cmd.Dispose();

            if (dt.Rows != null && dt.Rows.Count > 0 && dt.Rows[0]["isVerified"].ToString() == "1")
            {
                userDetails.Email = dt.Rows[0]["Email"].ToString();
                userDetails.UserName = dt.Rows[0]["UserName"].ToString();
                userDetails.IsVerified = true;
            }
            else
            {
                userDetails.IsVerified = false;
            }

            return Ok(userDetails);
        }
    }

    

    public class UserDetails
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; }
    }

    public class UserLoginRequest
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
    public class UserRegistration
    {
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string address { get; set; }
    }
}
