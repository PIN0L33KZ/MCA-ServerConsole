namespace MCA_ServerConsole.HelperClasses
{
    internal class ImageHelper
    {
        public static string ConvertImageToString(Image image)
        {
            using MemoryStream ms = new();

            // Convert image to base64 string
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            var base64Image = Convert.ToBase64String(ms.ToArray());

            // Return base64 string
            return base64Image;
        }

        public static Image ConvertStringToImage(string imageString)
        {
            var imageBytes = Convert.FromBase64String(imageString);
            using MemoryStream ms = new(imageBytes);
            
            return Image.FromStream(ms);
        }
    }
}