﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxFramework
{
	class Scene
	{
		protected Scene nextScene;
		SortedDictionary<int, List<DrawableBase>> DrawableList;
		public Scene(){
			DrawableList = new SortedDictionary<int, List<DrawableBase>>();//init,update,startscene(未実装),draw
		}
		public virtual void init() { setAutoAddFunc(); nextScene = this; }//ここでリストをセット！
		public virtual Scene update()
		{
			nextScene = this;
			setAutoAddFunc();//ここでリストをセット！
			foreach (KeyValuePair<int, List<DrawableBase>> l in DrawableList.ToArray()){
				foreach (int i in Enumerable.Range(0, l.Value.Count())){
					l.Value[i].update();
				}
			}
			return this.nextScene;
		}
		void setAutoAddFunc(){
			DrawableBase.setAutoAddFunc(addChild);
		}
		public virtual void draw(){
			foreach (KeyValuePair<int,List<DrawableBase>> l in DrawableList.ToArray()){foreach(int i in Enumerable.Range(0,l.Value.Count())){
				if (l.Value[i].isVisible) l.Value[i].draw();
			}
			}
		}
		public void addChild(DrawableBase obj){
			if (DrawableList.ContainsKey(obj.layer) == false) { DrawableList.Add(obj.layer, new List<DrawableBase>()); }
			DrawableList[obj.layer].Add(obj);
		}

	}
}
//TODO
/*afterdrawいらない
 *ボタンのデフォルトバージョンみたいなのは、staticでmakeDefaultButtonみたいな感じで作る
 *init,update,startscene(未実装),draw
 *上記のうち、draw以外はちゃんとbaseを呼ぶ（setautoaddlist関係)
 *もしくは、setautoaddlistはスタック状にする？
 *そして明示的に読んだ方がいい？
 * */