using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KillerApp.Factory;
using KillerApp.Logic;
using Model;

namespace KillerApp.View.Controllers
{
    public class StudentenhuisController : Controller
    {
        StudentenhuisLogic studentenhuislogic = StudentenhuisFactory.UseSqlContext();

        public IActionResult Index()
        {
            return View(studentenhuislogic.GetallStudentenhuizen());
        }
    }
}