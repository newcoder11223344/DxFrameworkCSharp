using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DxFramework
{
	class Graphic:DrawableBase
	{
		public Vector2 top {get; set; }//実体
		public Vector2 bottom { get { return top + size; } set { top = value - size; } }
		public Vector2 size {  get; private set; }//実体
		public Vector2 mid {  get { return top + size / 2; } set { top = value - size / 2; } }
		protected int graphHandle{ get;private set;}

		public Graphic(int layer):base(layer){top =new Vector2(0, 0);}
		public Graphic(Vector2 midposition, string graphName,int layer):base(layer){//ここデフォルトはmidにしたよ
			setGraphHandle(graphName);
			mid = midposition;
		}
		public override void update() { ;}
		public override void draw(){//隠し関数drawgraphF　
			DX.DrawGraphF((float)top.x,(float) top.y, graphHandle, 1);
		}
		public void setGraphHandle(int handle)
		{
			graphHandle=handle;
			int x,y;DX.GetGraphSize(graphHandle,out x,out y);
			size=new Vector2 (x,y);
		}
		public void setGraphHandle(string filename)
		{
			setGraphHandle(DX.LoadGraph(filename));
		}
		public bool pointOnFlag(Vector2 point){
			return Vector2.RectPointHit(top, bottom, point);
		}
		public bool isMoused(){
			return Vector2.RectPointHit(top, bottom, BasicInput.mouse.position);
		}
		public bool isLastDown(){//ドラッグと化すると使えなくなる　よくない
			return Vector2.RectPointHit(top, bottom, BasicInput.mouse.left.lastDown);
		}
		public bool isClickedOn(){//上で押した瞬間である
			return Vector2.RectPointHit(top, bottom, BasicInput.mouse.left.lastDown) && (BasicInput.mouse.left.down);
		}
		public bool isClickedOff(){//上で離された瞬間である
			return Vector2.RectPointHit(top, bottom, BasicInput.mouse.left.lastUp) && (BasicInput.mouse.left.up);
		}
		public bool isPressed(){//上で押されている
			return Vector2.RectPointHit(top, bottom, BasicInput.mouse.position ) && (BasicInput.mouse.left.pressed);
		}
	}
}
