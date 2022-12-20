namespace Laskutussovellus_Harjoitustyo {
    /// <summary>
    /// Luokka laskuttajan tiedoille.
    /// </summary>
    internal static class Biller { // staattinen luokka yrityksen osoitetiedoille, sillä tätä sovellusta tehdään yhden yrityksen käyttöön
        /// <summary>
        /// Laskuttajan osoitetiedot.
        /// </summary>
        public static Address Address { get; private set; }

        static Biller() {
            Address = new Address("Rakennus Oy", "Karjalankatu 3", 80200, "Joensuu");
        }
    }
}
