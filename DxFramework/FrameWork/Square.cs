using DxFramework.FrameWork.Bases;
using DxFramework.FrameWork.Materials;
using DxFramework.FrameWork.Utils;
using DxLibDLL;
namespace DxFramework.FrameWork
{

    class Square :ShapeBase
    {
        public Square(int layer)
            : this(layer, new Vector2(1, 1), new Vector2(100, 50)) { }

        public Square(int layer, Vector2 top, ISquareMaterialBase canvas)
            : base(layer)
        {
            Top = top;
            SquareMaterial = canvas;
            Size = SquareMaterial.Size;
        }

        public Square(int layer, Vector2 top, Vector2 size)
            : base(layer)
        {
            SquareMaterial = new SquareMaterial();
            Top = top;
            Size = size;
        }

        public  ISquareMaterialBase SquareMaterial { get; set; }   // 描画対象

        public override IMaterialBase Material
        {
            get { return SquareMaterial; }
            set { SquareMaterial = value as ISquareMaterialBase; }
        }

        public virtual Vector2 Top                          // 左上の座標
        {
            get { return _drawingPoint; }
            set { _drawingPoint = value; }
        }          
       
        public virtual Vector2 Size                        // 左上を基準にしたサイズ
        {
            get { return _size; }
            set
            {
                SquareMaterial.Size = new Vector2(SquareMaterial.Size.x * value.x / _size.x, SquareMaterial.Size.y * value.y / _size.y);
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
          
        private Vector2 _size = new Vector2(1, 1);

        public bool pointOnFlag(Vector2 point)
        {
            return Vector2.RectPointHit(Top, Bottom, point);
        }
       
        public bool isLastDown()  // ドラッグと化すると使えなくなる　よくない
        {
            return Vector2.RectPointHit(Top, Bottom, BasicInput.Mouse.Left.LastDown);
        }

        public override bool isMouseOn()
        {
            return Vector2.RectPointHit(Top, Bottom, BasicInput.Mouse.Position);
        }

        public override bool isClickedOn()
        {
            return Vector2.RectPointHit(Top, Bottom, BasicInput.Mouse.Left.LastDown) && (BasicInput.Mouse.Left.Down);
        }

        public override bool isClickedOff()
        {
            return Vector2.RectPointHit(Top, Bottom, BasicInput.Mouse.Left.LastUp) && (BasicInput.Mouse.Left.Up);
        }

        public override bool isPressed()
        {
            return Vector2.RectPointHit(Top, Bottom, BasicInput.Mouse.Position) && (BasicInput.Mouse.Left.Pressed);
        }
    }
}
