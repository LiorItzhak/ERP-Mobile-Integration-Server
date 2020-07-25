using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_Api.Pages.Forms
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DownloadEmployeesTimeClockModel : PageModel
    {
        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; } = DateTime.Now;
        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; } = DateTime.Now;

        public void OnGet()
        {
            
        }
        
        public IActionResult OnPost()
        {
            var url = $"~/api/EmployeesTimeClock/CSV?fromDate={FromDate.Date:yyyy-MM-dd}&toDate={ToDate.Date:yyyy-MM-dd}";
            return  Redirect(url);
        }
        
    }
}