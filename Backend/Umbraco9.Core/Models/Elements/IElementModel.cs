﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbraco9.Core.Models.Elements
{
    public interface IElementModel
    {
        public string UmbracoContentType { get; }
    }
}
