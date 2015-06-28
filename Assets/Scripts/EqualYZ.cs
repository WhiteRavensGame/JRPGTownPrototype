using UnityEngine;
using System.Collections;

public class EqualYZ : MonoBehaviour {

	public float offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 oldPos = transform.position;
		oldPos.z = oldPos.y + offset;
		transform.position = oldPos;

		if(Input.GetKey (KeyCode.W))
		{
			transform.Translate(Vector3.up*Time.deltaTime);
		}
		else if(Input.GetKey (KeyCode.S))
		{
			transform.Translate(Vector3.down*Time.deltaTime);
		}
		else if(Input.GetKey (KeyCode.A))
		{
			transform.Translate(Vector3.left*Time.deltaTime);
		}
		else if(Input.GetKey (KeyCode.D))
		{
			transform.Translate(Vector3.right*Time.deltaTime);
		}
	}


}
