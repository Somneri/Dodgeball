using UnityEngine;
using System.Collections;

public class BallThrow : MonoBehaviour {

    GameObject player;
    GameObject ball;

    Vector3 target;

    float speed = 2.0f;
    float throwCharge = 0.0f;
    float powerLimit = 5.0f;
    float angle;
    float angleRadian;

    bool ballThrown = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update () {

        ball = GameObject.FindGameObjectWithTag("ballwithplayer");

        if (ball != null) // if there is a ball with the player found
        {
            if (Input.GetMouseButton(0) && !ballThrown)
            {
                if (throwCharge < powerLimit) // limiting the charge
                    throwCharge = throwCharge + (speed * Time.deltaTime);

                //Debug.Log("Throw Charge: " + throwCharge);

            }
            else if (!Input.GetMouseButton(0) && throwCharge != 0 && !ballThrown)
            {
                if (!ballThrown)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    target = new Vector3(ray.origin.x, ray.origin.y, 0);
                    angle = player.transform.rotation.eulerAngles.z;
                    angleRadian = angle * Mathf.PI / 180;

                    ball.GetComponent<Rigidbody2D>().isKinematic = false;
                    ball.GetComponent<BallController>().isThrown = true;

                    Vector3 direction = target - player.transform.position;
                    direction.Normalize();

                    ballThrown = true;

                    ballMove(direction);
                }
            }
            else { }
        }

	}

    void ballMove(Vector3 direction)
    {

        ball.rigidbody2D.AddForce(new Vector2(100.0f * throwCharge * speed * direction.x, 100.0f * throwCharge * speed * direction.y));
        throwCharge = 0;

    }
}
