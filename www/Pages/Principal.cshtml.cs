using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace www.Pages
{
    public class PrincipalModel : PageModel
    {
        public string UserName { get; set; }
        public IActionResult OnGet()
        {
            PrincipalModel model = new PrincipalModel();
            string nomeDoUsuario = "Nome do Usuário";

            model.UserName = nomeDoUsuario;

            return Page();
        }


    }
}
