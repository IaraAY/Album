using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TP4_Album.Controllers;

public class AlbumController : Controller
{
    BD bd = new BD();

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult MiAlbum()
    {
        ViewBag.Figuritas = bd.ObtenerAlbum(1);
        return View();
    }

    public IActionResult AbrirSobre()
    {
        ViewBag.Sobre = bd.AbrirSobre();
        return View();
    }

    [HttpPost]
    public IActionResult ConfirmarSobre(List<int> idsFiguritas)
    {
        bd.GuardarSobre(1, idsFiguritas);

        return RedirectToAction("MiAlbum");
    }


}