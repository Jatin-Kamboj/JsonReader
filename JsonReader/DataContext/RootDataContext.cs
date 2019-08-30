using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JsonReader.Invoice;

namespace JsonReader.DataContext
{
    class RootDataContext : DbContext
    {

        public RootDataContext() : base("name=Model1")
        {

        }

        public DbSet<JSONReader> JSONReader { get; set; }
        public DbSet<B2b> b2B   { get; set; }
        public DbSet<Inv> Inv { get; set; }
        public DbSet<Itm> Itm { get; set; }
        public DbSet<Itm_Det> Itm_Det { get; set; }

    }
}
