using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR36_2020_POP2021.Model
{
    public class Address
    {
        public Address() { }

        public int Id { get; set; }

        public string StreetName { get; set; }

        public string StreetNum { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public override string ToString()
        {
            return Id + ";" + StreetName + ";" + StreetNum + ";" + City + ";" + State;
        }
    }
}
