using System.Data.SqlClient;

namespace SportingEvents.Models
{
    public class Responses
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string HomeTelephoneNumber { get; set; }
        public string MobileTelephoneNumber { get; set; }
        public string Biography { get; set; }
        public string SkillKeyWord { get; set; }
        public string WorkLocation { get; set; }
        //public string UTID { get; set; }

        public int SaveDetails()
        {
            SqlConnection connection = new SqlConnection(CallConnectionString.ConnectionString());
            string query = "INSERT INTO UserInfo(Name, DateOfBirth, Gender, Email, Address, PostCode, HomeTelephoneNumber, MobileTelephoneNumber, Biography, SkillKeyWord, WorkLocation) values ('" + Name + "', '" + DateOfBirth + "','" + Gender + "','" + Email + "','" + Address + "','" + PostCode + "','" + HomeTelephoneNumber + "','" + MobileTelephoneNumber + "','" + Biography + "','" + SkillKeyWord + "','" + WorkLocation + "')";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int x = cmd.ExecuteNonQuery();
            connection.Close();
            return x;
        }

        public int UpdateDetails()
        {
            SqlConnection connection = new SqlConnection(CallConnectionString.ConnectionString());
            string query = "UPDATE UserInfo SET (Name, DateOfBirth, Gender, Email, Address, PostCode, HomeTelephoneNumber, MobileTelephoneNumber, Biography, SkillKeyWord, WorkLocation) values ('" + Name + "', '" + DateOfBirth + "','" + Gender + "','" + Email + "','" + Address + "','" + PostCode + "','" + HomeTelephoneNumber + "','" + MobileTelephoneNumber + "','" + Biography + "','" + SkillKeyWord + "','" + WorkLocation + "')";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int x = cmd.ExecuteNonQuery();
            connection.Close();
            return x;
        }

        public int DeleteDetails()
        {
            SqlConnection connection = new SqlConnection(CallConnectionString.ConnectionString());
            string query = "TRUNCATE UserInfo(Name, DateOfBirth, Gender, Email, Address, PostCode, HomeTelephoneNumber, MobileTelephoneNumber, Biography, SkillKeyWord, WorkLocation) values ('" + Name + "', '" + DateOfBirth + "','" + Gender + "','" + Email + "','" + Address + "','" + PostCode + "','" + HomeTelephoneNumber + "','" + MobileTelephoneNumber + "','" + Biography + "','" + SkillKeyWord + "','" + WorkLocation + "')";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int x = cmd.ExecuteNonQuery();
            connection.Close();
            return x;
        }

        public int DisplayData() 
        {
            SqlConnection connection = new SqlConnection(CallConnectionString.ConnectionString());
            string query = "SELECT * FROM UserInfo";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int x = command.ExecuteNonQuery();
            connection.Close();
            return x;
        }
    }
}