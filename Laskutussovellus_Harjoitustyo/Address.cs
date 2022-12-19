namespace Laskutussovellus_Harjoitustyo {
    /// <summary>
    /// Luokka osoitetietoja varten.
    /// </summary>
    internal class Address {
        public string Name { get; private set; } = string.Empty; // ominaisuudet on private set, koska niitä muutetaan metodien avulla
        public string StreetAddress { get; private set; } = string.Empty;
        public int PostalCode { get; private set; } = -1;
        public string City { get; private set; } = string.Empty;

        /// <summary>
        /// Konstruktori jonka avulla asetetaan osoitetiedot.
        /// </summary>
        /// <param name="name">Yrityksen tai henkilön nimi</param>
        /// <param name="streetAddress">Katuosoite</param>
        /// <param name="postalCode">Postinumero</param>
        /// <param name="city">Kaupunki / Postitoimipaikka</param>
        public Address(string name, string streetAddress, int postalCode, string city) {
            Name = name;
            ChangeAddress(streetAddress, postalCode, city);
        }

        /// <summary>
        /// Metodi jonka avulla muutetaan osoite.
        /// </summary>
        /// <param name="streetAddress">Katuosoite</param>
        /// <param name="postalCode">Postinumero</param>
        /// <param name="city">Kaupunki / Postitoimipaikka</param>
        public void ChangeAddress(string streetAddress, int postalCode, string city) {
            StreetAddress = streetAddress;
            PostalCode = postalCode;
            City = city.ToUpper();
        }

        /// <summary>
        /// Metodi jonka avulla muutetaan osoitetietoihin nimi.
        /// </summary>
        /// <param name="name">Yrityksen tai henkilön nimi.</param>
        public void ChangeName(string name) {
            Name = name;
        }

        /// <summary>
        /// Metodi jonka avulla haetaan osoiterivit.
        /// </summary>
        /// <returns>String-taulukko: [0]: yrityksen tai henkilön nimi, [1]: katuosoite, [2]: postinumero + " " + postitoimipaikka</returns>
        public string[] GetAddressLines() {
            return new string[3] { Name, StreetAddress, PostalCode + " " + City };
        }
    }
}
