namespace Laskutussovellus_Harjoitustyo {
    /// <summary>
    /// Luokka laskun tietoja ja rivejä varten.
    /// </summary>
    internal class Invoice {
        private readonly List<InvoiceLine> lines = new List<InvoiceLine>();

        public int ID { get; private set; } = -1;
        public DateOnly Date { get; private set; }
        public DateOnly DueDate { get; private set; }
        public Address BillerAddress { get; private set; }
        public Address CustomerAddress { get; private set; }
        public string Details { get; private set; } = string.Empty;
        public double Total { get; private set; } = -1;

        /// <summary>
        /// Luo uuden laskun eräpäivällä, asiakkaan osoitteella ja lisätiedoilla.
        /// Asettaa automaattisesti nykyisen päivämäärän ja laskuttajan osoitteen.
        /// </summary>
        /// <param name="dueDate">Laskun eräpäivä</param>
        /// <param name="customerAddress">Asiakkaan osoite</param>
        /// <param name="details">Lisätiedot</param>
        public Invoice(DateOnly dueDate, Address customerAddress, string details = "") {
            Date = DateOnly.FromDateTime(DateTime.Now);
            DueDate = dueDate;

            CustomerAddress = customerAddress;
            BillerAddress = Biller.Address;

            Details = details;
        }

        /// <summary>
        /// Lisää laskuun uuden laskurivin ja päivittää laskun kokonaissumman.
        /// </summary>
        /// <param name="line">Uusi laskurivi mikä lisätään laskuun.</param>
        public void AddLine(InvoiceLine line) {
            lines.Add(line);
            this.Total += line.Total;
        }

        /// <summary>
        /// Asettaa laskun yksilöivän numeron.
        /// </summary>
        /// <param name="id">Yksilöivä numero.</param>
        public void SetID(int id) {
            if (ID == -1) {
                ID = id;
            }
        }

        /// <summary>
        /// Muotoilee laskun tiedot.
        /// </summary>
        /// <returns>Laskun tiedot stringinä.</returns>
        public override string ToString() {
            string[] billerAddress = BillerAddress.GetAddressLines();
            string[] customerAddress = CustomerAddress.GetAddressLines();

            string info = $" Laskuttaja:\r\n" +
                $" {billerAddress[0]}\t\t\t\tPäiväys: {Date}\r\n" +
                $" {billerAddress[1]}\t\t\t\tLaskun numero: {ID}\r\n" +
                $" {billerAddress[2]}\t\t\t\tEräpäivä: {DueDate}\r\n\r\n" +
                $" Asiakas:\r\n" +
                $" {customerAddress[0]}\r\n" +
                $" {customerAddress[1]}\r\n" +
                $" {customerAddress[2]}\r\n\r\n" +
                $" Lisätiedot: {Details}\r\n" +
                $"-------------------------------------------------------------------------\r\n" +
                $" Tuote\t\tMäärä\t\tYksikkö\t\tA-hinta\t\tYhteensä\r\n" +
                $"-------------------------------------------------------------------------\r\n";

            foreach (var line in lines) {
                info += line.ToString() + "\r\n";
            }

            info += $"\t\t\t\t\t\tYHTEENSÄ\t{Math.Round(Total,2)} e\r\n" +
                $"-------------------------------------------------------------------------";

            return info;
        }
    }
}
