using UnityEngine;
using System.Collections;

public class stone : MonoBehaviour {

	//1
	public Sprite laserOnSprite;    
	public Sprite laserOffSprite;
	
	//2    
	public float interval = 1.2f;    
	public float rotationSpeed = 6.0f;
	
	//3
	private bool isLaserOn = true;    
	private float timeUntilNextToggle;


	// Use this for initialization
	void Start () {
		timeUntilNextToggle = interval;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		
		//1
		timeUntilNextToggle -= Time.fixedDeltaTime;
		
		//2
		if (timeUntilNextToggle <= 0) {
			
			//3
			isLaserOn = !isLaserOn;
			
			//4
			collider2D.enabled = isLaserOn;
			//collider2D.enabled = true;
			
			//5
			SpriteRenderer spriteRenderer = ((SpriteRenderer)this.renderer);
			if (isLaserOn)
				spriteRenderer.sprite = laserOnSprite;
			else
				spriteRenderer.sprite = laserOffSprite;
			
			//6
			timeUntilNextToggle = interval;
		}
		
		//7
		transform.RotateAround(transform.position, 
		                       Vector3.forward, 
		                       rotationSpeed * Time. fixedDeltaTime);
	}




}
