﻿namespace GakuenDLL.Entity
{
    public class Address : AbstractEntity
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
