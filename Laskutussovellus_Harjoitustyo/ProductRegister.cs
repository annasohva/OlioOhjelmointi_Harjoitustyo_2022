namespace Laskutussovellus_Harjoitustyo {
    /// <summary>
    /// Luokka joka sisältää kaikki tallennetut tuotteet.
    /// </summary>
    internal class ProductRegister : BaseRegister<Product> {
        /// <summary>
        /// Luo uuden tuoterekisterin.
        /// </summary>
        public ProductRegister() : base() {
            items.Add(new Product("Työ","h",60));
        }

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
    }
}
