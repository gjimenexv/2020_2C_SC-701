using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = Solution.DO.Objects;
using Solution.BS;
using Solution.DAL.EF;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public AuthorsController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Authors>>> GetAuthors()
        {
            return new Authors(_context).GetAll().ToList(); //Consulta el constructor de la clase Authors del BS
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Authors>> GetAuthors(int id)
        {
            var authors = new Authors(_context).GetOneById(id);

            if (authors == null)
            {
                return NotFound();
            }

            return authors;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthors(int id, data.Authors authors)
        {
            if (id != authors.AuId)
            {
                return BadRequest();
            }

            // _context.Entry(authors).State = EntityState.Modified;

            try
            {
                new Authors(_context).Updated(authors);
            }
            catch (Exception ee)
            {
                throw ee;
            }

            return NoContent();
        }

        // POST: api/Authors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Authors>> PostAuthors(data.Authors authors)
        {
            new Authors(_context).Insert(authors);
            return CreatedAtAction("GetAuthors", new { id = authors.AuId }, authors);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Authors>> DeleteAuthors(int id)
        {
            var authors = new Authors(_context).GetOneById(id);
            if (authors == null)
            {
                return NotFound();
            }

            new Authors(_context).Delete(authors);
            await _context.SaveChangesAsync();

            return authors;
        }
    }
}