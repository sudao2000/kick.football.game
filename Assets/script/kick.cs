using UnityEngine;
using System.Collections;

public class kick : MonoBehaviour {
	private bool kicking;

	public GameObject arrow_pref = null;
	private GameObject arrow = null;
	
	private float maxDragArrorDistance;
	private float lastScaleFactor;
	private float arrowAngle;

	public static float MAX_FORCE = 500;

	void Start () {
		kicking = false;
		lastScaleFactor = 1;
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void kickBall() {
		rigidbody2D.AddForce (calcualteFore());
	}

	Vector2 calcualteFore() {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 ballCenter = this.transform.position;
		
		Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
		Vector2 ballCenter2D = new Vector2(ballCenter.x, ballCenter.y);
		Vector2 v = new Vector2(ballCenter2D.x - mousePos2D.x , ballCenter2D.y - mousePos2D.y );
		return v.normalized * MAX_FORCE * lastScaleFactor;
	}

	void OnMouseDrag() {
		if (kicking) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 ballCenter = this.transform.position;

			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
			Vector2 ballCenter2D = new Vector2(ballCenter.x, ballCenter.y);

			//print (mousePos.x + " " + mousePos.y+ " " + ballCenter.x+ " " + ballCenter.y+ " " );

			CircleCollider2D cc = this.GetComponent<CircleCollider2D>();
			maxDragArrorDistance = cc.radius * 8;

			float distance = Mathf.Abs(Vector2.Distance(mousePos2D, ballCenter2D)) * 10;
 
			if (distance < maxDragArrorDistance) {
				arrow.transform.localScale /= lastScaleFactor;
				lastScaleFactor = distance / maxDragArrorDistance;
				arrow.transform.localScale *= lastScaleFactor;
			} else {
				lastScaleFactor = 1;
			}

			Vector2 v = new Vector2(mousePos2D.x-ballCenter2D.x  ,mousePos2D.y - ballCenter2D.y );
			arrowAngle = Vector2.Angle(v, Vector3.left);
			arrow.transform.rotation = Quaternion.Euler(Vector3.forward * arrowAngle);
			//print ("OnMouseDrag maxDragArrorDistance " + maxDragArrorDistance + "  " + distance + " arrowAngle : " + arrowAngle); 
		}
	}

	void OnMouseDown() {
		arrow = (GameObject) Instantiate (arrow_pref, this.transform.position, this.transform.rotation);
		if (!kicking) {
			kicking = true;
		}
	}

	void OnMouseUp() {
		//print ("OnMouseUp");
		kicking = false;
		kickBall();
		if (arrow != null) {
			Destroy(arrow);
		}
	}
}
