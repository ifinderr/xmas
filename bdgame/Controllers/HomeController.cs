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
    
		//DateTime day_2 = DateTime.Parse("2023.12.11 19:10");
		//DateTime day_3 = DateTime.Parse("2023.12.11 19:12");
		//DateTime day_4 = DateTime.Parse("2023.12.11 19:14");
		//DateTime day_5 = DateTime.Parse("2023.12.11 19:16");
		//DateTime day_6 = DateTime.Parse("2023.12.11 19:18");
		//DateTime day_7 = DateTime.Parse("2023.12.11 19:20");


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
      var index = slide == null ? 1 : slide.ParamId + 1;

			ViewBag.Slide = index;
			ViewBag.Date = DateTime.Now.AddDays(index-1).ToString("yyyy.MM.dd").Substring(5,5);
			return View();

			//switch (index)
			//{
			//	case 1:
			//		return View();
			//	case 2:
			//		if (DateTime.Now > day_2)
			//		{
			//			return View();						
			//		}
			//		break;
			//	case 3:
			//		if (DateTime.Now > day_3)
			//		{
			//			return View();
			//		}
			//		break;
			//	case 4:
			//		if (DateTime.Now > day_4)
			//		{
			//			return View();
			//		}
			//		break;
			//	case 5:
			//		if (DateTime.Now > day_5)
			//		{
			//			return View();
			//		}
			//		break;
			//	case 6:
			//		if (DateTime.Now > day_6)
			//		{
			//			return View();
			//		}
			//		break;
			//	case 7:
			//		if (DateTime.Now > day_7)
			//		{
			//			return View();
			//		}
			//		break;
			//}

			//return RedirectToAction("Index");

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
