using UnityEngine;
using System.Collections;

public class kick : MonoBehaviour {
	private bool kicked = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		if (!kicked) {
			kicked = true;
			print ("OnMouseDown");
			rigidbody2D.AddForce (new Vector2 (-100, 20));
		}
	}
}
