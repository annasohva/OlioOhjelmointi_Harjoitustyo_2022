namespace Laskutussovellus_Harjoitustyo {
    /// <summary>
    /// Abstrakti luokka rekisteriä varten.
    /// </summary>
    /// <typeparam name="T">Objektin tyyppi mitä rekisterissä käsitellään.</typeparam>
    internal abstract class BaseRegister<T> {
        protected readonly List<T> items; // lista on protected ja readonly, että sitä ei poisteta vahingossa

        /// <summary>
        /// Luo uuden rekisterin.
        /// </summary>
        public BaseRegister() {
            items = new List<T>();
        }

        /// <summary>
        /// Lisää uuden objektin rekisteriin.
        /// </summary>
        /// <param name="item">Objekti joka lisätään rekisteriin.</param>
        public virtual void AddItem(T item) {
            items.Add(item);
        }

        /// <summary>
        /// Hakee tietyn objektin.
        /// </summary>
        /// <param name="identifier">Yksilöivä arvo millä haetaan.</param>
        /// <returns>Objekti joka vastaa yksilöivää arvoa. Jos objektia ei löydy palauttaa null.</returns>
        public abstract T? GetItem(string identifier);

        /// <summary>
        /// Hakee kaikkien objektien tiedot.
        /// </summary>
        /// <returns>String-taulukko mikä sisältää kaikkien objektien tiedot. Tyhjän taulukon jos rekisterissä ei ole objekteja.</returns>
        public virtual string[] GetItemsInfo() {
            string[] itemsAsString = Array.Empty<string>();

            if (items.Count != 0) {
                itemsAsString = new string[items.Count];

                for (int i = 0; i < items.Count; i++) {
                    itemsAsString[i] = items[i].ToString();
                }
            }

            return itemsAsString;
        }
    }
}
