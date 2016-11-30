using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Facade;
using GakuenDLL.Interface;

namespace GakuenAPI.Controllers
{
    public class OrderListsController : ApiController
    {
        private readonly IRepository<OrderList> _db = new RepositoryFacade().GetOrderListRepository();

        // GET: api/OrderLists
        public List<OrderList> GetOrderLists()
        {
            return _db.ReadAll();
        }

        // GET: api/OrderLists/5
        [ResponseType(typeof(OrderList))]
        public IHttpActionResult GetOrderList(int id)
        {
            OrderList orderList = _db.Read(id);
            if (orderList == null)
            {
                return NotFound();
            }

            return Ok(orderList);
        }

        // PUT: api/OrderLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderList(int id, OrderList orderList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderList.Id)
            {
                return BadRequest();
            }
            
            try
            {
                _db.Update(orderList);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrderLists
        [ResponseType(typeof(OrderList))]
        public IHttpActionResult PostOrderList(OrderList orderList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Create(orderList);

            return CreatedAtRoute("DefaultApi", new { id = orderList.Id }, orderList);
        }

        // DELETE: api/OrderLists/5
        [ResponseType(typeof(OrderList))]
        public IHttpActionResult DeleteOrderList(int id)
        {
            OrderList orderList = _db.Read(id);
            if (orderList == null)
            {
                return NotFound();
            }

            _db.Delete(orderList);
            

            return Ok(orderList);
        }

 
        private bool OrderListExists(int id)
        {
            return _db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}