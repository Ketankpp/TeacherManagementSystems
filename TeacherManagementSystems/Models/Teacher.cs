using Microsoft.Data.SqlClient;
using System.ComponentModel;

namespace TeacherManagementSystems.Models
{
    public class Teacher
    {
        [ReadOnly(true)]public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    public static List<Teacher> GetAllTeachers()
    {
        List<Teacher> lstTeac = new List<Teacher>();
        using (SqlConnection cn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True"))
        {
            try
            {
                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = System.Data.CommandType.Text;
                cmdSelect.CommandText = "SELECT * FROM Teacher"; 
                SqlDataReader dr = cmdSelect.ExecuteReader();
                while (dr.Read())
                {
                    lstTeac.Add(new Teacher
                    {
                        TeacherID = dr.GetInt32(0),
                        FirstName = dr.GetString(1),
                        LastName = dr.GetString(2),
                        Subject = dr.GetString(3),
                        Gender = dr.GetString(4),
                        Email = dr.GetString(5),
                        Phone = dr.GetString(6),
                        Address = dr.GetString(7)
                    });
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        return lstTeac;
    }

    public static Teacher GetSingleTeacher(int TeacherID)
        {
            Teacher obj = new Teacher();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select * from Teacher where TeacherID=@TeacherID";
                cmdInsert.Parameters.AddWithValue("@TeacherID", TeacherID);
                SqlDataReader dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    obj.TeacherID = dr.GetInt32(0);
                    obj.FirstName = dr.GetString(1);
                    obj.LastName = dr.GetString(2);
                    obj.Subject = dr.GetString(3);
                    obj.Gender = dr.GetString(4);
                    obj.Email = dr.GetString(5);
                    obj.Phone = dr.GetString(6);
                    obj.Address = dr.GetString(7);
                }
                else
                {
                    obj = null;
                }
                dr.Close();



            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return obj;
        }
        public static void InsertTeacher(Teacher obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "insert into Teacher values(@TeacherID,@FirstName,@LastName,@Subject,@Gender,@Email,@Phone,@Address)";



                cmdInsert.Parameters.AddWithValue("@TeacherID", obj.TeacherID);
                cmdInsert.Parameters.AddWithValue("@FirstName", obj.FirstName);
                cmdInsert.Parameters.AddWithValue("@LastName", obj.LastName);
                cmdInsert.Parameters.AddWithValue("@Subject", obj.Subject);
                cmdInsert.Parameters.AddWithValue("@Gender", obj.Gender);
                cmdInsert.Parameters.AddWithValue("@Email", obj.Email);
                cmdInsert.Parameters.AddWithValue("@Phone", obj.Phone);
                cmdInsert.Parameters.AddWithValue("@Address", obj.Address);
                cmdInsert.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void UpdateTeacher(Teacher obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "update Teacher SET FirstName = @FirstName, LastName = @LastName, Subject = @Subject, Gender = @Gender, Email = @Email, Phone = @Phone, Address = @Address WHERE TeacherID = @TeacherID";

                cmdInsert.Parameters.AddWithValue("@TeacherID", obj.TeacherID);
                cmdInsert.Parameters.AddWithValue("@FirstName", obj.FirstName);
                cmdInsert.Parameters.AddWithValue("@LastName", obj.LastName);
                cmdInsert.Parameters.AddWithValue("@Subject", obj.Subject);
                cmdInsert.Parameters.AddWithValue("@Gender", obj.Gender);
                cmdInsert.Parameters.AddWithValue("@Email", obj.Email);
                cmdInsert.Parameters.AddWithValue("@Phone", obj.Phone);
                cmdInsert.Parameters.AddWithValue("@Address", obj.Address);
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void DeleteTeacher(int TeacherID)
        {
            using (SqlConnection cn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True"))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmdDelete = new SqlCommand();
                    cmdDelete.Connection = cn;
                    cmdDelete.CommandType = System.Data.CommandType.Text;
                    cmdDelete.CommandText = "DELETE FROM Teacher WHERE TeacherID = @TeacherID";

                    cmdDelete.Parameters.AddWithValue("@TeacherID", TeacherID);
                    cmdDelete.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }
    }
}



