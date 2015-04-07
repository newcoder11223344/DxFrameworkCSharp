using DxFramework.FrameWork.Bases;
using DxFramework.FrameWork.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxFramework.FrameWork.Materials;

namespace DxFramework.FrameWork
{
    public enum TextPos { Top, Mid, Bottom, Custom };

    class Text : Canvas
    {
        private Vector2 _size;
        private TextPos _textPos;
        private bool _changeTextFlag = false;
        private Vector2 _textPosition;
        private TextMaterial _text;

        public Text(int layer)
            : base(layer)
        {
            TextMaterial = new TextMaterial();
            Size = TextMaterial.Size;
            BackGroundFlag = false;
        }

        public Text(int layer, Vector2 top, TextMaterial tex)
            : base(layer)
        {
            TextMaterial = new TextMaterial();
            Top = top;
            TextMaterial = tex;
            Size = tex.Size;
            BackGroundFlag = false;
        }

        public bool BackGroundFlag { get; set; }


        public TextMaterial TextMaterial
        {
            get
            {
                _changeTextFlag = true;
                return _text;
            }
            set
            {
                _text = value;
                setTextPosition(_textPos);
            }
        }

        public Vector2 TextPosition
        {
            get { return _textPosition; }
            set
            {
                _textPosition = value;
                _textPos = TextPos.Custom;
            }
        }

        public override Vector2 Size
        {
            get { return _size; }
            set
            {
                _size = value;
                setTextPosition(_textPos);
            }
        }

        public override void draw()
        {
           if(BackGroundFlag) base.draw();
           TextMaterial.DrawAction(Top + TextPosition);
        }

        public override void update()
        {
            if (_changeTextFlag)
            {
                _changeTextFlag = false;
                setTextPosition(_textPos);
            }
            base.update();
        }

        public void setTextPosition(TextPos pos)
        {
            _textPos = pos;
            switch (pos)
            {
                case TextPos.Top:
                    _textPosition = new Vector2(0, 0);
                    break;
                case TextPos.Mid:
                    _textPosition = Mid - Top - TextMaterial.Size/2.0;
                    break;
                case TextPos.Bottom:
                    _textPosition = Bottom - TextMaterial.Size/2.0;
                    break;
                case TextPos.Custom:
                    break;
            }
        }
    }
}
