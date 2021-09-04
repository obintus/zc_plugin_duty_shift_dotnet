﻿using App.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static IMongoCollection<Users> _usersCollection;

        public UsersController(IMongoClient client)
        {
            var database = client.GetDatabase("zuri_tracker");
            _usersCollection = database.GetCollection<Users>("testUsers");
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _usersCollection.Find(_ => true).ToList();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromForm] Users user)
        {
            _usersCollection.InsertOne(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
