﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public static Camera cam{
		get{
			return CameraSwitch.activeCamera;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
