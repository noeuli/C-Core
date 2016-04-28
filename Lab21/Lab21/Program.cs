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
            // 동시에 100개 쓰레드를 만들어 병렬 실행
            // CPU Core 갯수에 따라 자동 병렬 처리
            Parallel.For(
                0, 100, (i) => Print(i)
            );
        }

        private static void Print(int i)
        {
            string dbConnectionString = "";
            using(var con = new SqlConnection(dbConnectionString))
            {
                // query 문은 2개를 실행함
                // 첫번째는 입력
                // 두번째는 출력
                con.Open();

                SqlCommand sqlCmd = new SqlCommand("IO SP", con);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                // 입력
                SqlParameter sqlPMInput = new SqlParameter("@in", System.Data.SqlDbType.Int);
                sqlPMInput.Value = 1;
                sqlCmd.Parameters.Add(sqlPMInput);

                // 출력
                SqlParameter sqlPMOutput = new SqlParameter("@out", System.Data.SqlDbType.Int);
                sqlPMOutput.Direction = System.Data.ParameterDirection.Output;
                sqlCmd.Parameters.Add(sqlPMOutput);

                sqlCmd.ExecuteNonQuery();

                // 이렇게 하면 deadlock이 걸린단다.
            }
        }
    }
}
