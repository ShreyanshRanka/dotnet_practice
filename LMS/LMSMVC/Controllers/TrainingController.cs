using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LMSMVC.Models;
using System.Text.Json;

namespace LMSMVC.Controllers;

public class TrainingController : Controller
{
    private readonly LMSContext _lMSContext;

    public TrainingController(LMSContext lMSContext)
    {
        _lMSContext = lMSContext;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            string userJSON = JsonSerializer.Serialize(user);
            System.IO.File.WriteAllText("user.json", userJSON);
            return RedirectToAction("Login");
        }
        return RedirectToAction("TrainingError");
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(User user)
    {
        string userJSON = System.IO.File.ReadAllText("user.json");
        var validUser = JsonSerializer.Deserialize<User>(userJSON);

        if (validUser.Email == user.Email && validUser.Password == user.Password && validUser != null && user != null)
        {
            return RedirectToAction("Index");
        }
        return RedirectToAction("TrainingError");
    }

    public IActionResult Index()
    {
        List<Training> list = _lMSContext.training.ToList();
        ViewBag.list = list;
        return View();
    }

    public IActionResult Create() {
        return View();
    }
    [HttpPost]
    public IActionResult Add(Training training) {
        _lMSContext.training.Add(training);
        _lMSContext.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        Training training = _lMSContext.training.Find(id);
        return View(training);
    }
    [HttpPost]
    public IActionResult Update(Training training)
    {
        _lMSContext.training.Update(training);
        _lMSContext.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id) {
        _lMSContext.training.Remove(_lMSContext.training.Find(id));
        _lMSContext.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult TrainingError()
    {
        return Content("Error in some method");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
