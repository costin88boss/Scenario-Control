﻿using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioControl_EXILED2
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}
