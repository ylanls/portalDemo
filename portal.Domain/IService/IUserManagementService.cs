using portal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal.Domain
{
    public interface IUserManagementService
    {
         bool Register(UserRegisterModel model);
         bool IsExistName(string UserName);
         UserInfoModel GetUser(UserLoginModel model);
         bool SubscriptionTicket(SubDomainModel model);
         List<SubDomainModel> GetSubHistoryByUserId(string UserId);
    }
}
