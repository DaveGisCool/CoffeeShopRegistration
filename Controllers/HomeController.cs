using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShopRegistration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public void PasswordMismatch()
        {
            ViewBag.PasswordMatchFail = $"Sorry, passwords did not match. Please try again.";
        }

        public void OutsideZipCode()
        {
            ViewBag.UnregisterableZipCode = $"Sorry, we are only accepting registrations from 48044 at this time.";
        }

        public ActionResult Submit(string firstname, string lastname, string emailaddress, string phonenumber, string birthdate, string zipcode, string favoritedrink, string password, string passwordconfirm)
        {
            if (password != passwordconfirm)
            {
                PasswordMismatch();
                ViewBag.PasswordStatusMessage = "Your passwords did not match.";
                return View("Register");
            }else if (zipcode != "48044")
            {
                OutsideZipCode();
                return View("Register");
            }
            ViewBag.Success = $"Welcome, {firstname} {lastname}!";
            ViewBag.EmailConfirm = $"A confirmation email has been sent to: {emailaddress} and a text message confirmation has been sent to {phonenumber}.";
            ViewBag.DetailsConfirm = $"Your birthdate is {birthdate}, look for a coupon for a {favoritedrink} on your special day. We will be excited to see you around {zipcode}!";

            return View();
        }

        public void PickupOrder(string sizeselection, string drinkselection, string chosentime)
        {
            ViewBag.ByPickup = $"Your order of a {sizeselection} {drinkselection} will be ready for pickup at approximately {chosentime}";
        }

        public void DeliverOrder(string sizeselection, string drinkselection, string chosentime, string homeaddress)
        {
            ViewBag.ByDelivery = $"Your order of a {sizeselection} {drinkselection} will be delivered at approximately {chosentime} to {homeaddress}";
        }

        public ActionResult Shop(string firstname, string lastname, string homeaddress, string drinkselection, string sizeselection, string pickup, string chosentime)
        {
            if (pickup == "choosepickup")
            {
                PickupOrder(sizeselection, drinkselection, chosentime);
                return View("Confirm");
            }
            else if (pickup == "choosedeliver")
            {
                DeliverOrder(sizeselection, drinkselection, chosentime, homeaddress);
                return View("Confirm");
            }
            ViewBag.Message = " ";

            return View();
        }

        public ActionResult Confirm(string firstname, string lastname, string homeaddress, string drinkselection, string sizeselection, string chosentime)
        {
            ViewBag.Message = "Confirm your order details.";
            //display order details for confirmation (changing for pickup/delivery) then allow user to confirm order
            return View();
        }

        public ActionResult Final(string firstname, string lastname, string homeaddress, string drinkselection, string sizeselection, string chosentime)
        {
            //accept values from Confirm and display relevant results
            ViewBag.Message = "Here are your order details for order #090920200001";
            ViewBag.Name = $"Thank you for your order, {firstname} {lastname}";
            ViewBag.ByPickup = $"Your order of a {sizeselection} {drinkselection} will be ready for pickup at approximately {chosentime}";
            ViewBag.ByDelivery = $"Your order of a {sizeselection} {drinkselection} will be delivered at approximately {chosentime} to {homeaddress}";
            return View();
        }
    }
}