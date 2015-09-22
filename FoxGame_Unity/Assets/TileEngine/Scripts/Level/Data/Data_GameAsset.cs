using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Data_GameAsset : DataNode {
	[HideInInspector]
	private TilePosition tilePosition = new TilePosition(0,0,0);
	
	private  GameAsset _parent;
	public GameAsset parent{
		get{
			return _parent;
		}
		set{
			_parent = value;
		}
	}

	virtual public TilePosition position{ 
		get { 
			return tilePosition; 
		} set{
			tilePosition = value;

		}
	}

	public override SimpleJSON.JSONNode saveData ()
	{
		json = base.saveData ();
		json.Add ("PositionX", position.x.ToString());
		json.Add ("PositionY", position.y.ToString());
		json.Add ("PositionZ", position.z.ToString());
		return json;
	}
	public override void loadData (SimpleJSON.JSONNode savedNode)
	{
		base.loadData (savedNode);
		position = new TilePosition (savedNode ["PositionX"].AsInt, savedNode ["PositionY"].AsInt, savedNode ["PositionZ"].AsInt);
	}

	public virtual void updateParent(){
		if (_parent != null) {
			_parent.transform.position = new Vector3(position.x,position.y,position.z);
		}
	}
}