namespace Laskutussovellus_Harjoitustyo {
    /// <summary>
    /// Luokka laskuriviä varten.
    /// </summary>
    internal class InvoiceLine {
        public Product Product { get; private set; }
        public double Quantity { get; private set; }
        public double Total { get; private set; }

        /// <summary>
        /// Luo uuden laskurivin tuoteobjektin ja määrätiedon avulla. Laskee tuotteiden kokonaishinnan.
        /// </summary>
        /// <param name="product">Tuote-objekti.</param>
        /// <param name="quantity">Tuotteiden määrä.</param>
        public InvoiceLine(Product product, double quantity) {
            Product = product;
            Quantity = quantity;
            Total = product.PricePerUnit * quantity;
        }

        /// <summary>
        /// Muotoilee tuoterivin.
        /// </summary>
        /// <returns>Muotoillun tuoterivin stringinä.</returns>
        public override string ToString() {
            return String.Format(" {0,-14} {1}\t\t{2}\t\t{3}\t\t{4}", Product.Code, Quantity, Product.Unit, Product.PricePerUnit, Math.Round(Total, 2));
        }
    }
}
