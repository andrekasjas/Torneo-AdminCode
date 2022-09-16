using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.DTs
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioDT _repoDt;
        public DirectorTecnico directorTecnico { get; set; }

        public EditModel(IRepositorioDT repoDt)
        {
            _repoDt = repoDt;
        }


        public IActionResult OnGet(int id)
        {
            directorTecnico = _repoDt.GetDT(id);

            if (directorTecnico == null)
            {
                return NotFound();
            }
            else
            {
                return Page();


            }
        }

        public IActionResult OnPost(DirectorTecnico directorTecnico)
        {
            _repoDt.UpdateDT(directorTecnico);
            return RedirectToPage("Index");
        }




    }

}
