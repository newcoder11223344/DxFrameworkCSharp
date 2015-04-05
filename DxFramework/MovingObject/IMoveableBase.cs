using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxFramework.FrameWork;

namespace DxFramework
{
  interface IMoveableBase
    {
      Vector2 Center { get; set; }
      double Mass { get; set; }
      Vector2 Speed { get; set; }
    }

    interface ISquareObject :IMoveableBase
    {
      Vector2 Top { get; set; }
      Vector2 Bottom { get; set; }
    }

}
