using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP4_Album.Models;
namespace TP4_Album.Controllers;

public class AlbumController : Controller
{
    BD bd = new BD();

    public IActionResult Index()
    {
        ViewBag.Album = bd.ObtenerAlbum(1);
        ViewBag.MiAlbum = bd.ObtenerMiAlbum(1);
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
        return RedirectToAction("Index");
    }
}