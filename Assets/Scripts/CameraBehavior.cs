﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(GameObject))]
public class CameraBehavior : MonoBehaviour
{

	[SerializeField] GameObject player;
	public Vector3 offset;

	// Start is called before the first frame update
	void Start()
    {
		//player = GetComponent<GameObject>();
		offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
		transform.position = player.transform.position + offset;
    }
}
