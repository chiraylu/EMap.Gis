﻿namespace IMap.Gis.Symbology
{
    public interface ILineLayer:IFeatureLayer
    {
        new ILineScheme Symbology { get; set; }
    }
}