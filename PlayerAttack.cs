using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	
	public GameObject otherGameObject;
	public string direction = "left"; // probably don't need this anymore but it's helpful to look at in the inspector.
	public PlayerLogic logic;
	public static int playerAttack = 5;
	
	public GameLogic gameLogic;
	public GameObject daggerObject;
	public Transform daggerSpawnPosition;
	float RANDOM_daggerSpawnPositionY;
	
	public GameObject slashUpEffect;
	public GameObject slashMidEffect;
	public GameObject slashDownEffect;
	public Transform slashSpawnPosition;
	void Awake () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(gameLogic.gameState == 0)
		{
			// TODO Figure out the orientation (left or right) of the sprite
			
			// Player is facing left 
			if (PlayerMove.isLeft == 1) { 
				direction = "left";
				performAttack();
			}
			 
			else
				
			// Player is facing right	
			if (PlayerMove.isLeft == 0) { 
				direction = "right";
				performAttack ();
			}
		}
	}
	
	/* When an attack button is pressed, we start the delay timer
	 * 
	 * */
	void performAttack () {
		
		if (Input.GetKeyDown(KeyCode.A)) {
				Transform inst = PoolManager.Pools["Spawn Pool"].Spawn(slashUpEffect.transform, slashSpawnPosition.position, slashUpEffect.transform.rotation);
				delayNextAttack ();
				playerAttack = 0;
				logic.HitBox.tag = "a";
				print ("Top " + direction + " Attack");
		} else
		
		if (Input.GetKeyDown(KeyCode.S)) {
			Transform inst = PoolManager.Pools["Spawn Pool"].Spawn(slashMidEffect.transform, slashSpawnPosition.position, slashUpEffect.transform.rotation);
				delayNextAttack ();
				playerAttack = 1;
				logic.HitBox.tag = "s";
				print ("Middle " + direction + " Attack");
		} else
			
		if (Input.GetKeyDown(KeyCode.D)) {
			Transform inst = PoolManager.Pools["Spawn Pool"].Spawn(slashDownEffect.transform, slashSpawnPosition.position, slashUpEffect.transform.rotation);
				delayNextAttack ();
				playerAttack = 2;
				logic.HitBox.tag = "d";
				print ("Bottom " + direction + " Attack");
		} else
		
		if(gameLogic.playerDaggerRemaining > 0)
		{
			if (Input.GetKeyDown(KeyCode.DownArrow)) {
				playerAttack = 3;
				RANDOM_daggerSpawnPositionY = Random.Range (-0.1f, 0.1f);
				Transform inst = PoolManager.Pools["Spawn Pool"].Spawn(daggerObject.transform, new Vector3(daggerSpawnPosition.position.x, daggerSpawnPosition.position.y + RANDOM_daggerSpawnPositionY, daggerSpawnPosition.position.z), daggerSpawnPosition.rotation);
				gameLogic.playerDaggerRemaining -= 1;
			} 
		}
	}
	
	/* Enable box and timer
	 * */
	
	void delayNextAttack () {
		//	activation call
		logic.TIMER_delayTime = Time.time + logic.delayTime;
		logic.HitBox.enabled = true;
	}
}
