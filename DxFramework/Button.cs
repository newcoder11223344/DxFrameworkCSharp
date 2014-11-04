using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DxFramework
{
	class Button:Graphic
	{
		public string text{get;set;}
		public int textColor{get;set;}
		public int color{ get; set; }
		public int mouseOnColor { get; set; }
		public Vector2 textPosition{get;set;}
		public int TLight { get; private set; }
		public int TGraphHandle { get;private set;}
		public bool colorFlag { get; set; }
		public int clickedTimes { get; private set; }
		public bool draggableFlag{get;set;}
		public bool draggedFlag{get;private set;}
		protected Action clickedAction;
		public Button(int layer):base(layer)
		{ init();
		}
		public Button(Vector2 midpos, int layer, string graphicname, Action clicked):base(layer){
			init();
			mid = midpos;
			setGraph(graphicname);
			clickedAction = clicked;
		}
		public void init(){
			text = "";
			textColor = DX.GetColor(0, 0, 0);
			color = DX.GetColor(170, 170, 170);
			mouseOnColor = DX.GetColor(200, 200, 200);
			textPosition =new Vector2(0, 0);
			TLight = 50;
			colorFlag = true;
			draggableFlag = false;
			draggedFlag = false;
			clickedTimes =0;
			clickedAction = () => this.initialClickedAction();
		}
		private void initialClickedAction(){
			;
		}
		public void setClickedAction(Action a){
			clickedAction = a;
		}
		public override void update(){
			base.update();
			if (isClickedOn()) draggedFlag = true;
			if(BasicInput .mouse.left.pressed==false)draggedFlag=false;
			if (draggableFlag && draggedFlag) mid += BasicInput.mouse.speed;
			if ( isClickedOff()) { clickedAction(); clickedTimes++; }
		}
		public void setTLight(int light){
			TLight = light;
			TGraphHandle = DX.MakeGraph((int)size.x, (int)size.y);
			DX.GraphFilterBlt(graphHandle,TGraphHandle, DX.DX_GRAPH_FILTER_HSB,0,0,0,light);

		}
		public void setGraph(string graphName){
			colorFlag = false;
			base.setGraphHandle(graphName);
			TGraphHandle = graphHandle;
		}
		public override void draw(){
			if (isMoused()){
				if (colorFlag) DX.DrawBox((int)top.x,(int) top.y, (int)bottom.x,(int) bottom.y, mouseOnColor,1);
				DX.DrawGraphF((float)top.x, (float)top.y, TGraphHandle,1);
			}else{
				if (colorFlag) DX.DrawBox((int)top.x, (int)top.y, (int)bottom.x, (int)bottom.y,color, 1);
				base.draw();
			}
			DX.DrawStringF((float)(top.x + textPosition.x), (float)(top.y + textPosition.y), text, textColor);
			
		}
	}
}
