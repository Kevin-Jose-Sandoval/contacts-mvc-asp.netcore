using ContactsApi.Models;
using System.Data.SqlClient;
using System.Data;

namespace ContactsApi.Data
{
    public class ContactData
    {
        public List<ContactModel> List()
        {
            var list = new List<ContactModel>();
            var newConnection = new Connection();

            using (var connection = new SqlConnection(newConnection.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_contact_getcontacts", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new ContactModel
                        {
                            ContactId = Convert.ToInt32(dr["contactId"]),
                            Name = Convert.ToString(dr["name"]),
                            Phone = Convert.ToString(dr["phone"]),
                            Email = Convert.ToString(dr["email"]),
                        });
                    }
                }
            }

            return list;
        }
    }
}
