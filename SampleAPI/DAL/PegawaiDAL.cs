using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SampleAPI.Models;

namespace SampleAPI.DAL
{
    public class PegawaiDAL : ICrud<Pegawai>
    {
        public void Delete(string id)
        {
            var result = GetById(id);
            if (result == null)
                throw new Exception($"Data dengan Nip {id} tidak ditemukan");

            using (SqlConnection conn =
                new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"delete from Pegawai where Nip=@Nip";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Nip", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public IEnumerable<Pegawai> GetAll()
        {
            List<Pegawai> lstPegawai = new List<Pegawai>();
            using(SqlConnection conn = 
                new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"select * from Pegawai 
                                  order by Nama asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lstPegawai.Add(new Pegawai
                        {
                            Nip = dr["Nip"].ToString(),
                            Nama = dr["Nama"].ToString(),
                            Email = dr["Email"].ToString(),
                            Telp = dr["Telp"].ToString(),
                            Umur = Convert.ToInt32(dr["Umur"])
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return lstPegawai;
        }

        public Pegawai GetById(string id)
        {
            Pegawai pegawai = new Pegawai();
            using (SqlConnection conn =
               new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"select * from Pegawai 
                                  where Nip=@Nip";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Nip", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    pegawai.Nip = dr["Nip"].ToString();
                    pegawai.Nama = dr["Nama"].ToString();
                    pegawai.Email = dr["Email"].ToString();
                    pegawai.Telp = dr["Telp"].ToString();
                    pegawai.Umur = Convert.ToInt32(dr["Umur"]);
                }
                else
                {
                    pegawai = null;
                }

                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return pegawai;
        }

        public void Insert(Pegawai obj)
        {
            using (SqlConnection conn =
               new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"insert into Pegawai(Nip,Nama,Email,Telp,Umur) 
                                values(@Nip,@Nama,@Email,@Telp,@Umur)";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Nip", obj.Nip);
                cmd.Parameters.AddWithValue("@Nama", obj.Nama);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Telp", obj.Telp);
                cmd.Parameters.AddWithValue("@Umur", obj.Umur);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public void Update(Pegawai obj)
        {
            var result = GetById(obj.Nip);
            if (result == null)
            {
                throw new Exception($"Data Pegawai {obj.Nip} tidak ditemukan");
            }
            using (SqlConnection conn =
              new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"update Pegawai set 
                                Nama=@Nama,Email=@Email,Telp=@Telp,Umur=@Umur 
                                where Nip=@Nip";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Nama", obj.Nama);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Telp", obj.Telp);
                cmd.Parameters.AddWithValue("@Umur", obj.Umur);
                cmd.Parameters.AddWithValue("@Nip", obj.Nip);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
    }
}