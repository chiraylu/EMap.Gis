﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EMap.Gis.Symbology
{
    public interface IFeatureSymbolizer:ISymbolizer
    {
        ScaleMode ScaleMode { get; set; }
    }
}