using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	// Use this for initialization
    public static int numBallWithPlayer = 0;
	public PlayerController player;
	public bool isInside;
	public bool isActive;

    //dns
    public bool isThrown = false;

	void Start () {
		if(gameObject.activeSelf){
			isActive = true;	
		}
		player = GameObject.Find("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("ball with player: " + numBallWithPlayer);
        if (!isActive)
        {
            // gameObject.SetActive(false);
            
            // dns code:
            if (!isThrown)
            {
                //Debug.Log("in !isThrown");
                GameObject armField = GameObject.FindGameObjectWithTag("PlayerCatchField");
                transform.position = armField.transform.position;
                gameObject.tag = "ballwithplayer";

                gameObject.rigidbody2D.isKinematic = true;

                //Debug.Log(gameObject.GetComponent<BallThrow>());
                if(gameObject.GetComponent<BallThrow>() == null)
                    gameObject.AddComponent<BallThrow>();
            }

        }
        if (isThrown)
        {
            numBallWithPlayer = 0;
            gameObject.tag = "ball";
            if (gameObject.GetComponent<BallThrow>() != null)
                Destroy(GetComponent("BallThrow"));
        }
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerCatchField")
        {
            isInside = true;

            if (Input.GetMouseButtonDown(1) && numBallWithPlayer == 0)
            {
                if (isActive)
                {
                    numBallWithPlayer = 1;
                    isActive = false;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerCatchField")
        {
            isInside = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "wall")
        {
           isActive = true;
           isThrown = false;
        }

    }
}
