﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.DataAccess.Models
{
    public  class Supplier
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        [Required]
        public string Description { get; set; } 
        public string? Email { get; set; } = null;
        public string? RFC { get; set; } = null;
        public string? Phone { get; set; } = null ;
    }
}
