namespace DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DescriptionT")]
    public partial class DescriptionT
    {
        public int Code { get; set; }

        public int? Value { get; set; }

        public DateTime? TimeStamp { get; set; }

        public int DataSet { get; set; }

        public int ID { get; set; }
    }
}
