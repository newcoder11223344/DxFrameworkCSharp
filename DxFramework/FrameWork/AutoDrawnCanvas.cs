using DxLibDLL;
namespace DxFramework.FrameWork
{

    internal delegate void NomalEventHandler(object sender, object eventArgs);

    class AutoDrawnCanvas : AutoDrawnBase,IMouseObjectBase
    {
        public AutoDrawnCanvas(int layer)
            : this(layer, new Vector2(0, 0), new Vector2(100, 50))
        { }

        public AutoDrawnCanvas(int layer, ICanvasBase canvas)
            : base(layer)
        {
            Canvas = canvas;
            Top = Canvas.Top;
            Size = Canvas.Size;
            DraggableFlag = false;    　　　　　　　　　　// デフォルトではドラッグできません。
        }

        public AutoDrawnCanvas(int layer, Vector2 top, Vector2 size)
            : base(layer)
        {
            Canvas= new Canvas(top,size);
            Top = top;
            Size = size;
            DraggableFlag = false;                        // デフォルトではドラッグできません。
        }


        public ICanvasBase Canvas { get; set; }            // 描画対象
       

        public Vector2 Top                                 // 左上の座標
        {
            get { return _top; }
            set
            {
                Canvas.Top += value - _top;
                _top = value;
            }
        }

        public Vector2 Size                               // 左上を基準にしたサイズ
        {
            get { return _size; }
            set
            {
                Canvas.Size = new Vector2(value.x / _size.x, value.y / _size.y);
                _size = value;
            }
        }

        public Vector2 Bottom                              // 右下の座標
        {
            get { return Top + Size; }
            set { Top = value - Size; }
        }

        public Vector2 Mid                                 // 中心の座標
        {
            get { return Top + Size / 2; }
            set { Top = value - Size / 2; }
        }

        public bool DraggableFlag { get; set; }　　　　　 // ドラッグ機能

        public event NomalEventHandler MouseOnEvent;　　　// マウスオーバー時に発生します。

        public event NomalEventHandler ClickedEvent;  　　// クリック完了時に発生します。

        public event NomalEventHandler ClickedOnEvent;　　// 上で押された時に発生します。

        public event NomalEventHandler ClickedOffUpEvent; // 上で離された時に発生します。

        public event NomalEventHandler PressingEvent; 　　// 押されている間に発生します。

        public event NomalEventHandler DraggingEvent;     //ドラッグされている間に発生します。

        private bool _clickedFlag = false;
        private bool _draggedFlag = false;
        private Vector2 _top;
        private Vector2 _size;

        public override void draw()
        {
            Canvas.DrawAction();
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
            if (BasicInput.mouse.left.pressed == false)
            {
                _draggedFlag = false;
            }
            if (DraggableFlag && _draggedFlag)
            {
                if (DraggingEvent != null) DraggingEvent(this, null);
                Top += BasicInput.mouse.speed;
            }
        }


        public bool pointOnFlag(Vector2 point)
        {
            return Vector2.RectPointHit(Top, Bottom, point);
        }
        public bool isMouseOn()
        {
            return Vector2.RectPointHit(Top, Bottom, BasicInput.mouse.position);
        }
        public bool isLastDown()　　　　// ドラッグと化すると使えなくなる　よくない
        {
            return Vector2.RectPointHit(Top, Bottom, BasicInput.mouse.left.lastDown);
        }
        public bool isClickedOn()　　　// 上で押した瞬間である。
        {
            return Vector2.RectPointHit(Top, Bottom, BasicInput.mouse.left.lastDown) && (BasicInput.mouse.left.down);
        }
        public bool isClickedOff()　　　// 上で離された瞬間である。
        {
            return Vector2.RectPointHit(Top, Bottom, BasicInput.mouse.left.lastUp) && (BasicInput.mouse.left.up);
        }
        public bool isPressed()　　　　// 上で押されている。
        {
            return Vector2.RectPointHit(Top, Bottom, BasicInput.mouse.position) && (BasicInput.mouse.left.pressed);
        }


    }
}
