﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGit.Data;
using ProjectGit.Models;

namespace ProjectGit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ProjectGitContext _context;

        public TeachersController(ProjectGitContext context)
        {
            _context = context;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teachers>>> GetTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teachers>> GetTeachers(int id)
        {
            var teachers = await _context.Teachers.FindAsync(id);

            if (teachers == null)
            {
                return NotFound();
            }

            return teachers;
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeachers(int id, Teachers teachers)
        {
            if (id != teachers.Id)
            {
                return BadRequest();
            }

            _context.Entry(teachers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teachers>> PostTeachers(Teachers teachers)
        {
            _context.Teachers.Add(teachers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeachers", new { id = teachers.Id }, teachers);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeachers(int id)
        {
            var teachers = await _context.Teachers.FindAsync(id);
            if (teachers == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teachers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeachersExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
