using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AZ_New_webapp_VS2022.Models;

namespace AZ_New_webapp_VS2022.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly AZ_New_webapp_VS2022.Models.AppDBContext _context;

        public IndexModel(AZ_New_webapp_VS2022.Models.AppDBContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees.ToListAsync();
        }
    }
}
