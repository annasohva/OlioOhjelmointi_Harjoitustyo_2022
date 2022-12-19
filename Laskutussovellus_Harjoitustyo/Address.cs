namespace Laskutussovellus_Harjoitustyo {
    /// <summary>
    /// Luokka osoitetietoja varten.
    /// </summary>
    internal class Address {
        public string StreetAddress { get; private set; } = string.Empty; // ominaisuudet on private set, koska niitä muutetaan metodien avulla
        public int PostalCode { get; private set; } = -1;
        public string City { get; private set; } = string.Empty;

        /// <summary>
        /// Konstruktori tyhjän osoitteen luomiseen.
        /// </summary>
        public Address() {

        }

        /// <summary>
        /// Konstruktori jonka avulla asetetaan osoitetiedot.
        /// </summary>
        /// <param name="streetAddress">Katuosoite</param>
        /// <param name="postalCode">Postinumero</param>
        /// <param name="city">Kaupunki / Postitoimipaikka</param>
        public Address(string streetAddress, int postalCode, string city) {
            ChangeAddress(streetAddress, postalCode, city);
        }

        /// <summary>
        /// Metodi jonka avulla muutetaan osoitetiedot.
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
        /// Metodi jonka avulla haetaan osoiterivit.
        /// </summary>
        /// <returns>String-taulukko: [0]: katuosoite, [1]: postinumero + " " + postitoimipaikka</returns>
        public string[] GetAddressLines() {
            return new string[2] { StreetAddress, PostalCode + " " + City };
        }
    }
}
