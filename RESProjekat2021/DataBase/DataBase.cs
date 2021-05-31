namespace DataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataBase : DbContext
    {
        public DataBase() : base("name=DataBase")
        {
        }

        public virtual DbSet<DescriptionT> DescriptionT { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
