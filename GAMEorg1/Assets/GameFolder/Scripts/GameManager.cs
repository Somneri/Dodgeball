using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    //prefab
	public GameObject ballPrefab;
	public GameObject AIenemyPrefab;
	public GameObject AIplayerPrefab;
	public GameObject playerPrefab;
    //prefab clones
    [SerializeField] 
    private GameObject[] ballClone;
    [SerializeField] 
    private GameObject[] AIenemyClone;
    [SerializeField]
    private GameObject[] AIplayerClone;

	public Transform spawnPoint;
	public Transform ballSpawn;

	//desired variables
	public int numberOfBalls;
	public int numberOfEnemy;
	public int numberOfTeammates;

    private float ballDistance = 0.0f;
	// Use this for initialization
	void Awake () {
        if (numberOfBalls != 0 | numberOfBalls != null)
        {
            ballClone = new GameObject[numberOfBalls];
            for (int i = 0; i < numberOfBalls; i++)
            {
                 ballClone[i] = Instantiate(ballPrefab, new Vector3(0,ballDistance,0), Quaternion.identity) as GameObject;
                 ballDistance += 2;
            }
        }
        if (numberOfEnemy != 0 | numberOfEnemy != null)
        {
            AIenemyClone = new GameObject[numberOfEnemy];
        }
        if (numberOfTeammates != 0 | numberOfTeammates != null)
        {
            AIplayerClone = new GameObject[numberOfTeammates];
        }
        
		

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
