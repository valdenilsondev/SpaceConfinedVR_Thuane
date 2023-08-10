using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {


	private Rigidbody rbPlayer;
	// Use this for initialization
	void Start () {
		rbPlayer = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.W))
		{
			rbPlayer.velocity = Vector3.forward;
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			rbPlayer.velocity = Vector3.forward * 0;
		}

	}
}
