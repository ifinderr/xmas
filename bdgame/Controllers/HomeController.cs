using bdgame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace bdgame.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly EnglishContext _context;

    public HomeController(ILogger<HomeController> logger,EnglishContext eglishContext)
    {
      _logger = logger;
      _context = eglishContext;
    }

    public IActionResult Index()
    {
      return View();
    }

    public async Task<IActionResult> Game()
    {
      var slide = await _context.Params.Where(x => x.ParamValue == 1).OrderByDescending(x => x.ParamId).FirstOrDefaultAsync();
      ViewBag.Slide = slide == null ? 1 : slide.ParamId + 1;

      return View();
    }

		public IActionResult Error()
		{
			return View();
		}

		public IActionResult Privacy()
    {
      return View();
    }

		[HttpPost]
		public async Task<IActionResult> SaveIndex(int index)
    {
      var slide = await _context.Params.FirstOrDefaultAsync(x => x.ParamId == index);
      slide.ParamValue = 1;
      slide.RefreshDate = DateTime.Now;
      await _context.SaveChangesAsync();

      return Ok();

		}

		[HttpPost]
		public async Task<IActionResult> GetSlideIndex()
		{
			var slide = await _context.Params.Where(x => x.ParamValue == 1).OrderByDescending(x => x.ParamId).FirstOrDefaultAsync();
			return Ok(slide == null ? 1 : slide.ParamId + 1);

		}

		public IActionResult Gift()
		{
			return View();
		}

	}
}
