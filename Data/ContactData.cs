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

        public ContactModel GetContact(int contactId)
        {
            var newContact = new ContactModel();
            var newConnection = new Connection();

            using (var connection = new SqlConnection(newConnection.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_contact_getcontact", connection);
                cmd.Parameters.AddWithValue("contactId", contactId);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        newContact.ContactId = Convert.ToInt32(dr["contactId"]);
                        newContact.Name = dr["name"].ToString();
                        newContact.Email = dr["email"].ToString();
                        newContact.Phone = dr["phone"].ToString();
                    }
                }
            }

            return newContact;
        }

        public bool AddContact(ContactModel newContact)
        {
            bool result;

            try
            {
                var newConnection = new Connection();

                using (var connection = new SqlConnection(newConnection.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_contact_addcontact", connection);
                    cmd.Parameters.AddWithValue("name", newContact.Name);
                    cmd.Parameters.AddWithValue("phone", newContact.Phone);
                    cmd.Parameters.AddWithValue("email", newContact.Email);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            } catch (Exception e)
            {
                string error = e.Message;
                result= false;
            }

            return result;
        }

        public bool UpdateContact(ContactModel newContact)
        {
            bool result;

            try
            {
                var newConnection = new Connection();

                using (var connection = new SqlConnection(newConnection.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_contact_updatecontact", connection);
                    cmd.Parameters.AddWithValue("contactId", newContact.ContactId);
                    cmd.Parameters.AddWithValue("name", newContact.Name);
                    cmd.Parameters.AddWithValue("phone", newContact.Phone);
                    cmd.Parameters.AddWithValue("email", newContact.Email);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                result = false;
            }

            return result;
        }

        public bool DeleteContact(int contactId)
        {
            bool result;

            try
            {
                var newConnection = new Connection();

                using (var connection = new SqlConnection(newConnection.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_contact_deletecontact", connection);
                    cmd.Parameters.AddWithValue("contactId", contactId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                result = false;
            }

            return result;
        }
    }
}
