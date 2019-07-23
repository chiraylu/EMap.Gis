using EMap.Gis.Symbology;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSGeo.GDAL;
using OSGeo.OGR;
using SixLabors.ImageSharp;
using SixLabors.Primitives;
using System.IO;
using System.Text;

namespace EMap.Gis.Test
{
    [TestClass]
    public class UnitTest1
    {
        static UnitTest1()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//todo ע����룬ע��gdalʹ�õ�GBK����
            Gdal.AllRegister();
            Ogr.RegisterAll();
            // Ϊ��֧������·�������������������  
            if (Encoding.Default.EncodingName == Encoding.UTF8.EncodingName && Encoding.Default.CodePage == Encoding.UTF8.CodePage)
            {
                Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");
            }
            else
            {
                Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
            }
            // Ϊ��ʹ���Ա��ֶ�֧�����ģ�������������  
            Gdal.SetConfigOption("SHAPE_ENCODING", "");
        }
        [TestMethod]
        public void TestMethod1()
        {
            LayerFactory layerFactory = new LayerFactory();
            var path = "E:\\LC\\Codes\\EMap\\EMap.MapServer\\EMap.MapServer.Services\\Services\\Wmts\\1.0.0\\����\\2014��ü�Ӱ��.img";
            using (var layer = layerFactory.OpenLayer(path))
            {
                Envelope envelope = new Envelope
                {
                    MinX = 35384006.5,
                    MinY = 3375343.61155511,
                    MaxX = 35403574.388444893,
                    MaxY = 3394911.5
                };
                Rectangle rectangle = new Rectangle(0, 0, 256, 256);
                var img = layer.GetImage(envelope, rectangle);
                using (FileStream fs = File.Create(@"C:\Users\lc156\Desktop\123.png"))
                {
                    img.SaveAsPng(fs);
                }
            }
        }
    }
}
