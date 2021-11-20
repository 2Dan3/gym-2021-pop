using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR36_2020_POP2021
{
    public class Address
    {
        public Address(long id, string streetName, int streetNum, string city, string state)
        {
            this.Id = id;
            this.StreetName = streetName;
            this.StreetNum = streetNum;
            this.City = city;
            this.State = state;
        }

        private long Id { get; set; }

        private string StreetName { get; set; }

        private int StreetNum { get; set; }

        private string City { get; set; }

        private string State { get; set; }
    }
}
