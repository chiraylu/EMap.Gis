﻿using EMap.Gis.Data;
using System;
using System.Drawing;

namespace EMap.Gis.Symbology
{
    public class MapArgs :  IProj
    {
        public Graphics Device { get; }
        public Extent Extent { get; private set; }
        public Rectangle Bounds { get; }
        public double Dx { get; }
        public double Dy { get; }
        public MapArgs(Rectangle rectangle,Extent extent )
        {
            Extent = extent;
            Bounds = rectangle;
            double worldWidth = extent.Width;
            double worldHeight = extent.Height;
            Dx = rectangle.Width != 0 ? worldWidth / rectangle.Width : 0;
            Dy = rectangle.Height != 0 ? worldHeight / rectangle.Height : 0;
        }
        public MapArgs(Rectangle rectangle, Extent extent, Graphics g ):this( rectangle, extent)
        {
            Device = g;
        }
    }
}
