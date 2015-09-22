using UnityEngine;
using System.Collections;

namespace TileEngine{
	public class Tool_ColorTile : Tool {

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		new void Update () {
			if (Input.GetMouseButtonDown (0)) {
				findTilePosition(true);
			}
			if (Input.GetMouseButtonDown (1)) {
				findTilePosition(false);
			}
		}
		private void findTilePosition(bool add){
			Ray mouseRay = CameraController.cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			if (Physics.Raycast (mouseRay,out hitInfo, 500)) {
				if(add){
					GameTile tile = hitInfo.collider.gameObject.GetComponent<GameTile>();
					if(tile != null){
						tile.color = ColorPicker.currentColor;
					}
				}
			}
		}
	}
}