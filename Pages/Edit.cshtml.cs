using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Runtime.CompilerServices;
using ToDoList.Models;

namespace ToDoList.Pages
{
    public class EditModel : PageModel
    {
        public Item? ItemToEdit { get; set; }
        private ItemContext _context { get; set; }

        public EditModel (ItemContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ItemToEdit = await _context.Items.FindAsync(id);

            if(ItemToEdit == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, string name = "n/a", string description = "n/a")
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            Item? newItem = await _context.Items.FindAsync(id);

            if (newItem == null)
            {
                return NotFound();
            }

            newItem.Name = name;
            newItem.Description = description;

            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
