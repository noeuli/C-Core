using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab21
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(
                    0, 100, (i) => Print(i)
                );
        }

        private static void Print(int i)
        {
            string dbConnectionString = 
                 @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Lab\TestDB.mdf;Integrated Security=True;Connect Timeout=30";
            using (var con = new SqlConnection(dbConnectionString))
            {
                // 쿼리문은. 2개를 실행함..
                // 첫번째는 입력
                // 두번째는 출력
                try
                {
                    con.Open();

                    SqlCommand sqlcmd =
                        new SqlCommand("입력 출력 저장프로시저", con);
                    sqlcmd.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    //입력
                    SqlParameter sqlPMInput =
                        new SqlParameter("@in", System.Data.SqlDbType.Int);
                    sqlPMInput.Value = 1;
                    sqlcmd.Parameters.Add(sqlPMInput);
                    // 출력
                    SqlParameter sqlPMOuput =
                        new SqlParameter("@out", System.Data.SqlDbType.Int);
                    sqlPMOuput.Direction = System.Data.ParameterDirection.Input;
                    sqlcmd.Parameters.Add(sqlPMOuput);

                    sqlcmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (SqlException sqlex)
                {

                }
                catch (Exception er)
                {
                }
                finally
                {
                    // 개체 연결 상태 확인 후 연결 종료..
                    con.Dispose();
                    
                }

            }
        }
    }
}
