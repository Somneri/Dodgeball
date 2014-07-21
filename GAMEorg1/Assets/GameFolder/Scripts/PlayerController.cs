using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//public BallController[] ballCon;

	public float moveSpeed = 5.0f;
	public float h_Move;
	public float v_Move;

	public bool canPick;
	public bool acquireBall;
	public float ballCount;

    [SerializeField]
    Vector3 currentPos;
    [SerializeField]
    Vector3 newPos;
    [SerializeField]
    float mouseAngle;

    [SerializeField]
    Vector3 mousePoint;

    Event e;
    RaycastHit ray;

   public enum PlayerState
    {
        IDLE,
        MOVING
    };

    public PlayerState myState;

	void Start () {	
            
		//ballCon = FindObjectsOfType<BallController>();
        // Debug.Log(ballCon);
        myState = PlayerState.IDLE;
		ballCount = 0;
	}

	void Update () {

        currentPos = transform.position;

		/*foreach( BallController ball in ballCon)
        {
			if(ball != null)
            {
				if(ball.isInside)
                {
					//right mouse button
					if(Input.GetMouseButtonDown(1))
                    {
						if(ball.isActive)
                        {
							ballCount += 1;
							ball.isActive = false;
						}
					}
				}
			}
		}*/

        PlayerLookAtMouse();
        PlayerMove();
      
	}

    void PlayerMove()
    {
		h_Move = Input.GetAxis("Horizontal")* moveSpeed;
		v_Move = Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(h_Move * Time.deltaTime , v_Move * Time.deltaTime , 0, Space.World);
        if (h_Move == 0 && v_Move == 0)
        {
            myState = PlayerState.IDLE;
        }
        else
        {
            myState = PlayerState.MOVING;
		}
    }

    void ThrowBall() {
        if (ballCount > 0) {
         
            
        }
    }

    void PlayerLookAtMouse() {
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position); 
        mousePoint = Input.mousePosition - objectPos;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(mousePoint.y, mousePoint.x) * Mathf.Rad2Deg));
    }
 


}
