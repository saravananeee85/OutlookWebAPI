﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutlookwebApi.Models
{
    public class TodoItem
    {
        [Key]
        //public long Id { get; set; }
        //public string Name { get; set; }
        //public bool IsComplete { get; set; }
        public int Id { get; set; }
        public string ROLE { get; set; }
        public int ACCESSLEVEL { get; set; }

    }
}
