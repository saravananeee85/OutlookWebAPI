using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutlookwebApi.Model
{
    [Table("CUSTOMREPORT")]
    public partial class Customreport
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string FeatureName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Launchdate { get; set; }
        [StringLength(50)]
        public string Launchtier { get; set; }
        [StringLength(50)]
        public string Linktodetails { get; set; }
        [StringLength(50)]
        public string Linktoaddcalendar { get; set; }
        [StringLength(50)]
        public string LaunchOwner { get; set; }
        [StringLength(50)]
        public string FrequencyofReport { get; set; }
    }
}
