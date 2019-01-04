﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    [SerializeField] float destructDelay = 3f;

	void Start ()
    {
        Destroy(gameObject, destructDelay);
	}
}
