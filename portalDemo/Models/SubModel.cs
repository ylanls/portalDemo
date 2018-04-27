using portal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portalDemo.Models
{
    public class SubModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Date { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public TicketType Type { get; set; }
        public string UserId { get; set; }
        public SubModel()
        {
            Count = 1;
        }
        public SubDomainModel CoverToDomain()
        {
            return new SubDomainModel()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = this.UserId,
                Type = (int)Type,
                Count = Count,
                SubDate = Date,
                Total = Total
            };
        }
        public static SubModel GetModel(SubDomainModel model)
        {
            return new SubModel()
            {
                Name = model.Type == 0 ? "天门山国家森林公园登山成人票" : "天门山国家森林公园登山门票+往返观光车成人票",
                Price = model.Type == 0 ? 50 : 80,
                Count = model.Count,
                Total = model.Total,
                Date = model.SubDate
            };
        }
    }
    public enum TicketType : int
    {
        Single = 0,
        Double = 1
    }
}