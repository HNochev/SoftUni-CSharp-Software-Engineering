using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("SoldProducts")]
    public class UsersAndProductsSoldProductOutputModel
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public UsersAndProductsProductOutputModel[] Products { get; set; }
    }
}
