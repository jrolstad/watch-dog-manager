﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace watchdogmanager.blazor.Models
{
    public interface IIdentifiable
    {
        public string Id { get; set; }
    }
}