﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.DataAccess.Models
{

        public class Rol
        {
            [Key]
            public int Id { get; set; }
            [Required]
            [MaxLength(50)]
            public string Name { get; set; }
        }
    }

