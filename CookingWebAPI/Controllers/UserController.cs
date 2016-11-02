﻿using Cooking.Entities;
using Cooking.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CookingWebAPI.Controllers
{
    [EnableCors( origins: "*", headers: "*", methods: "*" )]
    public class UserController : ApiController
    {
        private IUserService userService;

        public UserController( IUserService _iUserService )
        {
            this.userService = _iUserService;
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    User user =this.userService.Get(id);
                    response = Request.CreateResponse<User>( HttpStatusCode.OK, user );
                }
                catch( Exception e )
                {
                    response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, e );
                }

                return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                List<User> users =this.userService.Get();
                response = Request.CreateResponse<List<User>>( HttpStatusCode.OK, users );
            }
            catch (Exception e)
            { 
                response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, e );
            }
            return response;

        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]User u )
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                if( this.userService.Add( u ) )
                    response = Request.CreateResponse<User>( HttpStatusCode.OK, u );
            }
            catch( Exception e )
            {
                response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, e );
            }
            return response;
        }
    }
}