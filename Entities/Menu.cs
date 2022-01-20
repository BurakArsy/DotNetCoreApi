﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Entities
{
    public class Menu
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }
}
