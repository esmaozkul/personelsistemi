using Libraries.Services.PersonelIslemleri;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.Models;
using WebShared.CO;
using WebShared.DTO;
namespace WebApplication1.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        // 1- Logger: Hata veya bilgi loglarý için
        private readonly ILogger<HomeController> _logger;

        // 2- Servis field: Controller metodlarýndan servisi kullanabilmek için
        private readonly IPersonelIslemleriService _personelService;

        // 3- Constructor: Dependency Injection ile servis ve logger inject ediliyor
        public HomeController(ILogger<HomeController> logger, IPersonelIslemleriService personelService)
        {
            _logger = logger;
            _personelService = personelService;
        }
        [HttpPost("PersonelListeGetir")]
        public async Task<IActionResult> PersonelListeGetir([FromBody] PersonelListeCO kriter)
        //public void PersonelListeGetir([FromBody] string[] Id /*PersonelListeCO kriter*/)
        {
            //Burada servis çaðrýsý yapacaðýz. Unutma : //Dependency Injection
            //1 - Libraries.Services projesi oluþturacaðýz. (*)
            //Interface ve servis classlarý olacak:  (*)
            //--Libraries.Services (*)
            //----PersonelIslemleri (Klasör) (*)
            //------IPersonelIslemleri.cs (Interface) (*)
            //------PersonelIslemleri.cs (IPersonelIslemleri interface'inden türeyecek) Veri getirme ve kaydetme methodlarý bu cs içerisinde olacak. (*)


            //BURADA servis çaðrýsýný yap
            if (kriter == null)
            {
                return BadRequest("Filtre kriteri boþ olamaz");
            }

            // Servisi çaðýrýyoruz, controller ApplicationDbContext görmez
            PersonelListeDTO[] liste = await _personelService.PersonelListeGetirAsync(kriter);

            return Json(liste);

        }
        [HttpGet("Index")]
        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
