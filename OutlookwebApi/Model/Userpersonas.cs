using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutlookwebApi.Model
{
    [Table("USERPERSONAS")]
    public partial class Userpersonas
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("ROLE")]
        [StringLength(50)]
        public string Role { get; set; }
        [Column("ACCESSLEVEL")]
        public int Accesslevel { get; set; }
    }
}
