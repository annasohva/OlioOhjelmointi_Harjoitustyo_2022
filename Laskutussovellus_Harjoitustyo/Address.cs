﻿namespace Laskutussovellus_Harjoitustyo {
    internal class Address {
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public Address(string streetAddress, string postalCode, string city) {
            StreetAddress = streetAddress;
            PostalCode = postalCode;
            City = city;
        }
    }
}
