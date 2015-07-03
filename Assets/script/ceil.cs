using UnityEngine;
using System.Collections;

public class ceil : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "barrier") {
			print ("collider is : " + col.name);
			GameObject o = col.gameObject;
			barrierFloat bf = o.GetComponent<barrierFloat>();
			bf.direction = Vector3.down;
		}
	}
}
