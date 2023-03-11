using Microsoft.AspNetCore.Mvc;

namespace EnvironmentsExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        public HomeController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        [Route("/")]
        [Route("some-route")]
        public IActionResult Index()
        {
            EmployeeOptions configs =  _configuration.GetSection("Employee").Get<EmployeeOptions>();

            ViewBag.EmpID = configs.Eno;
            ViewBag.EmpName = configs.Ename;
            ViewBag.Salary = configs.Salary;

            //ViewBag.EmpID = _configuration["Employee:Eno"];
            ////ViewBag.EmpName = _configuration["Employee:Ename"];
            ////ViewBag.Salary = _configuration["Employee:Salary"];
            //ViewBag.EmpName = _configuration.GetSection("Employee")["Ename"];
            //ViewBag.Salary = _configuration.GetSection("Employee")["Salary"];

            ViewBag.MyKey = _configuration.GetValue("MyKey", "Default Value");
            ViewBag.CurrentEnvironent = _webHostEnvironment.EnvironmentName;
            return View();
        }
        [Route("some-route")]
        public ActionResult Other()
        {
            return View();
        }
    }
}
