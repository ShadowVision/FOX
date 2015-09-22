using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Data_GameTile: Data_GameAsset {
	private Color color;

	public override SimpleJSON.JSONNode saveData ()
	{
		base.saveData ();
		if (parent != null) {
			json ["name"] = parent.name;
			try{
				Color color = ((GameTile)parent).color;
				json ["color"] = color.r.ToString("F5") + "," + color.g.ToString("F5") + "," +color.b.ToString("F5") + "," + color.a.ToString("F5");
			}catch{
				Debug.LogError("Couldn't Save Game Tile");
			}
		}
		return json;
	}
	public override void loadData (SimpleJSON.JSONNode savedNode)
	{
		base.loadData (savedNode);

	}

	public override void updateParent ()
	{
		base.updateParent ();
		if(parent != null && json != null){
			try {
				string[] colors = json ["color"].Value.Split (',');
				color = new Color (float.Parse(colors [0]), float.Parse (colors [1]), float.Parse (colors [2]), float.Parse (colors [3]));
				
				if (parent != null) {
					((GameTile)parent).color = color;
				} 
			}
			catch (Exception e) {
				Debug.LogError ("Couldn't Parse Game Tile: " + e.ToString ());
			}
			loadData(json);
		}
	}
}