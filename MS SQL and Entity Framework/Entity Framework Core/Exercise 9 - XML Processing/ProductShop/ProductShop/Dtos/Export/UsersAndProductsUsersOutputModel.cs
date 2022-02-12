using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class UsersAndProductsUsersOutputModel
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UsersAndProductsUserOutputModel[] Users { get; set; }
    }
}
