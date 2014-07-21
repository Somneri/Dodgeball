using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
    public Transform target;

	void Update () {
        transform.position = target.position;
        transform.position += new Vector3(0, 0, -10);
	}
}
