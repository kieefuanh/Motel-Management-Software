﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM.Classes
{
    [Serializable]
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Save { get; set; }
    }
}
