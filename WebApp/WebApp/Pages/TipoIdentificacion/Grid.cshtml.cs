using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WBL;

namespace WebApp.Pages.TipoIdentificacion
{
    public class GridModel : PageModel
    {
        private readonly ITipoIdentificacionService tipoIdentificacionService;

        public GridModel(ITipoIdentificacionService tipoIdentificacionService)
        {
            this.tipoIdentificacionService = tipoIdentificacionService;
        }
        public IEnumerable<TipoIdentificacionEntity> GridList {get; set;} = new List<TipoIdentificacionEntity>();

        public string Mensaje { get; set; } = "";
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await tipoIdentificacionService.Get();
                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }
                TempData.Clear();
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await tipoIdentificacionService.Delete(new() { IdTipoIdentificacion = id });
                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }
                TempData["Msg"] = "Se elimino correctamente";
                return Redirect("Grid");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
