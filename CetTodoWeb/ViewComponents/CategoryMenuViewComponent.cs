using CetTodoWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CetTodoWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
namespace CetTodoWeb.ViewComponents
{
    
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<CetUser> _userManager;
        public CategoryMenuViewComponent(ApplicationDbContext dbContext, UserManager<CetUser> userManager)
        {
            this.dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool ShowEmpty=true)
        {
            List<Category> items;
            if(User.Identity.IsAuthenticated)
			{
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                var query = dbContext.Categories.Where(t => t.CetUserId == currentUser.Id);
                items = await query.Where(c => ShowEmpty || c.TodoItems.Any()).ToListAsync();
            }
            else
			{
                items = await dbContext.Categories.Where(c => ShowEmpty).ToListAsync();
            }
            //var items = await dbContext.Categories.Where(c => ShowEmpty || c.TodoItems.Any()).ToListAsync();
            
            
            return View(items);
        }
    }
}
