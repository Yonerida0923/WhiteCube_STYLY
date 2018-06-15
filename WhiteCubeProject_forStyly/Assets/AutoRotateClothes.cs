using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotateClothes : MonoBehaviour {

    public float rotateSpeed = 25f;

	void Update ()
    {
        float angle = Time.deltaTime * rotateSpeed;
        transform.Rotate(0f, angle, 0f);
	}
}
