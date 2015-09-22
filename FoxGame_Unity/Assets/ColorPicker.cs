using UnityEngine;
using System.Collections;


namespace TileEngine{
	public class ColorPicker : Tool {
		public static Color currentColor;

		public KeyCode nextKey;
		public KeyCode prevKey;
		public KeyCode debugKey;
		public Color[] colors;
		public Sprite colorSprite; 

		private int currentColorI = 0;
		private bool showColorPicker = false;
		private Vector2 spriteSize;

		public override void enableTool ()
		{

		}
		public override void disableTool ()
		{

		}
		public void Awake(){
			setColorSwatch (0);
			spriteSize = new Vector2 (colorSprite.texture.width, colorSprite.texture.height);
		}
		void Update(){
			if (Input.GetKeyDown (nextKey)) {
				nextColorSwatch();
			}
			if (Input.GetKeyDown (prevKey)) {
				prevColorSwatch();
			}
			if (Input.GetKeyDown (debugKey)) {
				startSelectColor();
			}

			if (showColorPicker) {
				if(Input.GetMouseButtonDown(0)){
					pickColor();
				}
			}
		}
		void OnGUI(){
			if (showColorPicker) {
				GUI.DrawTexture(new Rect(Screen.width/2f - spriteSize.x/2,Screen.height/2f - spriteSize.y/2, spriteSize.x,spriteSize.y), colorSprite.texture);
			}
		}

		public void setColorSwatch(int i){
			currentColorI = i;
			currentColor = colors [currentColorI];
		}
		
		public void nextColorSwatch(){
			currentColorI++;
			if (currentColorI >= colors.Length) {
				currentColorI = 0;
			}
			setColorSwatch (currentColorI);
		}
		public void prevColorSwatch(){
			currentColorI--;
			if (currentColorI < 0) {
				currentColorI =  colors.Length-1;
			}
			setColorSwatch (currentColorI);
		}

		public void startSelectColor(){
			showColorPicker = true;
			select ();
		}
		private void finishSelectColor(){
			deselect ();
			showColorPicker = false;
		}
		private void pickColor(){
			Vector2 mousePos = Input.mousePosition;
			mousePos.x -= Screen.width / 2 - spriteSize.x / 2;
			mousePos.y -= Screen.height / 2 - spriteSize.y / 2;
			if (mousePos.x > 0 && mousePos.y > 0 && mousePos.x < spriteSize.x && mousePos.y < spriteSize.y) {
				setColor(colorSprite.texture.GetPixel((int)mousePos.x,(int)mousePos.y));
				finishSelectColor();
			}
		}
		private void setColor(Color newColor){
			colors [currentColorI] = newColor;
			currentColor = newColor;
		}

	}
}
