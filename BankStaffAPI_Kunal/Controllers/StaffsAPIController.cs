using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankStaffAPI_Kunal.Data;
using BankStaffAPI_Kunal.Models;

namespace BankStaffAPI_Kunal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StaffsAPI
        [HttpGet]
        public ActionResult<List<StaffVM>> GetStaffs()
        {
            //var data= _context.Staffs.Include(x => x.Designation).ToListAsync();
            List<StaffVM> svm = new List<StaffVM>();
            var data = (from s in _context.Staffs
                       join d in _context.Designations on s.DesignationID equals d.ID
                       select new 
                       {
                           s.ID,
                           s.Name,
                           s.Email,
                           s.Mobile,
                           s.Address,
                           s.EmpCode,
                           s.DesignationID,
                           s.Designation.DesignationName
                       }).ToList();
            foreach (var item in data)
            {
                StaffVM obj = new StaffVM();
                obj.ID = item.ID;
                obj.Name = item.Name;
                obj.Email = item.Email;
                obj.Mobile = item.Mobile;
                obj.Address = item.Address;
                obj.EmpCode = item.EmpCode;
                obj.DesignationID = item.DesignationID;
                obj.DesignationName = item.DesignationName;
                svm.Add(obj);
            }
            return svm;
        }

        // GET: api/StaffsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

        // PUT: api/StaffsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            if (id != staff.ID)
            {
                return BadRequest();
            }

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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

        // POST: api/StaffsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaff", new { id = staff.ID }, staff);
        }

        // DELETE: api/StaffsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Staff>> DeleteStaff(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();

            return staff;
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.ID == id);
        }
    }
}
