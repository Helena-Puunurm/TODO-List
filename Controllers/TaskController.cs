using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TARpe19TodoApp.Data;
using TARpe19TodoApp.Models;

namespace TARpe19TodoApp.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TaskController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetItems()
        {
            var items = _context.TaskItems.ToList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _context.TaskItems.FirstOrDefaultAsync(z => z.Id == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(TODOItem data)
        {
            if (ModelState.IsValid)
            {
                await _context.TaskItems.AddAsync(data);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetItem", new { data.Id }, data);
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, TODOItem item)
        {
            if (id != item.Id)
                return BadRequest();

            var existItem = await _context.TaskItems.FirstOrDefaultAsync(z => z.Id == id);

            if (existItem == null)
                return NotFound();

            existItem.Expected_Deadline = item.Expected_Deadline;
            existItem.Task_Size = item.Task_Size;
            existItem.Study_Materials = item.Study_Materials;
            existItem.Task_Type = item.Task_Type;
            existItem.Information = item.Information;
            existItem.Description = item.Description;

            await _context.SaveChangesAsync();

            // Following up the REST standart on update we need to return NoContent
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var existItem = await _context.TaskItems.FirstOrDefaultAsync(z => z.Id == id);

            if (existItem == null)
                return NotFound();

            _context.TaskItems.Remove(existItem);
            await _context.SaveChangesAsync();

            return Ok(existItem);
        }
    }
}
