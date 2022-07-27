using System.Drawing;
using MyFirstServerSideBlazor.Servises.Contracts;

namespace MyFirstServerSideBlazor.Servises
{
    public class BookCoverGeneratorServise : IBookCoverGeneratorServise
    {
        public Image CreateCover(string BookTitle)
        {
            var blankCover = Image.FromFile(@"wwwroot/css/images/BookCover30.png");

            var cover = WriteTextOnImage(blankCover, BookTitle,
                new Font("Snell Roundhand, cursive", 16),
                new SolidBrush(Color.DarkGoldenrod),
                new Point(50, 50));

            return cover;
        }

        private Image WriteTextOnImage(Image image, string title, Font font, Brush brush, Point position)
        {
            var newImage = image.Clone() as Image;

            using (var gfx = Graphics.FromImage(newImage))
            {
                gfx.DrawString(title, font, brush, position);

                return newImage;
            };
        }
    }
}
