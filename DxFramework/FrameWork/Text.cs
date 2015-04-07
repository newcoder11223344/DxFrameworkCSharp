using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxFramework.FrameWork.Bases;
using DxFramework.FrameWork.Utils;
using DxLibDLL;

namespace DxFramework.FrameWork
{
    class Text : ICanvasBase
    {
        private int _fontSize;
        private int _thick;
        private string _fontName;
        private int _fontHandle;
        private TextPos _textPos;
        private Vector2 _top;
        private Vector2 _size;
        private string _string;

        public Text()
        {
            init();
        }
        public Text(string str)
        {
            IsVisible = true;
            String = str;
            setTextPosition(TextPos.Top);
            setFont("ＭＳ ゴシック", 12, 1);
            _top = new Vector2(0, 0);
            _size = new Vector2(getTextWidth(), FontSize);
        }
        public Text(string str,int size)
        {
            IsVisible = true;
            String = str;
            setTextPosition(TextPos.Top);
            setFont("ＭＳ ゴシック", size, 1);
            _top = new Vector2(0, 0);
            _size = new Vector2(getTextWidth(), FontSize);
        }
        public Text(string str,int size,string fontName)
        {
            IsVisible = true;
            String = str;
            setTextPosition(TextPos.Top);
            setFont(fontName, size, 1);
            _top = new Vector2(0, 0);
            _size = new Vector2(getTextWidth(), FontSize);
        }
        public Text(string str, int size, string fontName,int thick)
        {
            IsVisible = true;
            String = str;
            setTextPosition(TextPos.Top);
            setFont(fontName, size, thick);
            _top = new Vector2(0, 0);
            _size = new Vector2(getTextWidth(), FontSize);
        }

        public void init()
        {
            String = "Hello! World";
            setTextPosition(TextPos.Top);
            setFont("ＭＳ ゴシック",12,1);
            _top = new Vector2(0, 0);
            _size = new Vector2(getTextWidth(), FontSize);
        }

        public string String {
            get { return _string; }
            set
            {
                _string = value;
                setTextPosition(_textPos);
            }
        }

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

        public Vector2 TextPosition { get; set; }


        public Vector2 Top
        {
            get { return _top; }
            set
            {
                _top = value;
                setTextPosition(_textPos);
            }
        }　　　　　　　　

        public Vector2 Size
        {
            get { return _size; }
            set
            {
                _size = value;
                setTextPosition(_textPos);
            }
        }

        public Vector2 Bottom { get { return Top + Size; } set { Top = value - Size; } }       // 右下の座標

        public Vector2 Mid { get { return Top + Size / 2; } set { Top = value - Size / 2; } }  // 中心の座標

        public Action DrawAction
        {
            get
            {
                return () =>
                {
                    DX.DrawStringToHandle((int)(Top.x+TextPosition.x), (int)(Top.y+TextPosition.y), String, Color.DxCoolor, _fontHandle);
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

        public enum TextPos { Top, Mid, Bottom,Custom };

        public void setTextPosition(TextPos pos)
        {
            _textPos = pos;
            switch (pos)
            {
                case TextPos.Top:
                    TextPosition = new Vector2(0, 0);
                    break;
                case TextPos.Mid:
                    TextPosition = Mid - Top - new Vector2(getTextWidth()/2.0, FontSize/2.0);
                    break;
                case TextPos.Bottom:
                    TextPosition = Bottom - new Vector2(getTextWidth()/2.0, FontSize/2.0);
                    break;
                case TextPos.Custom:
                    break;
                
            }

        }
     
    }
}
