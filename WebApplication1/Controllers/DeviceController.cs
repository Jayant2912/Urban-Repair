using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Controllers;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        [HttpGet(Name = "GetAllBrands")]
        public IActionResult GetAllBrands(string type)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-FLR9DN0\\SQLEXPRESS; Initial Catalog=Repair_01;Integrated Security=True;";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", type);
            cmd.CommandText = "PRC_GetBrands";
            con.Open();

            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                dt = new DataTable("table1");
                dt.Load(sdr);
            }
            con.Close();
            cmd.Dispose();

            return Ok(JsonConvert.SerializeObject(dt));
        }

        [HttpGet(Name = "GetAllDevices")]
        public IActionResult GetAllDevices(int id, string dType)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-FLR9DN0\\SQLEXPRESS; Initial Catalog=Repair_01;Integrated Security=True;";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BrandId", id.ToString());
            cmd.Parameters.AddWithValue("@DeviceType", dType.ToString());
            cmd.CommandText = "PRC_GetAllDeviceByBrandID";
            con.Open();

            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                dt = new DataTable("table1");
                dt.Load(sdr);
            }
            con.Close();
            cmd.Dispose();

            return Ok(JsonConvert.SerializeObject(dt));
        }

        [HttpGet(Name = "GetPhoneRepairDetails")]
        public IActionResult GetPhoneRepairDetails(string DeviceCode)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-FLR9DN0\\SQLEXPRESS; Initial Catalog=Repair_01;Integrated Security=True;";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DeviceCode", DeviceCode);
            cmd.CommandText = "PRC_GetDeviceRepairDetailsByDeviceCode";
            con.Open();

            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                dt = new DataTable("table1");
                dt.Load(sdr);
            }
            con.Close();
            cmd.Dispose();

            return Ok(JsonConvert.SerializeObject(dt));
        }

        [HttpPost(Name = "SetUserDeviceRepairDetails")]
        public IActionResult SetUserDeviceRepairDetails([FromBody] Request request)
        {
            
            int result = 0;
            DataTable dt = new DataTable();

            foreach (var item in request.data)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-FLR9DN0\\SQLEXPRESS; Initial Catalog=Repair_01;Integrated Security=True;";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@serviceID", item.ServiceID);
                    cmd.Parameters.AddWithValue("@userEmail", request.UserEmail);
                    cmd.Parameters.AddWithValue("@deviceCode", request.DeviceCode);
                    cmd.Parameters.AddWithValue("@subtotalCost", request.SubtotalCost);
                    cmd.Parameters.AddWithValue("@tax", request.Tax);
                    cmd.Parameters.AddWithValue("@totalCost", request.TotalCost);
                    cmd.Parameters.AddWithValue("@serviceCost", item.ServiceCost);
                    cmd.Parameters.AddWithValue("@invoiceNumber", request.InvoiceNumber);
                    cmd.Parameters.AddWithValue("@recieptVoucherNumber", request.RecieptVoucherNumber);

                    cmd.CommandText = "PRC_SetUserService";
                    con.Open();
                    result += cmd.ExecuteNonQuery();
                    con.Close();
                    cmd.Dispose();
                }
                catch(Exception ex)
                {
                    string message = ex.Message;
                }
            }

            

            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet(Name = "GetUserDeviceRepairDetails")]
        public IActionResult GetUserDeviceRepairDetails(string DeviceCode, string EmailId)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-FLR9DN0\\SQLEXPRESS; Initial Catalog=Repair_01;Integrated Security=True;";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DeviceCode", DeviceCode);
            cmd.Parameters.AddWithValue("@EmailId", EmailId);
            cmd.CommandText = "GetUserDeviceRepairDetails";
            con.Open();

            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                dt = new DataTable("table1");
                dt.Load(sdr);
            }
            con.Close();
            cmd.Dispose();

            return Ok(JsonConvert.SerializeObject(dt));
        }
        [HttpGet(Name = "GetOrderStatusDetails")]
        public IActionResult GetOrderStatusDetails(string searchtext)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-FLR9DN0\\SQLEXPRESS; Initial Catalog=Repair_01;Integrated Security=True;";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@searchtext", searchtext);
            cmd.CommandText = "GetOrderStatusDetails";
            con.Open();

            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                dt = new DataTable("table1");
                dt.Load(sdr);
            }
            con.Close();
            cmd.Dispose();

            return Ok(JsonConvert.SerializeObject(dt));
        }

    }
    public class UserDeviceRepairDetailsRequest
    {
        public string ServiceID { get; set; }
        public long ServiceCost { get; set; }

    }
    public class Request
    {
        public string DeviceCode { get; set; }  
        public string UserEmail { get; set; }  
        public string SubtotalCost { get; set; }
        public string Tax { get; set; }
        public string TotalCost { get; set; }
        public string InvoiceNumber { get; set; }
        public string RecieptVoucherNumber { get; set; }
        public List<UserDeviceRepairDetailsRequest> data { get; set; }
    }

}
