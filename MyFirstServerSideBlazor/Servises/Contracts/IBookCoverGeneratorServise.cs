using System.Drawing;

namespace MyFirstServerSideBlazor.Servises.Contracts
{
    public interface IBookCoverGeneratorServise
    {
        public Image CreateCover(string BookTitle);
        
    }
}
