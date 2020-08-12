using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;

namespace WebTest
{
    [Authorize]
    [RoutePrefix("api/orders")]
    public class OrderController : ApiController
    {
        private Model.DbModel db = new Model.DbModel();

        [Route]
        public IHttpActionResult Put(Order model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Orders.Add(model);
            db.SaveChanges();
            return Ok(model);
        }

        [Route]
        public IHttpActionResult Get(int id)
        {
            var order = db.Orders.Find(id);
            if (order == null)
            {
                return BadRequest("订单ID不存在！");
            }
            return Ok(order);
        }

        //[Route("select")]
        //public IHttpActionResult Post(Order order)
        //{
        //    var db = new Model.Model();
        //    var orders = from each in db.Orders where each.CustomerName.Contains(order.CustomerName) && each.ShipperCity.Contains(order.ShipperCity) && each.IsShipped == order.IsShipped select each;
        //    return Ok(orders);
        //}

        [Route]
        public IHttpActionResult Delete(int id)
        {
            var order = db.Orders.Find(id);
            if (order == null)
            {
                return BadRequest("订单ID不存在！");
            }
            db.Orders.Remove(order);
            db.SaveChanges();
            return Ok(order);
        }

        [Route]
        public IHttpActionResult Post(Order model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = db.Orders.Find(model.Id);
            if (order == null)
            {
                return BadRequest("订单ID不存在！");
            }
            order.CustomerName = model.CustomerName;
            order.ShipperCity = model.ShipperCity;
            order.IsShipped = model.IsShipped;
            order.PhoneNumber = model.PhoneNumber;
            db.Entry(order).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(model);
        }
    }

    [Authorize]
    [RoutePrefix("api/orders/select")]
    public class OrderSelectController : ApiController
    {
        private Model.DbModel db = new Model.DbModel();

        [Route]
        public IHttpActionResult Post(OrderInfo info)
        {
            var orders = from each in db.Orders where (info.CustomerName == null || each.CustomerName.Contains(info.CustomerName)) && (info.ShipperCity == null || each.ShipperCity.Contains(info.ShipperCity)) && (info.ShipState < 0 || each.IsShipped == info.IsShipped) && (info.StartTime == DateTime.MinValue || each.CreateTime >= info.StartTime) && (info.EndTime == DateTime.MinValue || each.CreateTime <= info.EndTime) orderby each.Id select each;
            info.TotalCount = orders.Count();
            int maxPageIndex = info.MaxPageIndex;
            if (info.PageIndex > maxPageIndex)
            {
                info.PageIndex = maxPageIndex;
            }
            else if (info.PageIndex < 0)
            {
                info.PageIndex = 1;
            }
            int skipCount = (info.PageIndex - 1) * info.PageSize;
            info.Orders = skipCount > 0 ? orders.Skip(skipCount).Take(info.PageSize).ToList() : orders.Take(info.PageSize).ToList();
            return Ok(info);
        }

        //public IList<TEntity> GetPaged<TEntity>(out int total, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int index = 1, int size = 20) where TEntity : class
        //{
        //    int skipCount = (index - 1) * size;
        //    var _reset = Get(filter, orderBy);
        //    total = _reset.Count();
        //    _reset = skipCount > 0 ? _reset.Skip(skipCount).Take(size) : _reset.Take(size);
        //    return _reset.ToList();
        //}

        //public IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null) where TEntity : class
        //{
        //    IQueryable<TEntity> query = db.Set<TEntity>();
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }
        //    if (orderBy != null)
        //    {
        //        return orderBy(query).AsQueryable();
        //    }
        //    else
        //    {
        //        return query.AsQueryable();
        //    }
        //}
    }


}