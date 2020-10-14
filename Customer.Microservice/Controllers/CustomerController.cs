﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Microservice.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customer.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IApplicationDbContext _context;
        public CustomerController(IApplicationDbContext context)
        {
            _context = context;
        }

        //Gemmer en ny kunde og retuner et id
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChanges();
            return Ok(customer.Id);
        }

        // Henter en liste af kunder
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _context.Customers.ToListAsync();
            if (customers == null) return NotFound();
            return Ok(customers);
        }
        // Henter en kunde udfra Id 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _context.Customers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        // Sletter en en kunde udfra Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (customer == null) return NotFound();
            _context.Customers.Remove(customer);
            await _context.SaveChanges();
            return Ok(customer.Id);
        }

        // Opdater en kunde ud fra Id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Customer customerData)
        {
            var customer = _context.Customers.Where(a => a.Id == id).FirstOrDefault();

            if (customer == null) return NotFound();
            else
            {
                customer.City = customerData.City;
                customer.Name = customerData.Name;
                customer.Contact = customerData.Contact;
                customer.Email = customerData.Email;
                await _context.SaveChanges();
                return Ok(customer.Id);
            }
        }
    }
}

