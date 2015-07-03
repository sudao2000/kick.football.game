using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {	
	public Texture2D scoreTexture;
	public int totalSeconds = 60;
	
	int leaveSeconds;
	
	void Awake()
	{
		leaveSeconds = totalSeconds;
	}
	
	void Start () {
		StartCoroutine(DoCountDown());
	}
	
	// Update is called once per frame
	void Update () {
		if (leaveSeconds <= 0) {
			StopAllCoroutines ();
		}
	}
	
	void DisplayCoinsCount()
	{
		Rect coinIconRect = new Rect(30, 30, 100, 50);
		GUI.DrawTexture(coinIconRect, scoreTexture);                         
		
		GUIStyle style = new GUIStyle();
		style.fontSize = 40;
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.yellow;
		
		Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y, 60, 32);
		GUI.Label(labelRect, leaveSeconds + "", style);
	}
	
	void OnGUI()
	{
		DisplayCoinsCount();
	}
	
	IEnumerator DoCountDown()
	{
		while (leaveSeconds>0)
		{
			yield return new WaitForSeconds(1f);
			leaveSeconds--;
		}
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "football") {
			print ("collider is : " + col.name);
			StopAllCoroutines ();
		}
	}

	void OnTriggerExit2D(Collider2D col) {
	}

}
