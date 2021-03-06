﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEnterpriseDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEnterpriseDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EnterpriseController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Enterprise> Get()
        {
            return context.Enterprises.ToList();
        }

        [HttpGet("{id}", Name = "EnterpriseCreate")]
        public IActionResult GetById(int id)
        {
            var enterprise = context.Enterprises.Include(x => x.Employees).FirstOrDefault(x => x.Id == id);

            if (enterprise == null)
            {
                return NotFound();
            }

            return Ok(enterprise);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                context.Enterprises.Add(enterprise);
                context.SaveChanges();
                return new CreatedAtRouteResult("EnterpriseCreate", new { id = enterprise.Id }, enterprise);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Enterprise enterprise, int id)
        {
            if (enterprise.Id != id)
            {
                return BadRequest();
            }

            context.Entry(enterprise).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var enterprise = context.Enterprises.FirstOrDefault(x => x.Id == id);

            if (enterprise == null)
            {
                return NotFound();
            }

            context.Enterprises.Remove(enterprise);
            context.SaveChanges();
            return Ok(enterprise);
        }
    }
}