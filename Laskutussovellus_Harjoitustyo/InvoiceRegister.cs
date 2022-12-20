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
            base.AddItem(invoice);
            invoice.SetID(items.Count + 1);
        }
    }
}
