using portal.Domain.Model;
using portal.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace portal.Domain
{
    public class UserFunction : IUserFunction
    {
        public bool Register(UserRegisterModel model)
        {
            var query = @"insert  into users values(@Id,@Name,@Password)";
            var conn = Util.Util.GetDBConnection();
            conn.Open();
            SqlCommand com = new SqlCommand(query, conn);
            SqlParameter[] parmas = new SqlParameter[] { new SqlParameter("@Id",model.Id),
            new SqlParameter("@Name",model.Name),
            new SqlParameter("@Password",model.Password)
            };
            com.Parameters.AddRange(parmas);
            var result = com.ExecuteNonQuery() > 0;
            conn.Close();
            return result;
        }
        public bool IsExistName(string UserName)
        {
            var query = @"select * from users where name=@UserName";
            var conn = Util.Util.GetDBConnection();
            conn.Open();
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.Add(new SqlParameter("@UserName", UserName));
            var reader = com.ExecuteReader();
            var result = reader.Read();
            conn.Close();
            return result;
        }
        public UserInfoModel GetUser(UserLoginModel model)
        {
            UserInfoModel result = null;
            var query = @"select * from users where name=@UserName and password=@Password";
            var conn = Util.Util.GetDBConnection();
            conn.Open();
            SqlCommand com = new SqlCommand(query, conn);
            SqlParameter[] parmas = new SqlParameter[] {
            new SqlParameter("@UserName",model.UserName),
            new SqlParameter("@Password",model.Password)
            };
            com.Parameters.AddRange(parmas);
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                result = new UserInfoModel();
                result.Name = reader["Name"].ToString();
                result.Id = reader["Id"].ToString();
            }
            return result;
        }
        public bool SubscriptionTicket(SubDomainModel model)
        {
            var query = @"insert into Subscription values(@Id,@UserId,@Type,@Count,@Total,@SubDate)";
            var conn = Util.Util.GetDBConnection();
            conn.Open();
            SqlCommand com = new SqlCommand(query, conn);
            SqlParameter[] parmas = new SqlParameter[] {
            new SqlParameter("@Id",model.Id),
            new SqlParameter("@UserId",model.UserId),
            new SqlParameter("@Type",model.Type),
            new SqlParameter("@Count",model.Count),
            new SqlParameter("@Total",model.Total),
            new SqlParameter("@SubDate",model.SubDate)
            };
            com.Parameters.AddRange(parmas);
            var result = com.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }
        public List<SubDomainModel> GetSubHistoryByUserId(string UserId)
        {
            var result = new List<SubDomainModel>();
            var query = @"select * from Subscription where UserId=@UserId";
            var conn = Util.Util.GetDBConnection();
            conn.Open();
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.Add(new SqlParameter("@UserId", UserId));
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                var model = new SubDomainModel();
                model.Id = reader["Id"].ToString();
                model.UserId = UserId;
                model.Type = Int32.Parse(reader["Type"].ToString());
                model.Count = Int32.Parse(reader["TicketCount"].ToString());
                model.Total = Int32.Parse(reader["Total"].ToString());
                model.SubDate = reader["SubDate"].ToString();
                result.Add(model);
            }
            conn.Close();
            return result;
        }
    }
}
