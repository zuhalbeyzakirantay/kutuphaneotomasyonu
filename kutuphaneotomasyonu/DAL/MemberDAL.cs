using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;
using kutuphaneotomasyonu.Domain;



namespace kutuphaneotomasyonu.DAL
{
    public class MemberDAL
    {
        DbConnection db = new DbConnection();

        public void Add(Member member)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"INSERT INTO members
                (Name, Surname, Phone, Email, RegisterDate)
                VALUES (@Name, @Surname, @Phone, @Email, @RegisterDate)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", member.Name);
                cmd.Parameters.AddWithValue("@Surname", member.Surname);
                cmd.Parameters.AddWithValue("@Phone", member.Phone);
                cmd.Parameters.AddWithValue("@Email", member.Email);
                cmd.Parameters.AddWithValue("@RegisterDate", member.RegisterDate);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int memberId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM members WHERE MemberId=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", memberId);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Member> GetAll()
        {
            List<Member> members = new List<Member>();

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT * FROM members";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    members.Add(new Member
                    {
                        MemberId = Convert.ToInt32(reader["MemberId"]),
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        RegisterDate = Convert.ToDateTime(reader["RegisterDate"])
                    });
                }
            }

            return members;
        }
    }
}





