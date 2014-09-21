using UnityEngine;
using System.Collections;

public class UCSTest : MonoBehaviour {
	void Start () {
	
	}
	
	void Update () {
	}

	void OnGUI() {
		Debug.Log (UCS.ConvertRect (new Rect (-1.0f, -1.0f, 2.0f, 2.0f)));
		GUI.Box (UCS.ConvertRect(new Rect(-1.0f, -1.0f, 2.0f, 2.0f)), "Test");
	}
}
