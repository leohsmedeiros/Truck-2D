using UnityEngine;
using System.Collections;

public class TruckBehavior : MonoBehaviour {

//	public Rigidbody2D[] pneus;

	// Use this for initialization
	void Start () {
		Physics2D.gravity = new Vector2(0, -9);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-3, this.transform.GetComponent<Rigidbody2D> ().velocity.y);
//			pneus[0].velocity = new Vector2 (-3, 0);
		}


		if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (3, this.transform.GetComponent<Rigidbody2D> ().velocity.y);
//			pneus[1].velocity = new Vector2 (3, 0);
		}

	}
}
