using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using SQLitePCL;
using ToDoList.Models;

namespace ToDoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly ItemContext _context;

        public List<Item> ItemsList { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ItemContext context)
        {
            _logger = logger;
            _context = context;
            ItemsList = _context.Items.ToList();
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
