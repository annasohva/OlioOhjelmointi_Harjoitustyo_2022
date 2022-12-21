namespace Laskutussovellus_Harjoitustyo {
    internal class Program {
        static void Main(string[] args) {
            InvoiceRegister invoiceRegister = new InvoiceRegister();
            ProductRegister productRegister = new ProductRegister();

            var address1 = new Address("Yritys Oy", "Esimerkkitie 1", "80100", "Joensuu");
            var address2 = new Address("Erkki Esimerkki", "Esimerkkitie 2", "80100", "Joensuu");
            var address3 = new Address("Osakeyhtiö Oy", "Esimerkkitie 3", "80100", "Joensuu");

            productRegister.AddItem(new Product("Tyo", "t", 60));
            productRegister.AddItem(new Product("Parketti", "m2", 89.50));
            productRegister.AddItem(new Product("Alusmateriaali", "m2", 2.38));
            productRegister.AddItem(new Product("Liima", "l", 17.63));
            productRegister.AddItem(new Product("Maali", "l", 13.69));
            productRegister.AddItem(new Product("Maalarinteippi", "m", 0.11));
            productRegister.AddItem(new Product("Kalusteovi", "kpl", 23.5));
            productRegister.AddItem(new Product("Kalustevedin", "kpl", 3.98));
            productRegister.AddItem(new Product("Sarana", "kpl", 3.99));

            var invoice1 = new Invoice(GenerateDate(2023), address1, "Lattiaremontti");
            var invoice1line1 = new InvoiceLine(productRegister.GetItem("Tyo"), 10);
            invoice1.AddLine(invoice1line1);
            var invoice1line2 = new InvoiceLine(productRegister.GetItem("Parketti"), 46);
            invoice1.AddLine(invoice1line2);
            var invoice1line3 = new InvoiceLine(productRegister.GetItem("Alusmateriaali"), 46);
            invoice1.AddLine(invoice1line3);
            var invoice1line4 = new InvoiceLine(productRegister.GetItem("Liima"), 10);
            invoice1.AddLine(invoice1line4);
            invoiceRegister.AddItem(invoice1);
            Console.WriteLine(invoice1.ToString());

            var invoice2 = new Invoice(GenerateDate(2023), address1, "Seinien maalaus");
            invoiceRegister.AddItem(invoice2);

            var invoice3 = new Invoice(GenerateDate(2023), address2, "Keittiöremontti, kaapin ovien vaihto");
            invoiceRegister.AddItem(invoice3);

            var invoice4 = new Invoice(GenerateDate(2023), address3, "Lattiaremontti");
            invoiceRegister.AddItem(invoice4);

            var invoice5 = new Invoice(GenerateDate(2023), address3, "Seinien maalaus");
            invoiceRegister.AddItem(invoice5);

        }

        /// <summary>
        /// Luo satunnaisen päivämäärän tiettynä vuonna.
        /// </summary>
        /// <param name="year">Vuosiluku.</param>
        /// <returns>Satunnainen DateOnly-päivämäärä.</returns>
        public static DateOnly GenerateDate(int year) {
            Random random = new Random();

            int month = random.Next(1, 13);
            int day = 1;

            switch (DateTime.DaysInMonth(year, month)) {
                case 31:
                    day = random.Next(1, 32);
                    break;
                case 30:
                    day = random.Next(1, 31);
                    break;
                case 29:
                    day = random.Next(1, 30);
                    break;
                case 28:
                    day = random.Next(1, 29);
                    break;
            }

            return new DateOnly(year, month, day);
        }
    }
}