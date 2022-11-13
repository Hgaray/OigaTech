using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OigaTech.BusinessRules;
using OigaTech.Dto;

namespace UserApi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserBusinessRules _userBusinessRules;
        public IndexModel(ILogger<IndexModel> logger, IUserBusinessRules userBusinessRules)
        {
            _logger = logger;
            _userBusinessRules = userBusinessRules;
        }

        public void  OnGet()
        {

        }
    }
}