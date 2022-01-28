using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR36_2020_POP2021.Model
{

    [Table(Name = "fitness_center")]
    public class FitnessCenterInfo
    {
        [Column(IsPrimaryKey = true, Name = "fitness_id", CanBeNull = false)]
        public int FcId { get; set; }

        [Column(Name = "naziv", CanBeNull = false)]
        public string FcName { get; set; }

        [Column(Name = "adresa_id")]
        public int Adr_Id_FK { get; set; }

        // *
        /*private EntityRef<Address> location;
        [Association(Storage = "location", ThisKey = "Adr_Id_FK", OtherKey = "FcId", IsForeignKey = true)]
        public Address Location
        {
            get { return this.location.Entity; }
            set { this.location.Entity = value; }
        }*/
        /*[Column(Name = "adresa_id", CanBeNull = true)]
        public int AdrId { get; set; }*/
    }
}
