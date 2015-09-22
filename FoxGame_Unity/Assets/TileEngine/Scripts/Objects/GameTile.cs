using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTile : GameAsset {
	private Data_GameTile _myData;
	public Data_GameTile myData{
		get{
			return _myData;
		}
		set{
			_myData = value;
			_myData.parent = (GameTile)this;
			data = _myData;
			_myData.updateParent();
		}
	}
	public Color color{
		get{
			return renderer.material.color;
		}
		set{
			renderer.material.color = value;
		}
	}

	private Renderer renderer;

	// Use this for initialization
	void Awake(){
		renderer = gameObject.GetComponentInChildren<MeshRenderer> ();
	}
	void Start () {

	}
	// Update is called once per frame
	void Update () {
	
	}

	/*public void init(LevelData.LevelTile_Options options){
		position = options.position;
		transform.position = new Vector3(options.position.x,options.position.y,options.position.z);
	}*/
}
