using System;
using System.Text;
using DxFramework.FrameWork.Bases;
using DxFramework.FrameWork.Utils;
using DxLibDLL;

namespace DxFramework.FrameWork.Materials
{
    class TextMaterial : ISquareMaterialBase
    {
        public TextMaterial()
        {
            init();
        }
        public TextMaterial(string str)
        {
            IsVisible = true;
            String = str;
            setFont("ＭＳ ゴシック", 12, 1);
        }
        public TextMaterial(string str,int size)
        {
            IsVisible = true;
            String = str;
            setFont("ＭＳ ゴシック", size, 1);
        }
        public TextMaterial(string str,int size,string fontName)
        {
            IsVisible = true;
            String = str;
            setFont(fontName, size, 1);
        }
        public TextMaterial(string str, int size, string fontName,int thick)
        {
            IsVisible = true;
            String = str;
            setFont(fontName, size, thick);        
        }

        private int _fontSize;
        
        private int _thick;
        
        private string _fontName;
        
        private int _fontHandle;

        public void init()
        {
            String = "Hello! World";
            setFont("ＭＳ ゴシック",12,1);      
        }

        public Vector2 Size
        {
            get { return new Vector2(getTextWidth(), _fontSize); }
            set {  }
        }

        public string String { get; set; }

        public Color Color { get; set; }

        public string FontName
        {
            get { return _fontName; }
            set
            {
                _fontName = value;
                setFont();
            }
        }

        public int FontSize
        {
            get { return _fontSize; }
            set
            {
                _fontSize = value;
                setFont();
            }
        }

        public int Thick 
        {
            get { return _thick; }
            set
            {
                _thick = value;
                setFont();
            }
        }

        public Action<Vector2> DrawAction
        {
            get
            {
                return (top) =>
                {
                    DX.DrawStringToHandle((int)top.x, (int)top.y, String, Color.DxCoolor, _fontHandle);
                };
            }
        }

        public bool IsVisible { get; set; }

        public int getTextWidth()
        {
            return DX.GetDrawStringWidthToHandle(String, Encoding.GetEncoding("Shift_JIS").GetByteCount(String), _fontHandle);
        }

        public void setFont(string fontName, int size, int thick)
        {
            FontSize = size;
            Thick = thick;
            FontName = fontName;
            _fontHandle = DX.CreateFontToHandle(fontName, size, thick, DX.DX_FONTTYPE_ANTIALIASING_8X8);
        }

        public void setFont(int fontHandle)
        {
            FontSize = -1;
            Thick = -1;
            FontName = null;
            _fontHandle = fontHandle;
        }

        public void setFont()
        {
            _fontHandle = DX.CreateFontToHandle(FontName, FontSize, Thick, DX.DX_FONTTYPE_ANTIALIASING_8X8);
        }
    }
}
