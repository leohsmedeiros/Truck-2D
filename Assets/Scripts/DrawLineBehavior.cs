using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DrawLineBehavior : MonoBehaviour {
	public GameObject Line;
	public Transform light_following_finger;
	GameObject referenceParent;

	bool StartWasSetted = false;

	Vector3 posStart;
	Vector3 posCur;
	Vector3 integerPos;

	List<Vector3> points; 


	bool ContainPoint (Vector3 newPoint)
	{
		foreach (Vector3 point in points) {
			if (point.x == newPoint.x && point.y == newPoint.y) {
				return true;
			}
		}

		return false;
	}
		
	void Update()
	{
		if (Input.GetMouseButton (0)) {

			if (!StartWasSetted) {
				
				referenceParent = new GameObject ("DrawParent");
				referenceParent.transform.SetParent (this.transform);

				StartWasSetted = true;

				integerPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				integerPos.z = 0;

				light_following_finger.position = integerPos;

				posStart = integerPos;
				points = new List<Vector3> ();
				return;
			}


			integerPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			integerPos.z = 0;

			light_following_finger.position = integerPos;

			if (!ContainPoint (integerPos)) {
				points.Add (integerPos);

				GameObject newLine = Instantiate (Line, integerPos, Quaternion.identity) as GameObject;
				newLine.transform.SetParent (referenceParent.transform);

//				if(referenceParent.transform.childCount > 2)
//				{
//					newLine.transform.LookAt (referenceParent.transform.GetChild (referenceParent.transform.childCount - 2));
//
//					Vector3 newEulerAngles = newLine.transform.eulerAngles;
//
//					newEulerAngles.z = newEulerAngles.x;
//					newEulerAngles.y = 0;
//					newEulerAngles.x = 0;
//
//					newLine.transform.eulerAngles = newEulerAngles;
//
//				}

			}
		}


		if (Input.GetMouseButtonUp (0)) {
			light_following_finger.position = new Vector3 (-1000, 0, 0);
			
			this.transform.GetChild (this.transform.childCount - 1).gameObject.AddComponent<Rigidbody2D> ();
			this.transform.GetChild (this.transform.childCount - 1).gameObject.GetComponent<Rigidbody2D> ().mass = 5000;
			StartWasSetted = false;
		}



	}






















}
