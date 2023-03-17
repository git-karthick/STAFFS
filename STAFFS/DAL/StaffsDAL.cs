using STAFFS.Models;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Data;

namespace STAFFS.DAL
{
    public class StaffsDAL
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        public static IConfiguration Configuration { get; set; }
        private string GetConnectionString() 
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration= builder.Build();
            return Configuration.GetConnectionString("DefaultConnection");
        }

        public List<Staffs> GetAll()
        {
            List<Staffs> StaffList = new List<Staffs>();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "VIEWALLSTAFFS_SP";
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();
                while (dr.Read())
                {
                    Staffs staffs = new Staffs();
                    staffs.Id = Convert.ToInt32(dr["Id"]);
                    staffs.sId = Convert.ToInt32(dr["sId"]);
                    staffs.sName = dr["sName"].ToString();
                    staffs.sQly = dr["sQly"].ToString();
                    staffs.sDesg = dr["sDesg"].ToString();
                    staffs.sSal = Convert.ToDecimal(dr["sSal"]);
                    StaffList.Add(staffs);
                }
            }
            return StaffList;
        }
        public bool Insert(Staffs staffs)
        {
            using(_connection= new SqlConnection(GetConnectionString())) 
            { 
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "INSETRTSTAFFS_SP";
                _command.Parameters.AddWithValue("@sId", staffs.sId);
                _command.Parameters.AddWithValue("@sName", staffs.sName);
                _command.Parameters.AddWithValue("@sQly", staffs.sQly);
                _command.Parameters.AddWithValue("@sDesg", staffs.sDesg);
                _command.Parameters.AddWithValue("@sSal", staffs.sSal);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            return true;
        }
        public Staffs GetById(int id)
        {
            Staffs staffs = new Staffs();  
            using(_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "VIEWBYSTAFFID_SP";
                _command.Parameters.AddWithValue("@id", id);
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();
                while (dr.Read())
                {
                    staffs.Id = Convert.ToInt32(dr["ID"]);
                    staffs.sId = Convert.ToInt32(dr["sID"]);
                    staffs.sName = dr["sName"].ToString();
                    staffs.sQly = dr["sQly"].ToString();
                    staffs.sDesg = dr["sDesg"].ToString();
                    staffs.sSal = Convert.ToDecimal(dr["sSal"]);
                }
            }
            return staffs;
        }
        public bool Update(Staffs staffs)
        {
            int id = 0;
            using(_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "UPDATESTAFFS_SP";
                _command.Parameters.AddWithValue("@Id", staffs.Id);
                _command.Parameters.AddWithValue("@sId", staffs.sId);
                _command.Parameters.AddWithValue("@sName", staffs.sName);
                _command.Parameters.AddWithValue("@sQly", staffs.sQly);
                _command.Parameters.AddWithValue("@sDesg", staffs.sDesg);
                _command.Parameters.AddWithValue("@sSal", staffs.sSal);
                _connection.Open();
               id =  _command.ExecuteNonQuery();
            }
            return id>0 ? true:false;
        }
        public bool Delete(int id)
        {
            using(_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText= "UPDATESTAFFS1_SP";
                _command.Parameters.AddWithValue("@id", id);
                _connection.Open();
                id = _command.ExecuteNonQuery();
            }
            return id>0 ? true:false;
        }
    }
}
