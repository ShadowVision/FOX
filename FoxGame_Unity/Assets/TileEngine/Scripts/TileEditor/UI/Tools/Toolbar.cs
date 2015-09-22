using UnityEngine;
using System.Collections;

namespace TileEngine{
	public class Toolbar : MonoBehaviour {
		[HideInInspector]
		public UI_HUD hud;
		public Tool[] tools;

		// Use this for initialization
		void Awake(){
			foreach(Tool tool in tools){
				tool.toolbar = (Toolbar)this;
				tool.deselect();
			}
		}

		public void deselectAllTools(){
			foreach(Tool tool in tools){
				tool.deselect();
			}
		}

		void Update(){
			foreach (Tool tool in tools) {
				if(Input.GetKeyUp(tool.hotKeyButton)){
					tool.select();
				}
			}
		}
	}
}