using DxFramework.FrameWork.Bases;
using DxFramework.FrameWork.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxFramework.FrameWork
{
    public enum TextPos { Top, Mid, Bottom, Custom };

    class AutoDrawnText : AutoDrawnCanvas
    {
        private Vector2 _size;
        private TextPos _textPos;
        private bool _changeTextFlag = false;
        private Vector2 _textPosition;
        private Text _text;

        public AutoDrawnText(int layer)
            : base(layer)
        {
            Text = new Text();
            Size = Text.Size;
            BackGroundFlag = false;
        }

        public AutoDrawnText(int layer, Vector2 top, Text tex)
            : base(layer)
        {
            Text = new Text();
            Top = top;
            Text = tex;
            Size = tex.Size;
            BackGroundFlag = false;
        }

        public bool BackGroundFlag { get; set; }


        public Text Text
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
           Text.DrawAction(Top + TextPosition);
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
                    _textPosition = Mid - Top - Text.Size/2.0;
                    break;
                case TextPos.Bottom:
                    _textPosition = Bottom - Text.Size/2.0;
                    break;
                case TextPos.Custom:
                    break;
            }
        }
    }
}
