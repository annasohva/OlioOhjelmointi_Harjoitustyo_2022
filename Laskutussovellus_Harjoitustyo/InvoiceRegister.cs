namespace Laskutussovellus_Harjoitustyo {
    /// <summary>
    /// Luokka joka sisältää kaikki laskut.
    /// </summary>
    internal static class InvoiceRegister {
        private readonly static List<Invoice> invoices = new List<Invoice>(); // lista on yksityinen ja readonly, että sitä ei poisteta vahingossa

        /// <summary>
        /// Metodin avulla lisätään uusi lasku rekisteriin.
        /// </summary>
        /// <param name="invoice">Lasku joka lisätään rekisteriin.</param>
        public static void AddInvoice(Invoice invoice) {
            invoices.Add(invoice);
        }

        /// <summary>
        /// Metodin avulla haetaan kaikki laskutiedot.
        /// </summary>
        /// <returns>Lista joka sisältää kaikki laskutiedot.</returns>
        public static IList<Invoice> GetInvoices() {
            return invoices.AsReadOnly();
        }
    }
}
