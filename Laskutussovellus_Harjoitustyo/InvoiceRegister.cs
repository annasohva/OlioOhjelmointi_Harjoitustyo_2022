namespace Laskutussovellus_Harjoitustyo {
    /// <summary>
    /// Luokka joka sisältää kaikki laskut.
    /// </summary>
    internal class InvoiceRegister : BaseRegister<Invoice> {
        /// <summary>
        /// Lisää uuden laskun rekisteriin ja asettaa laskulle yksilöivän numeron.
        /// </summary>
        /// <param name="invoice">Lasku joka lisätään rekisteriin.</param>
        public override void AddItem(Invoice invoice) {
            if (items.Contains(invoice) == false) {
                base.AddItem(invoice);
                invoice.SetID(items.Count);
            }
        }

        /// <summary>
        /// Etsii tietyn laskun tiedot käyttäen yksilöivää numeroa.
        /// </summary>
        /// <param name="identifier">Laskun yksilöivä numero. (ID)</param>
        /// <returns>Jos lasku löytyi, niin laskun tiedot stringinä. Jos ei, niin tyhjä string.</returns>
        public string GetOneItemInfo(int identifier) {
            foreach (var invoice in items) {

                if (identifier == invoice.ID) {
                    return invoice.ToString();
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Etsii kaikki laskut joissa esiintyy tietty tuote.
        /// </summary>
        /// <param name="productCode">Yksilöivä tuotekoodi</param>
        /// <returns>String-taulukko kaikista laskuista joissa esiintyy kyseinen tuote.</returns>
        public string[] GetItemsInfo(string productCode) {
            List<string> invoices = new List<string>();

            foreach (var invoice in items) {

                if (invoice.ToString().Contains($" {productCode} ")) {
                    invoices.Add(invoice.ToString());
                }
            }

            return invoices.ToArray();
        }

        /// <summary>
        /// Hakee tietyn asiakkaan kaikki laskut. Yksilöivänä tietona toimii osoitetiedot.
        /// </summary>
        /// <param name="address">Asiakkaan osoitetiedot.</param>
        /// <returns>String-taulukko asiakkaan laskuista.</returns>
        public string[] GetItemsInfo(Address address) {
            List<string> invoices = new List<string>();

            for (int i = 0; i < items.Count; i++) {

                if (AddressMatches(address, items[i].CustomerAddress)) {
                    invoices.Add(items[i].ToString());
                }
            }

            return invoices.ToArray();
        }

        private bool AddressMatches(Address address1, Address address2) { // yksityinen metodi osoitteiden vertailuun
            if (address1.Name == address2.Name && address1.StreetAddress == address2.StreetAddress && address1.PostalCode == address2.PostalCode) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
