using UnityEngine;
using System.Collections;

namespace TileEngine{
	public class Editor_Input : MonoBehaviour {
		Editor_Controller controller;
		// Use this for initialization
		void Awake () {
			controller = gameObject.GetComponent < Editor_Controller> ();
		}
		
		// Update is called once per frame
		void Update () {
			if(Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.LeftCommand)){
				controller.save();
			}else if(Input.GetKeyDown(KeyCode.L) && Input.GetKey(KeyCode.LeftCommand)){
				controller.load();
			}
		}
	}
}
