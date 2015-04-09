using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxFramework.FrameWork.Utils;

namespace DxFramework.FrameWork.Bases
{
   abstract class ShapeBase : AutoDrawnBase, IMouseObjectBase
    {
        public ShapeBase(int layer)
            : base(layer)
        {
            DraggableFlag = false;    　　　　　　　　　　// デフォルトではドラッグできません。
        }
        public bool DraggableFlag { get; set; }

        public abstract IMaterialBase Material { get; set; }

        protected Vector2 _drawingPoint;

        public event NomalEventHandler MouseOnEvent;　　　// マウスオーバー時に発生します。

        public event NomalEventHandler ClickedEvent;  　　// クリック完了時に発生します。

        public event NomalEventHandler ClickedOnEvent;　　// 上で押された時に発生します。

        public event NomalEventHandler ClickedOffUpEvent; // 上で離された時に発生します。

        public event NomalEventHandler PressingEvent; 　　// 押されている間に発生します。

        public event NomalEventHandler DraggingEvent;     //ドラッグされている間に発生します。

        private bool _clickedFlag;

        private bool _draggedFlag;

        public override void draw()
        {
            Material.DrawAction(_drawingPoint);
        }

        public override void update()
        {
            if (isMouseOn())
            {
                if (MouseOnEvent != null) MouseOnEvent(this, null);
            }
            if (isClickedOff())
            {
                if (ClickedOffUpEvent != null) ClickedOffUpEvent(this, null);
                if (_clickedFlag)
                {
                    if (ClickedEvent != null) ClickedEvent(this, null);
                }
            }
            if (isClickedOn())
            {
                if (ClickedOnEvent != null) ClickedOnEvent(this, null);
                _clickedFlag = true;
                _draggedFlag = true;
            }
            if (isPressed())
            {
                if (PressingEvent != null) PressingEvent(this, null);
            }
            else
            {
                _clickedFlag = false;
            }
            if (BasicInput.Mouse.Left.Pressed == false)
            {
                _draggedFlag = false;
            }
            if (DraggableFlag && _draggedFlag)
            {
                if (DraggingEvent != null) DraggingEvent(this, null);
                _drawingPoint += BasicInput.Mouse.Speed;
            }
        }

        public abstract bool isPressed();      // 上で押されている。

       public abstract bool isClickedOn();   // 上で押した瞬間である。

       public abstract bool isClickedOff(); 　// 上で離された瞬間である。

       public abstract bool isMouseOn();     // マウスオーバーしている。
    }
}
