using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

[System.Serializable]
public class Data_Level : DataNode {
	//SUN	
	public Color sunColor;
	public float sunBrightness;
	public Vector3 sunDirection;
	
	//GRID
	public float maxTilesX = 100;
	public float maxTilesY = 100;
	public List<Data_GameTile> tiles;

	public override SimpleJSON.JSONNode saveData ()
	{
		base.saveData ();
		JSONNode levelData = JSON.Parse ("{}");
		levelData ["maxTiles"] = maxTilesX + "," + maxTilesY;

		foreach (Data_GameTile tile in tiles) {
			levelData ["tiles"][-1] = tile.saveData();
		}

		json ["level"] = levelData;
		return json;
	}
}
