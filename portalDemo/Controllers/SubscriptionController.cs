using portalDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using portal.Domain;

namespace portalDemo.Controllers
{
    public class SubscriptionController : BaseController
    {
        private readonly IUserManagementService userManagementService;
        // GET: Subscription
        public SubscriptionController()
        {
            this.userManagementService = new UserManagementService();
        }
        [HttpPost]
        public ActionResult SubscriptionTicket()
        {
            return Json("success", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Index(TicketType type)
        {
            var model = new SubModel()
            {
                Name = type == TicketType.Single ? "天门山国家森林公园登山成人票" : "天门山国家森林公园登山门票+往返观光车成人票",
                Price = type == TicketType.Single ? 50 : 80,
                Count = 1,
                Total = type == TicketType.Single ? 50 : 80,
                Type = type,
                UserId = this.currentUser.UserId
            };
            return View(model);
        }
        [AllowAnonymous]
        public ActionResult SubscriptionTicket(SubModel model)
        {
            var domianModel = model.CoverToDomain();
            var result = userManagementService.SubscriptionTicket(domianModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SubDetail()
        {
            var domainModel = userManagementService.GetSubHistoryByUserId(currentUser.UserId);
            var model = new List<SubModel>();
            domainModel.ForEach(o =>
            {
                model.Add(SubModel.GetModel(o));
            });
            return View(model);
        }
    }
}