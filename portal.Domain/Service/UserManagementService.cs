using portal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal.Domain
{
    public class UserManagementService : IUserManagementService
    {
        private IUserFunction userFunction;
        public UserManagementService()
        {
            userFunction = new UserFunction();
        }
        public bool Register(UserRegisterModel model)
        {
            return userFunction.Register(model);
        }
        public bool IsExistName(string UserName)
        {
            return userFunction.IsExistName(UserName);
        }
        public UserInfoModel GetUser(UserLoginModel model)
        {
            return userFunction.GetUser(model);
        }
        public bool SubscriptionTicket(SubDomainModel model)
        {
            return userFunction.SubscriptionTicket(model);
        }
        public List<SubDomainModel> GetSubHistoryByUserId(string UserId)
        {
            return userFunction.GetSubHistoryByUserId(UserId);
        }
    }
}
