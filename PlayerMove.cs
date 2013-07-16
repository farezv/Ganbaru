using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	
	public static int isLeft = 0;
	public PlayerLogic logic;
	public GameLogic gameLogic;
	// Use this for initialization
	void Start () {
	
	}
	
	/* Update is called once per frame
	 * When the left (right) arrow key is pressed,
	 *
	 * 1) the player faces left (right)
	 * 2) disables the hitbox so the wrong attack, top attack for instance, isn't matched with enemy attacking top
	 *
	 * */
	
	void Update () {
		if(gameLogic.gameState == 0)
		{
		if (Input.GetKeyDown(KeyCode.RightArrow) && isLeft == 1) { // Face right
			this.transform.Rotate(Vector3.up, 180);
			logic.HitBox.enabled = false;
			logic.TIMER_delayTime = Time.time;
			isLeft = 0;
			
		} else 
			
		if (Input.GetKeyDown(KeyCode.LeftArrow) && isLeft == 0) { // Face left
			this.transform.Rotate(Vector3.up, 180);
			logic.HitBox.enabled = false;
			logic.TIMER_delayTime = Time.time;
			isLeft = 1;
			
		}
		}
	}
}
