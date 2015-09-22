using UnityEngine;
using System.Collections;

namespace TileEngine{
public class Tool : MonoBehaviour {
	[HideInInspector]
	public Toolbar toolbar;
	public virtual void enableTool (){enabled = true;}
	public virtual void disableTool (){enabled = false;}

	public KeyCode hotKeyButton;

	
	public virtual void select(){
		Debug.Log("Selecting Tool: " + name);
		toolbar.deselectAllTools();
		enableTool();
	}
	public virtual void deselect(){
		disableTool();
	}
	
	public void captureTile(){
		
	}
}
}