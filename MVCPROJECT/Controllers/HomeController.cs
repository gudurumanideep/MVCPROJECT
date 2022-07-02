using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCPROJECT.Models;
using System.Diagnostics;

namespace MVCPROJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Home(string Login, string uname, string pwd, string mode)
        {
            string cs = "server=LAPTOP-N44MFQFK\\SQLEXPRESS;integrated security=true;database=ToyDB";
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();
            if (mode == "Admin")
            {
                string query = "select uname,password from tblAdmin";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string un = dr[0].ToString();
                    string pn = dr[1].ToString();

                    if (uname.Equals(un) && pwd.Equals(pn))
                    {
                        return Redirect("/AdminModels");
                    }
                    else
                    {
                        ViewData["message"] = "invalid credits";

                    }
                }

            }
            if (mode == "User")
            {
                string query = "select uname,password from UserModels";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string un = dr[0].ToString();
                    string pw = dr[1].ToString();
                    if (uname.Equals(un) && pwd.Equals(pw))
                    {
                        return Redirect("/ProductModels/DashboardPage");
                    }
                    else
                    {
                        ViewData["message"] = "Invalid Credentials....";
                    }


                }



            }
            return View();
        }
        public IActionResult Signup(int id,string uname, string email,string password,string mobile)
        {
            string cs = "server=LAPTOP-N44MFQFK\\SQLEXPRESS;integrated security=True;DataBase=ToyDB";
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();
            string query = "insert into UserModels(id,uname, email , password , mobile) values(@id, @uname, @email, @password, @mobile)";

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@uname", uname);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@mobile", mobile);

            ViewData["message"] = "Added Sucessfully";
           

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