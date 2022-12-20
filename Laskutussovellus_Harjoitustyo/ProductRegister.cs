namespace Laskutussovellus_Harjoitustyo {
    /// <summary>
    /// Luokka joka sisältää kaikki tallennetut tuotteet.
    /// </summary>
    internal class ProductRegister : BaseRegister<Product> {
        public ProductRegister() : base() {
            items.Add(new Product("Työ","h",60));
        }
    }
}
