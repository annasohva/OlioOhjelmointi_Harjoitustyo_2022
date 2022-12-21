namespace Laskutussovellus_Harjoitustyo {
    /// <summary>
    /// Luokka joka sisältää kaikki tallennetut tuotteet.
    /// </summary>
    internal class ProductRegister : BaseRegister<Product> {
        /// <summary>
        /// Lisää uuden tuotteen tuoterekisteriin jos samanniminen tuote ei jo ole olemassa.
        /// </summary>
        /// <param name="product">Lisättävä tuote.</param>
        public override void AddItem(Product product) {
            bool productIsNew = true;

            foreach (var item in items) {

                if (item.Code.ToLower() == product.Code.ToLower()) {
                    productIsNew = false;
                    break;
                }
            }

            if (productIsNew) {
                base.AddItem(product);
            }
        }

        /// <summary>
        /// Hakee tuotteen käyttäen tuotekoodia.
        /// </summary>
        /// <param name="productCode">Tuotekoodi.</param>
        /// <returns>Jos löytyy, niin tuote, jos ei niin null.</returns>
        public Product? GetItem(string productCode) {
            foreach (var product in items) {

                if (productCode == product.Code) {
                    return product;
                }
            }

            return null;
        }
    }
}
