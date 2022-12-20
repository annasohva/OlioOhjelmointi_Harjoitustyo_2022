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
        /// Hakee kaikkien objektien tiedot.
        /// </summary>
        /// <returns>String-taulukko mikä sisältää kaikkien objektien tiedot.</returns>
        public virtual string[] GetItems() {
            string[] itemsToString = Array.Empty<string>();

            if (items.Count != 0) {
                itemsToString = new string[items.Count];

                for (int i = 0; i < itemsToString.Length; i++) {
                    itemsToString[i] = items[i].ToString();
                }
            }

            return itemsToString;
        }
    }
}
