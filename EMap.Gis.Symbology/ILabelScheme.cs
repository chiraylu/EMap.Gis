﻿using System;
using System.Drawing;

namespace EMap.Gis.Symbology
{
    /// <summary>
    /// Interface for label scheme.
    /// </summary>
    public interface ILabelScheme : IScheme
    {
        new ILabelCategoryCollection Categories { get; set; }
        new IFeatureLayer Parent { get; set; }
        IFeatureCategory CreateRandomCategory(string filterExpression);
    }
}