using DxLibDLL;

namespace DxFramework.FrameWork.Utils
{
    struct Color
    {
        public Color(int r, int g, int b) : this()
        {
            R = r;
            G = g;
            B = b;
        }

        public int DxCoolor
        {
            get { return DX.GetColor(R, G, B); }
        }

        public int B { get; set; }

        public int G { get; set; }

        public int R { get; set; }

        public static Color operator +(Color a, Color b )
        {
            return new Color(a.R + b.R, a.G + b.G, a.B + b.B);
        }

        public static Color operator -(Color a, Color b)
        {
            return new Color(a.R - b.R, a.G - b.G, a.B - b.B);
        }
    }

}
