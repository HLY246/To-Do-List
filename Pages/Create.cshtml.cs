using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Pages
{
    public class CreateModel : PageModel
    {

        private readonly ItemContext _context;
        public CreateModel(ItemContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string name, string description)
        {
            Item itemToAdd = new Item();
            itemToAdd.Name = name;
            itemToAdd.Description = description;

            _context.Items.Add(itemToAdd);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }

    }
}
