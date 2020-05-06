using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankOfSimba.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankOfSimba.Controllers
{
    
    public class HomeController : Controller
    {
        static List<BankAccount> accountList;
        [HttpGet("show")]
        public IActionResult Index()
        {
            var bankAccount = new BankAccount("Simba", 2000.00m, "lion", true, false);
            return View(bankAccount);
        }
        [HttpGet("")]
        public IActionResult HtmlCeption()
        {
            var message = "This is an <em>HTML</em> text. <b>Enjoy yourself!</b>";
            return View(message as Object);
        }
        [HttpGet("list-all")]
        public IActionResult ListAll()
        {
            accountList = InitiateList();
            return View(accountList);
        }
        [HttpPost("increase")]
        public IActionResult Increase(int account)
        {
            accountList[account].IncreaseBalance();
            return View("ListAll", accountList);
        }
        [HttpPost("toggleking")]
        public IActionResult ToggleKing(int account)
        {
            accountList[account].ToggleKing();
            return View("ListAll", accountList);
        }
        [Route ("create")]
        public IActionResult CreateNewAccount(string name, decimal balance, string species, bool isKing, bool isGoodGuy)
        {
            if(name==null || species ==null)
            return View();
            HomeController.accountList = InitiateList();
            HomeController.accountList.Add(new BankAccount(name, balance, species, isGoodGuy, isKing));
            return View("ListAll", accountList);
        }
        public List<BankAccount> InitiateList()
        {
            if (HomeController.accountList?.Count>0)
            {
                return HomeController.accountList;
            }
            var accountList = new List<BankAccount>();
            accountList.Add(new BankAccount("Simba", 2000.00m, "lion", true, false));
            accountList.Add(new BankAccount("Mufasa", 99999.99m, "lion", true, true));
            accountList.Add(new BankAccount("Scar", 1337.42m, "lion", false, false));
            accountList.Add(new BankAccount("Nala", 50.00m, "lion", true, false));
            accountList.Add(new BankAccount("Zazu", 3636.36m, "bird", true, false));
            accountList.Add(new BankAccount("Timon", 1234.56m, "meerkat", true, false));
            return accountList;
        }
    }
}