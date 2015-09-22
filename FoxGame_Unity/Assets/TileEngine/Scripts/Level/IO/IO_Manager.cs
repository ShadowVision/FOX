using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.IO;

public class IO_Manager : MonoBehaviour {
	private string folderPath = "";
	public string defaultDirName = "Default";
	public string defaultFileName = "default";
	// Use this for initialization
	void Awake(){
		folderPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.MyDocuments) + "/" + defaultDirName + "/";
	}
	void Start () {
		createDefaultFolders ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void createDefaultFolders(){
		if (!Directory.Exists (folderPath + defaultDirName)) {
			Directory.CreateDirectory(folderPath + defaultDirName);

			saveData(JSON.Parse("{ default:\"value\";}"));
		}
	}

	public void saveData(JSONNode json, string dirName="", string fileName=""){
		if (dirName == "") {
			dirName = defaultDirName;
		}
		if (fileName == "") {
			fileName = defaultFileName;
		}
		
		Debug.Log ("Saving Data: " + json.ToString());

		if (!Directory.Exists (folderPath + dirName)) {
			Directory.CreateDirectory(folderPath + dirName);
		}
		string path = folderPath + dirName + "/" + fileName + ".json";

		Debug.Log ("Saving To: " + path);

		File.WriteAllText(path , json.ToString());
	}

	public JSONNode loadData(string dirName="", string fileName=""){
		string path = folderPath + dirName + "/" + fileName + ".json";
		Debug.Log("Loading Level: " + path);
		JSONNode data = JSON.Parse (File.ReadAllText (path));
		return data;
	}
}
