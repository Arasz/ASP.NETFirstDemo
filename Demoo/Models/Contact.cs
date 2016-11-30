using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demoo.Models
{
    /// <summary>
    /// Klasa modelu danych, reprezentuje jeden kontakt
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Id które jest nadawane w konstruktorze
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Imię danego kontaktu
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Nazwisko danego kontaktu
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Numer telefonu danego kontaktu.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Adres email danego kontaktu
        /// </summary>
        // Adnotacja [EmailAddress] jest elementem walidacji danych. 
        // MVC zadba by input i jego walidacja wgenerowana dla tego pola była dostosowana pod adres email
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// Wielolinijkowa notatka na temat danego kontaktu. 
        /// </summary>
        // Dzięki adnotacji [DataType(DataType.MultilineText)] Razor przy generacji tego pola
        // wygeneruje input który pozwoli na wprowadzanie wieloliniowego tekstu
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

        /// <summary>
        /// Statyczna instancja klasy Random która pozwala na generowanie losowych Id dla kontaktów
        /// </summary>
        static private Random _idGenerator = new Random();

        /// <summary>
        /// Konstruktor bezparametrowy który tworząc instancję obiektu nadaje mu Id
        /// </summary>
        public Contact()
        {
            Id = _idGenerator.Next();
        }


    }
}