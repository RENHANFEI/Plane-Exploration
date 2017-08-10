﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player5 : MonoBehaviour {

	public float speed;
	private float edge;

	Transform transform;
	Rigidbody rb;

	public bool top1, top2, front1, curve1;

	public Text winText;
	public Text instructionText;
	public GameObject panel;
	public GameObject player;
	public GameObject retryButton;
	public GameObject isometricButton;

	private static float r = 1.0f;

	void Start ()
	{
		transform = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody> ();
		edge = transform.localScale.x;

		top1 = false;
		top2 = false;
		front1 = false;
		curve1 = false;

		winText.text = "";
	}

	void Update ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (transform.position.x - speed * moveVertical >= edge / 2
			&& transform.position.x - speed * moveVertical <= 3 - edge / 2
			&& transform.position.z + speed * moveHorizontal >= edge / 2
			&& transform.position.z + speed * moveHorizontal <= 4 - edge / 2) {
			transform.position += speed * (new Vector3 (-moveVertical, 0, moveHorizontal));
			if (transform.position.x >= 1) {
				player.layer = 0;
				rb.useGravity = false;
				transform.position += speed * (new Vector3 (0, moveVertical, 0));
				transform.eulerAngles = new Vector3 (0, 0, -45);
			} else if (transform.position.z >= 1 && transform.position.z <= 3) {
				rb.useGravity = false;
				player.layer = 9;
//				float offsetZ = transform.position.z - 1;
//				float degree = Mathf.Acos ((r - offsetZ) / r) / Mathf.PI * 180;
//				float downY = Mathf.Pow (r * r - (r - offsetZ) * (r - offsetZ), 0.5f);
//				transform.position = new Vector3 (transform.position.x, 2.1f - downY, transform.position.z);
//				transform.eulerAngles = new Vector3 (- degree, 0, 0);
				transform.position = new Vector3 (transform.position.x, 2.2f, transform.position.z);
			} else {
				player.layer = 0;
				rb.useGravity = true;
				transform.eulerAngles = new Vector3 (0, 0, 0);
			}
		}

		if (Input.GetButtonDown ("Submit")) {
			if (top1 && top2 && front1 && curve1) {
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
