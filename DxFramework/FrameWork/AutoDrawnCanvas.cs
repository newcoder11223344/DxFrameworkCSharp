using DxLibDLL;
namespace DxFramework.FrameWork
{

    internal delegate void NomalEventHandler(object sender, object eventArgs);

    class AutoDrawnCanvas : AutoDrawnBase
    {
        public AutoDrawnCanvas(int layer)
            : this(layer,new Vector2(0,0),new Vector2(100,50) )
        {}

        public AutoDrawnCanvas(int layer, DrawableCanvas square)
            : base(layer)
        {
            _canvas = square;
            DraggableFlag = false;    　　　　　　　　　　// デフォルトではドラッグできません。
        }

        public AutoDrawnCanvas(int layer, Vector2 top, Vector2 size)
            : base(layer)
        {
            _canvas = new DrawableCanvas(top, size);
            DraggableFlag = false;                        // デフォルトではドラッグできません。
        }


        public DrawableCanvas Canvas                      // 描画対象
        {
            get { return _canvas; }
            set { _canvas = value; }
        }
  
        virtual public Vector2 Top                         // 左上の座標
        {
            get {return _canvas.Top; }
            set { _canvas.Top = value; }
        }

       virtual  public Vector2 Size                        // 左上を基準にしたサイズ
        {
            get { return _canvas.Size; }
            set { _canvas.Size = value; }
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
        private bool _draggedFlag;
       protected DrawableCanvas _canvas;

        public override void draw()
        {
         _canvas.draw();
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
