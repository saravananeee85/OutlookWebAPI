using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutlookwebApi.Model
{
    [Table("LAUNCHEVENT")]
    public partial class Launchevent
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string FeatureName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Launchdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Launchtime { get; set; }
        [StringLength(50)]
        public string Launchtype { get; set; }
        [StringLength(50)]
        public string Launchtier { get; set; }
        [StringLength(50)]
        public string Hyperlinktodetails { get; set; }
        [StringLength(50)]
        public string Customfields { get; set; }
    }
}
