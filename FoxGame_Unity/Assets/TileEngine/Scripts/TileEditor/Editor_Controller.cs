using UnityEngine;
using System.Collections;

namespace TileEngine{
	public class Editor_Controller : MonoBehaviour {
		public LevelBuilder builder;
		public Editor_UI ui;
		public Editor_Input input;

		// Use this for initialization
		void Awake () {

		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void save(){
			builder.saveLevel ();
		}
		public void load(){
			builder.loadLevel ();
		}
	}
}
