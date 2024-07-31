using BooleanşMvcApp.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooleanşMvcApp.ViewComponents
{
    public class GroupFilterViewComponent : ViewComponent
    {
        private readonly BooleanStudentsContext _dbContext;

        public GroupFilterViewComponent()
        {
            _dbContext = new BooleanStudentsContext();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var groups = await _dbContext.Groups.ToListAsync();
            return View(groups);
        }
    }
}
