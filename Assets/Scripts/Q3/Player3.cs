﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player3 : MonoBehaviour {

	public float speed;
	private float edge;

	Transform transform;
	Rigidbody rb;

	public bool top1, top2, left2, right2;

	public Text winText;
	public Text instructionText;
	public GameObject panel;
	public GameObject player;
	public GameObject retryButton;
	public GameObject isometricButton;

	void Start ()
	{
		transform = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody> ();
		edge = transform.localScale.x;

		top1 = false;
		top2 = false;
		left2 = false;
		right2 = false;

		winText.text = "";
	}

	void Update ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (transform.position.x - speed * moveVertical >= edge / 2
			&& transform.position.x - speed * moveVertical <= 2 - edge / 2
			&& transform.position.z + speed * moveHorizontal >= edge / 2
			&& transform.position.z + speed * moveHorizontal <= 4 - edge / 2) {
			transform.position += speed * (new Vector3 (-moveVertical, 0, moveHorizontal));
			if (transform.position.z <= 1) {
				rb.useGravity = false;
				transform.position += speed * (new Vector3 (0, moveHorizontal, 0));
				transform.eulerAngles = new Vector3 (-45, 0, 0);
			} else if ((transform.position.z > 2 && transform.position.z < 3 && transform.position.x < 1) 
				|| (transform.position.z > 2 && transform.position.x >= 1)) {
				rb.useGravity = false;
				transform.position += speed * (new Vector3 (0, -moveHorizontal, 0));
				transform.eulerAngles = new Vector3 (45, 0, 0);
			} else {
				rb.useGravity = true;
			}
		}

		if (Input.GetButtonDown ("Submit")) {
			if (top1 && top2 && left2 && right2) {
				panel.SetActive (true);
				winText.text = "You Win!";
				instructionText.text = "";
				player.SetActive (false);
				retryButton.SetActive (true);
				isometricButton.SetActive (true);
			} else {
				panel.SetActive (true);
				winText.text = "Inadequate Exploration!";
				instructionText.text = "";
				player.SetActive (false);
				retryButton.SetActive (true);
				isometricButton.SetActive (true);
			}
		}

	}
}
