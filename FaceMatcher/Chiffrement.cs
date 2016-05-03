using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using QRCoder;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace FaceMatcher
{
    public class Chiffrement
    {
        public static string textEnBase64(string texte)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(texte));
        }



        public static string base64EnTexte(string b64)
        {
            return System.Text.Encoding.Default.GetString(System.Convert.FromBase64String(b64));
        }

        public static void CreerQRCode(string texte, string chemin_logo = "")
        {
            SauvegarderImage(BitmapQRCode(texte, chemin_logo));
        }

        private static Bitmap BitmapQRCode(string texte, string chemin_logo = "")
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(textEnBase64(texte), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage;
            if (!string.IsNullOrEmpty(chemin_logo))
                qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Image.FromFile(chemin_logo), 20);
            else
                qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }

        private static void SauvegarderImage(Bitmap img)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "JPEG|*.jpeg";
            sfd.Title = "Sauvegarder votre QR code";
            if (sfd.ShowDialog() == DialogResult.OK)
                BitmapExtensions.SaveJPG100(img, sfd.FileName);
            else
                return;

        }
    }

    /*
     * Crédit: http://stackoverflow.com/questions/41665/bmp-to-jpg-png-in-c-sharp 
     * Merci à jestro
    */
    public static class BitmapExtensions
    {
        public static void SaveJPG100(this Bitmap bmp, string filename)
        {
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            bmp.Save(filename, GetEncoder(ImageFormat.Jpeg), encoderParameters);
        }

        public static void SaveJPG100(this Bitmap bmp, Stream stream)
        {
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            bmp.Save(stream, GetEncoder(ImageFormat.Jpeg), encoderParameters);
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }

            return null;
        }
    }
}
