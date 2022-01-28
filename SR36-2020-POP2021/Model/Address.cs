using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR36_2020_POP2021.Model
{

    [Table(Name = "adresa")]
    public class Address
    {
        public Address() { }

        [Column(IsPrimaryKey = true, Name = "adresa_id", CanBeNull = false)]
        public int Id { get; set; }

        [Column(Name = "ulica", CanBeNull = false)]
        public string StreetName { get; set; }

        [Column(Name = "broj", CanBeNull = false)]
        public int StreetNum { get; set; }

        [Column(Name = "grad", CanBeNull = false)]
        public string City { get; set; }

        [Column(Name = "drzava", CanBeNull = false)]
        public string State { get; set; }


        public override string ToString()
        {
            return Id + ";" + StreetName + ";" + StreetNum + ";" + City + ";" + State;
        }

        public Address Clone()
        {
            Address old = new Address()
            {
                StreetName = this.StreetName,
                StreetNum = this.StreetNum,
                City = this.City,
                State = this.State,
            };
            return old;
        }
    }
}
