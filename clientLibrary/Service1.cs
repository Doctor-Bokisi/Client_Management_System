using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace clientLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public Service1()
        {
            ConnectToDb();
        }

        SqlConnection conn;
        SqlCommand comm;
        SqlConnectionStringBuilder connStringBuilder;
        void ConnectToDb()
        {
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "BOOTCAMP21";
            connStringBuilder.InitialCatalog = "ClientManagement";
            connStringBuilder.Encrypt = true;
            connStringBuilder.TrustServerCertificate = true;
            connStringBuilder.ConnectTimeout = 30;
            connStringBuilder.AsynchronousProcessing = true;
            connStringBuilder.IntegratedSecurity = true;

            conn = new SqlConnection(connStringBuilder.ToString());
            comm = conn.CreateCommand();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int insertClient(clientC c)
        {
            try
            {

                comm.CommandText = "insert into Client values(@name, @Gender, @ResidentialAdd, @WorkAdd, @PostalAdd, @MobileNum, @WorkNum)";
                comm.Parameters.AddWithValue("name", c.name);
                comm.Parameters.AddWithValue("Gender", c.gender);
                comm.Parameters.AddWithValue("ResidentialAdd", c.ResidentialAdd);
                comm.Parameters.AddWithValue("WorkAdd", c.WorkAdd);
                comm.Parameters.AddWithValue("PostalAdd", c.PostalAdd);
                comm.Parameters.AddWithValue("MobileNum", c.mobileNumber);
                comm.Parameters.AddWithValue("WorkNum", c.workNumber);


                comm.CommandType = CommandType.Text;

                conn.Open();
                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }


        }

        public int updateClient(clientC c)
        {
            try
            {

                comm.CommandText = "UPDATE Client SET name=@name, Gender=@Gender, ResidentialAdd=@ResidentialAdd, WorkAdd=@WorkAdd, PostalAdd=@PostalAdd, MobileNum=@MobileNum, WorkNum=@WorkNum WHERE UserId=@UserId";
                comm.Parameters.AddWithValue("UserId", c.UserId);
                comm.Parameters.AddWithValue("name", c.name);
                comm.Parameters.AddWithValue("Gender", c.gender);
                comm.Parameters.AddWithValue("ResidentialAdd", c.ResidentialAdd);
                comm.Parameters.AddWithValue("WorkAdd", c.WorkAdd);
                comm.Parameters.AddWithValue("PostalAdd", c.PostalAdd);
                comm.Parameters.AddWithValue("MobileNum", c.mobileNumber);
                comm.Parameters.AddWithValue("WorkNum", c.workNumber);


                comm.CommandType = CommandType.Text;

                conn.Open();
                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public int deleteClient(clientC c)
        {
            try
            {

                comm.CommandText = "DELETE FROM Client WHERE UserId=@UserId";
                comm.Parameters.AddWithValue("UserId", c.UserId);             
                comm.CommandType = CommandType.Text;
                conn.Open();
                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }


        public List<clientC> getClients()
        {
            List<clientC> clientl = new List<clientC>();
            try
            {
                comm.CommandText = "select * from Client ";
                comm.CommandType = CommandType.Text;

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    clientC client = new clientC()
                    {
                        UserId = Convert.ToInt32((reader[0])),
                        name = reader[1].ToString(),
                        gender = reader[2].ToString(),
                        ResidentialAdd = reader[3].ToString(),
                        WorkAdd = reader[4].ToString(),
                        PostalAdd = reader[5].ToString(),
                        mobileNumber = reader[6].ToString(),
                        workNumber = reader[7].ToString()

                    };


                    clientl.Add(client);
                }


                return clientl;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
           }
        }
    }
