﻿using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Authorization.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        [Authorize(Roles ="Admin, Supervisor")]
        public IEnumerable<string>  Get()
        {
            IOwinContext ctx = Request.GetOwinContext();
            string id = ctx.Authentication.User.Claims.FirstOrDefault(x => x.Type == "UserID").Value;
            return  new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
       [AllowAnonymous]
        public  string Get(int id)
        {
            return  "value";
        }
                
        // POST: api/Default
        [Authorize(Roles = "Admin, Supervisor")]
       public CustomModel Post([FromBody]CustomModel model)
        {
            return model;
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }

    public class CustomModel
    {
        public string Name { get; set; }
    }
}
