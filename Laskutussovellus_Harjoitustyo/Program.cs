namespace Laskutussovellus_Harjoitustyo {
    internal class Program { // anteeksi nyt etukäteen tästä testauskoodista
        static void Main(string[] args) {
            // luodaan lasku-, tuote- ja asiakasrekisterit
            InvoiceRegister invoiceRegister = new InvoiceRegister();
            ProductRegister productRegister = new ProductRegister();

            InitializeRegisters(invoiceRegister, productRegister);

            string answer = string.Empty;

            do {
                Console.WriteLine("Tervetuloa laskutussovellukseen.\r\n\r\n" +
                "\ta. Listaa kaikki laskutiedot\r\n" +
                "\tb. Listaa yksittäisen laskun laskutiedot\r\n" +
                "\tc. Listaa yksittäisen asiakkaan kaikki laskut\r\n" +
                "\td. Listaa kaikki järjestelmään tallennetut tuotetiedot\r\n" +
                "\te. Listaa laskut joissa esiintyy tietty tuote\r\n" +
                "\tq. Lopeta\r\n");

                answer = Console.ReadLine();

                Console.Clear();

                switch (answer.ToLower()) {
                    case "a":
                        ListAllInvoices(invoiceRegister);
                        break;
                    case "b":
                        ListInvoice(invoiceRegister);
                        break;
                    case "c":
                        ListCustomerInvoices(invoiceRegister);
                        break;
                    case "d":
                        ListAllProducts(productRegister);
                        break;
                    case "e":
                        ListInvoicesContainingProduct(invoiceRegister);
                        break;
                    case "q":
                    default:
                        break;
                }

                Console.Clear();

            } while (answer.ToLower() != "q");
        }

        /// <summary>
        /// Tulostaa kaikki laskurekisteriin tallennetut laskut.
        /// </summary>
        /// <param name="invoiceRegister">Laskurekisteri mikä tulostetaan.</param>
        private static void ListAllInvoices(InvoiceRegister invoiceRegister) {
            string[] invoices = invoiceRegister.GetAllItemInfo();

            foreach (var invoice in invoices) {
                Console.WriteLine(invoice);
                Console.WriteLine();
            }

            PressEnterToContinue();
        }

        /// <summary>
        /// Kysyy käyttäjältä laskun yksilöivää numeroa ja tulostaa numeroa vastaavan laskun.
        /// </summary>
        /// <param name="invoiceRegister">Laskurekisteri mistä lasku haetaan.</param>
        private static void ListInvoice(InvoiceRegister invoiceRegister) {
            bool inputValid = false;

            do {
                Console.Write("Listaa yksittäisen laskun laskutiedot. q. Lopeta\r\n\r\nAnna laskun yksilöivä numero: ");
                string input = Console.ReadLine();
                inputValid = int.TryParse(input, out int id);

                if (inputValid) {
                    string invoice = invoiceRegister.GetOneItemInfo(id);

                    if (invoice != string.Empty) {
                        Console.WriteLine(invoice);
                        PressEnterToContinue();
                    }
                    else {
                        inputValid = false;
                        Console.WriteLine("Tämän numeroista laskua ei löytynyt.");
                        PressEnterToContinue();
                    }
                }
                else {
                    if (input.ToLower() == "q") { break; }

                    Console.WriteLine("Virhe. Anna kokonaisluku.");
                    PressEnterToContinue();
                }

            } while (!inputValid);
        }

        /// <summary>
        /// Listaa yksittäisen asiakkaan kaikki laskut.
        /// </summary>
        /// <param name="invoiceRegister">Laskurekisteri mistä lasku haetaan.</param>
        private static void ListCustomerInvoices(InvoiceRegister invoiceRegister) {
            Console.WriteLine("Listaa tietyn asiakkaan kaikki laskut.\r\n");
            Address address = AskAddress();
            string[] invoices = invoiceRegister.GetItemsInfo(address);

            if (invoices.Length > 0) {
                foreach (string invoice in invoices) {
                    Console.WriteLine("\r\n" + invoice);
                }
            }
            else {
                Console.WriteLine("\r\nTämän nimistä asiakasta ei ole tai osoite on väärin.");
            }

            PressEnterToContinue();
        }

        /// <summary>
        /// Listaa kaikki tuoterekisteriin tallennetut tuotteet.
        /// </summary>
        /// <param name="productRegister">Tuoterekisteri mikä listataan.</param>
        private static void ListAllProducts(ProductRegister productRegister) {
            string[] products = productRegister.GetAllItemInfo();

            Console.WriteLine("Kaikki järjestelmään tallennetut tuotteet:\r\n\r\n" +
                " Tuote\t\tYksikkö\t\tA-hinta\r\n" +
                " --------------------------------------");

            foreach (var product in products) {
                Console.WriteLine(product);
            }

            PressEnterToContinue();
        }

        /// <summary>
        /// Kysyy tuotekoodin käyttäjältä. ja listaa laskut jotka sisältää tietyn tuotteen. 
        /// </summary>
        /// <param name="invoiceRegister">Rekisteri josta haetaan laskuja.</param>
        private static void ListInvoicesContainingProduct(InvoiceRegister invoiceRegister) {
            Console.Write("Listaa laskut jotka sisältää tietyn tuotteen.\r\n\r\nAnna tuotekoodi: ");
            string productCode = Console.ReadLine();

            string[] invoices = invoiceRegister.GetItemsInfo(productCode);

            if (invoices.Length > 0) {
                foreach (var invoice in invoices) {
                    Console.WriteLine("\r\n" + invoice);
                }
            }
            else {
                Console.WriteLine("Tämä tuote ei esiinny missään laskussa.");
            }

            PressEnterToContinue();
        }


        /// <summary>
        /// Kysyy käyttäjältä osoitetiedot.
        /// </summary>
        /// <returns>Uusi Address-olio</returns>
        private static Address AskAddress() {
            Console.Write("Anna yrityksen/henkilön nimi: ");
            string name = Console.ReadLine();

            Console.Write("Anna katuosoite: ");
            string streetAddress = Console.ReadLine();

            Console.Write("Anna postikoodi: ");
            string postalCode = Console.ReadLine();

            Console.Write("Anna postitoimipaikka: ");
            string city = Console.ReadLine();

            return new Address(name, streetAddress, postalCode, city);
        }


        /// <summary>
        /// Pyytää käyttäjää painamaan ENTER jatkaakseen seuraavaan ruutuun.
        /// </summary>
        private static void PressEnterToContinue() {
            Console.WriteLine("\r\nPaina ENTER jatkaaksesi.");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Alustaa lasku- ja  tuoterekisterit esimerkkilaskuilla ja tuotteilla.
        /// </summary>
        /// <param name="invoiceRegister">Alustettava laskurekisteri</param>
        /// <param name="productRegister">Alustettava tuoterekisteri</param>
        private static void InitializeRegisters(InvoiceRegister invoiceRegister, ProductRegister productRegister) {
            // luodaan pari esimerkkiosoitetta
            var address1 = new Address("Yritys Oy", "Esimerkkitie 1", "80100", "Joensuu");
            var address2 = new Address("Erkki Esimerkki", "Esimerkkitie 2", "80100", "Joensuu");
            var address3 = new Address("Osakeyhtiö Oy", "Esimerkkitie 3", "80100", "Joensuu");

            // lisätään tuoterekisteriin tuotteita
            productRegister.AddItem(new Product("Parketti", "m2", 89.50));
            productRegister.AddItem(new Product("Alusmateriaali", "m2", 2.38));
            productRegister.AddItem(new Product("Liima", "l", 17.63));
            productRegister.AddItem(new Product("Maali", "l", 13.69));
            productRegister.AddItem(new Product("Maalarinteippi", "m", 0.11));
            productRegister.AddItem(new Product("Kalusteovi", "kpl", 23.5));
            productRegister.AddItem(new Product("Kalustevedin", "kpl", 3.98));
            productRegister.AddItem(new Product("Sarana", "kpl", 3.99));

            // luodaan ensimmäinen lasku
            var invoice1 = new Invoice(10, 60, address1, "Lattiaremontti");
            var invoice1line1 = new InvoiceLine(productRegister.GetItem("Parketti"), 46);
            invoice1.AddLine(invoice1line1);
            var invoice1line2 = new InvoiceLine(productRegister.GetItem("Alusmateriaali"), 46);
            invoice1.AddLine(invoice1line2);
            var invoice1line3 = new InvoiceLine(productRegister.GetItem("Liima"), 10);
            invoice1.AddLine(invoice1line3);
            invoiceRegister.AddItem(invoice1);

            // luodaan toinen lasku
            var invoice2 = new Invoice(4, 40, address1, "Seinien maalaus");
            var invoice2line1 = new InvoiceLine(productRegister.GetItem("Maali"), 16);
            invoice2.AddLine(invoice2line1);
            var invoice2line2 = new InvoiceLine(productRegister.GetItem("Maalarinteippi"), 75);
            invoice2.AddLine(invoice2line2);
            invoiceRegister.AddItem(invoice2);

            // luodaan kolmas lasku
            var invoice3 = new Invoice(3.5, 60, address2, "Keittiöremontti, kaappien ovien vaihto");
            var invoice3line1 = new InvoiceLine(productRegister.GetItem("Kalusteovi"), 8);
            invoice3.AddLine(invoice3line1);
            var invoice3line2 = new InvoiceLine(productRegister.GetItem("Kalustevedin"), 8);
            invoice3.AddLine(invoice3line2);
            var invoice3line3 = new InvoiceLine(productRegister.GetItem("Sarana"), 16);
            invoice3.AddLine(invoice3line3);
            invoiceRegister.AddItem(invoice3);

            // luodaan neljäs lasku
            var invoice4 = new Invoice(9, 60, address3, "Lattiaremontti");
            var invoice4line1 = new InvoiceLine(productRegister.GetItem("Parketti"), 42);
            invoice4.AddLine(invoice4line1);
            var invoice4line2 = new InvoiceLine(productRegister.GetItem("Alusmateriaali"), 42);
            invoice4.AddLine(invoice4line2);
            var invoice4line3 = new InvoiceLine(productRegister.GetItem("Liima"), 9);
            invoice4.AddLine(invoice4line3);
            invoiceRegister.AddItem(invoice4);

            // luodaan viides lasku
            var invoice5 = new Invoice(5, 40, address3, "Seinien maalaus");
            var invoice5line1 = new InvoiceLine(productRegister.GetItem("Maali"), 22);
            invoice5.AddLine(invoice5line1);
            var invoice5line2 = new InvoiceLine(productRegister.GetItem("Maalarinteippi"), 84.5);
            invoice5.AddLine(invoice5line2);
            invoiceRegister.AddItem(invoice5);

            // luodaan kuudes lasku
            var invoice6 = new Invoice(address1);
            var invoice6line1 = new InvoiceLine(productRegister.GetItem("Maali"), 30);
            invoice6.AddLine(invoice6line1);
            var invoice6line2 = new InvoiceLine(productRegister.GetItem("Maalarinteippi"), 160);
            invoice6.AddLine(invoice6line2);
            invoiceRegister.AddItem(invoice6);
        }
    }
}