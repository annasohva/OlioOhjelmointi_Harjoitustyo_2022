namespace Laskutussovellus_Harjoitustyo {
    /// <summary>
    /// Luokka laskun tietoja ja rivejä varten.
    /// </summary>
    internal class Invoice {
        public int ID { get; private set; } = -1;
        public DateOnly Date { get; private set; }
        public DateOnly DueDate { get; private set; }
        public Address BillerAddress { get; private set; }
        public Address CustomerAddress { get; private set; }
        public double Total { get; private set; } = -1;
        private readonly List<InvoiceLine> lines = new List<InvoiceLine>();

        /// <summary>
        /// Konstruktori jonka avulla luodaan uusi lasku. Asetetaan eräpäivä ja asiakkaan osoite.
        /// </summary>
        /// <param name="dueDate">Laskun eräpäivä</param>
        /// <param name="customerAddress">Asiakkaan osoite</param>
        public Invoice(DateOnly dueDate, Address customerAddress) {
            Date = DateOnly.FromDateTime(DateTime.Now);
            DueDate = dueDate;
            BillerAddress = Biller.Address;
            CustomerAddress = customerAddress;
            InvoiceRegister.AddInvoice(this);
        }

        /// <summary>
        /// Metodi jonka avulla laskuun voi lisätä uuden laskurivin.
        /// </summary>
        /// <param name="line">Uusi laskurivi mikä lisätään laskuun.</param>
        public void AddLine(InvoiceLine line) {
            lines.Add(line);
        }
    }
}
