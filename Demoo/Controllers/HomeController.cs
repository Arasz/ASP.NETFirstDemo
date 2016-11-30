using Demoo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demoo.Controllers
{
    /// <summary>
    /// Kontroler HomeController odpowiedzialny za obrabianie danych i wyświetlanie widoków z folderu Views/Home
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Statyczna lista kontaktów wykorzystywana przez aplikację do zapisywania danych. Imitacja bazy danych
        /// </summary>
        static List<Contact> contacts = new List<Contact>();

        // GET: Home
        /// <summary>
        /// Akcja zwracająca widok wraz z listą wszystkich kontaktów dostępnych w aplikacji
        /// </summary>
        /// <returns>Widok Index z katalogu Home wyświetlający wszystkie kontakty</returns>
        public ActionResult Index()
        {
            return View(contacts);
        }

        //GET: Add
        /// <summary>
        /// Akcja zwracająca widok któremu przekazuje jako model nową instancję klasy Contact
        /// </summary>
        /// <returns>Widok Add z katalogu Home wyświetlający formularz dodawania nowego kontaktu</returns>
        public ActionResult Add()
        {
            return View(new Contact());
        }
        //POST: Add
        /// <summary>
        /// Akcja która obsługuje wysłanie formularza z nowym kontaktem i dodaje go do listy wszystkich kontaktów.
        /// </summary>
        /// <param name="contact">Kontakt wysłany w formularzu z widoku Add</param>
        /// <returns>Przekierowanie do akcji Index, która zwraca widok z wszystkimi kontaktami</returns>
        [HttpPost]
        public ActionResult Add(Contact contact)
        {
            contacts.Add(contact);
            return RedirectToAction("Index");
        }

        //GET: Edit
        /// <summary>
        /// Akcja która wybiera interesujący nas kontakt z listy wszystkich kontaktów
        /// i zwraca go jako model dla danego widoku
        /// </summary>
        /// <param name="id">Id kontaktu który chcemy edytować</param>
        /// <returns>Widok formularza do edytowania danego kontaktu</returns>
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var contact = contacts.Where(x => x.Id == id).First();
            return View(contact);
        }

        //POST: Edit
        /// <summary>
        /// Akcja która przyjmuje instancję klasy Contact którą chcemy edytować.
        /// Edycja odbywa się poprzez usunięcie danego kontaktu z listy i dodaniu go na nowo z odświeżonymi informacjami
        /// </summary>
        /// <param name="contact">Kontakt który został poddany edycji w formularzu z widoku Edit</param>
        /// <returns>Przekierowanie do akcji Index, która zwraca widok z wszystkimi kontaktami</returns>
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            contacts.Remove(contacts.Where(x => x.Id == contact.Id).First());
            contacts.Add(contact);
            return RedirectToAction("Index");
        }
    }
}