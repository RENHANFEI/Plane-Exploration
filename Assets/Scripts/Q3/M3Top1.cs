﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3Top1 : MonoBehaviour {

	public GameObject gameObject;
	public GameObject player;

	private Vector3[] top1;

	private MeshFilter meshFilter;
	private Mesh mesh;

	public bool collide = false;

	void Start () {

		// get mesh from mesh filter
		meshFilter = (MeshFilter)gameObject.GetComponent(typeof(MeshFilter));


		// set mesh
		top1 = new Vector3[] {
			new Vector3 (0, 3, 1),
			new Vector3 (0, 3, 2), 
			new Vector3 (2, 3, 2),
			new Vector3 (2, 3, 1)
		};

		mesh = new Mesh ();

		mesh.vertices = new Vector3[] {
			top1 [0], top1 [1], top1 [3],
			top1 [3], top1 [1], top1 [2]
		};

		mesh.triangles = new int[] { 0, 1, 2, 3, 4, 5 };

		// set collide
		collide = false;


	}

	// render
	void Update () {

		if (collide)
			meshFilter.mesh = mesh;

	}

	// collision trigger
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Player")) {
			collide = true;
			player.GetComponent<Player3> ().top1 = true;
		}
	}
}
