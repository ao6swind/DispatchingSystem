using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.DbContexts;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private DbDispatchingSystem context;
        public DepartmentsController(DbDispatchingSystem _context)
        {
            context = _context;
        }
        
        // GET api/departments
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                return Ok(context.Departments.ToList());
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }


        // GET api/departments/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                Department department = context.Departments.Find(id);
                if(department != null)
                    return Ok(context.Departments.Find(id));
                else
                    return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            try
            {
                department.CreatedAt = DateTime.Now;
                department.UpdatedAt = DateTime.Now;
                context.Departments.Add(department);
                context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Department data)
        {
            Department department = context.Departments.Find(id);
            if(department == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    department.Name = data.Name;
                    department.UpdatedAt = DateTime.Now;
                    context.Departments.Update(department);
                    context.SaveChanges();
                    return Ok();
                }
                catch(Exception ex)
                {
                    return BadRequest();
                }
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Department department = context.Departments.Find(id);
            if(department == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    context.Departments.Remove(department);
                    context.SaveChanges();
                    return Ok();
                }
                catch(Exception ex)
                {
                    return BadRequest();
                }
            }
            
        }
    }
}
