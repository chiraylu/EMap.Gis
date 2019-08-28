﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System;
using System.Collections.Generic;

using System.Text;

namespace EMap.Gis.Symbology
{
    public interface IPointSymbolizer:IFeatureSymbolizer
    {
        new IPointSymbolCollection Symbols { get; set; }
        SizeF Size { get; set; }
        void DrawPoint(IImageProcessingContext<Rgba32> context, float scale, PointF point);
    }
}
