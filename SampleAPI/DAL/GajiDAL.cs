using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;

namespace SampleAPI.DAL
{
    public class GajiDAL : ICrud<Gaji>
    {
        //untuk delete data
        public void Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnectionString()))
            {
                //dete data - denny eaea
                string strSql = @"delete from Gaji where Id=@Id";
                var param = new { Id = id };
                try
                {
                    conn.Execute(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Exception : " + sqlEx.Message);
                }

            }
        }

        public IEnumerable<Gaji> GetAll()
        {
            using(SqlConnection conn = new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"select * from Gaji order by Nip";
                var results = conn.Query<Gaji>(strSql);
                
                return results;
            }
        }

        public Gaji GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"select * from Gaji where Id=@Id";
                var param = new { Id=id };
                var result = conn.QuerySingle<Gaji>(strSql,param);
                return result;
            }
        }

        public IEnumerable<Gaji> GetByJumlah(decimal jumlah)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"select * from Gaji where Jumlah>=@Jumlah";
                var param = new { Jumlah = jumlah };
                var results = conn.Query<Gaji>(strSql, param);
                return results;
            }
        }

        public void Insert(Gaji obj)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"insert into Gaji(Nip,Norek,Jumlah) 
                                  values(@Nip,@Norek,@Jumlah)";
                var param = 
                    new { Nip = obj.Nip, Norek = obj.Norek, Jumlah = obj.Jumlah };
                try
                {
                    conn.Execute(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Number: {sqlEx.Number} Error:{sqlEx.Message}");
                }
            }
        }

        public void Update(Gaji obj)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"update Gaji set Nip=@Nip,Norek=@Norek,Jumlah=@Jumlah 
                                  where Id=@Id";
                var param = new { Nip = obj.Nip, Norek = obj.Norek, Jumlah = obj.Jumlah };
                try
                {
                    conn.Execute(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Number: {sqlEx.Number}, Error:{sqlEx.Message}");
                }
            }
        }


    }
}