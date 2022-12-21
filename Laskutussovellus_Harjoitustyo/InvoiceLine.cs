namespace Laskutussovellus_Harjoitustyo {
    /// <summary>
    /// Luokka laskuriviä varten.
    /// </summary>
    internal class InvoiceLine {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public double Total { get; private set; }

        /// <summary>
        /// Luo uuden laskurivin tuoteobjektin ja määrätiedon avulla. Laskee tuotteiden kokonaishinnan.
        /// </summary>
        /// <param name="product">Tuote-objekti.</param>
        /// <param name="quantity">Tuotteiden määrä.</param>
        public InvoiceLine(Product product, int quantity) {
            Product = product;
            Quantity = quantity;
            Total = product.PricePerUnit * quantity;
        }

        /// <summary>
        /// Muotoilee tuoterivin.
        /// </summary>
        /// <returns>Muotoillun tuoterivin stringinä.</returns>
        public override string ToString() {
            return $" {Product.Code}\t\t{Quantity}\t\t{Product.Unit}\t\t{Product.PricePerUnit}\t\t{Math.Round(Total, 2)}";
        }
    }
}
