using UnityEngine;
using System.Collections;

public class barrierFloat : MonoBehaviour {
	
	private int volocity = 1;

	public Vector3 direction;

	void Start () {
		direction = Vector3.up;
	}

	void Update () {
		Rigidbody2D body = this.GetComponent<Rigidbody2D> ();
		body.transform.Translate(direction * volocity * Time.deltaTime);
	}


}
