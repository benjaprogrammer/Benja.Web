using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace Benja.Library
{
    public static class Qrcodes
    {
        public static string GenQrImmigration(string textBarcode, DateTime mfp, DateTime exp)
        {
            var QrUri = String.Empty;
            var BarcodeNo = textBarcode;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(BarcodeNo, QRCodeGenerator.ECCLevel.Q);
            QRCode QrCode = new QRCode(qrCodeData);
            Bitmap QrBitmap = QrCode.GetGraphic(60);

            using (Graphics graphics = Graphics.FromImage(QrBitmap))
            {
                var fontFamily = FontFamily.Families
                 .Where(c => c.Name == "Arial")
                 .FirstOrDefault();
                var font = new System.Drawing.Font(fontFamily, 50, System.Drawing.FontStyle.Bold);
                SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);

                graphics.DrawString("IMMIGRATION", font, brush, new PointF(250, 140));
                graphics.DrawString("Thanaleng Dry Port", font, brush, new PointF(250, QrBitmap.Height - 230));
                graphics.DrawString("MFP:" + mfp.ToString("dd.MM.yyyy hh:mm tt", new System.Globalization.CultureInfo("en-US")), font, brush, new PointF(250, QrBitmap.Height - 150));
                graphics.DrawString("EXP:" + exp.ToString("dd.MM.yyyy hh:mm tt", new System.Globalization.CultureInfo("en-US")), font, brush, new PointF(250, QrBitmap.Height - 70));
            }
            byte[] BitmapArray = QrBitmap.BitmapToByteArray();
            return string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
        }
        private static byte[] BitmapToByteArray(this Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
