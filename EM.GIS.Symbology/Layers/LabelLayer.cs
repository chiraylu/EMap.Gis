﻿using System;
using System.Drawing;
using System.Threading;

namespace EM.GIS.Symbology
{
    public class LabelLayer : Layer, ILabelLayer
    {
        public IFeatureLayer FeatureLayer { get; set; }
        public new ILabelScheme Symbology { get => base.Symbology as ILabelScheme; set => base.Symbology = value; }
        public new ILabelCategory DefaultCategory { get => base.DefaultCategory as ILabelCategory; set => base.DefaultCategory = value; }
        public LabelLayer(IFeatureLayer featureLayer)
        {
            FeatureLayer = featureLayer;
        }
        public void ClearSelection()
        {
            throw new NotImplementedException();
        }

        public void CreateLabels()
        {
            throw new NotImplementedException();
        }
        protected override void OnDraw(Graphics graphics, Rectangle rectangle, IExtent extent, bool selected = false,CancellationTokenSource cancellationTokenSource = null)
        {
            throw new NotImplementedException();
        }
        public bool Select(IExtent region)
        {
            throw new NotImplementedException();
        }

        public void Invalidate()
        {
            throw new NotImplementedException();
        }
    }
}
