using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace MyFirstServerSideBlazor.Servises
{
    public class FontService
    {
        public PrivateFontCollection Font { get; init; }
        public FontService()
        {
            Font = new PrivateFontCollection();
            AddSnellBT(); //0
        }
        private void AddSnellBT()
        {
            //My font here is "Digireu.ttf"
            int fontLength = Properties.Resources.SnellRoundhand_BlackScript.Length;
            
            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.SnellRoundhand_BlackScript;
            
            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            Font.AddMemoryFont(data, fontLength);
        }
    }
}
