using UnityEngine;
using UnityEngine.UI;	
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {room, lollipop_0, axe, lock_0, lollipop_1, room_axe, lock_1, corridor,
						stairs_up, stairs_down, closet, freedom};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.room;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if 	(myState == States.room) 	{room ();}
		else if (myState == States.lollipop_0) 	{lollipop_0 ();}
		else if (myState == States.lock_0) 	{lock_0 ();}
		else if (myState == States.axe)		{axe ();}
		else if (myState == States.lollipop_1)	{lollipop_1 ();}
		else if (myState == States.lock_1)	{lock_1 ();}
		else if (myState == States.room_axe)	{room_axe ();}
		else if (myState == States.corridor)	{corridor ();}
		else if (myState == States.stairs_up)	{stairs_up ();}
		else if (myState == States.stairs_down)	{stairs_down ();}
		else if (myState == States.closet)	{closet ();}
		else if (myState == States.freedom)	{freedom ();}
	}

	void room () {
		text.text = "You're in an unfamiliar room, and you want to get out. " +
					"There's a bloody axe, and a purple lollipop by the bed. " + 
					"The door's locked.\n\n" +
					"Press P to view lollipop, A to view axe and L to view lock.";

		if(Input.GetKeyDown(KeyCode.P)) 	{myState = States.lollipop_0;}
		else if(Input.GetKeyDown(KeyCode.A)) 	{myState = States.axe;}
		else if(Input.GetKeyDown(KeyCode.L))	{myState = States.lock_0;}

	}

	void lollipop_0 () {
		text.text = "Eeew, it's still sticky from a previous use. You weren't " +
					"going to escape with a lollipop anyway, right?\n\n" +
					"Press R to return to looking around in the room.";

		if(Input.GetKeyDown(KeyCode.R)) 	{myState = States.room;}
	}

	void lock_0 () {
		text.text = "The door's locked, but the lock has seen better days... \n\n" +
					"Press R to return to looking around in the room.";
		
		if(Input.GetKeyDown(KeyCode.R)) 	{myState = States.room;}
	}

	void axe () {
		text.text = "It's gross with all the blood and guts on it, " +
					"but maybe it's still worth taking it?\n\n" +
					"Press T to take the axe, or R to return to looking around in the room.";
		
		if(Input.GetKeyDown(KeyCode.T)) 	{myState = States.room_axe;}
		else if(Input.GetKeyDown(KeyCode.R)) 	{myState = States.room;}
	}

	void room_axe () {
		text.text = "You've got the not so mighty axe, what are you going " +
					"to do now?\n\n" +
					"Press L to view the lock, or P to view lollipop.";
		
		if(Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_1;}
		else if(Input.GetKeyDown(KeyCode.D)) 	{myState = States.lollipop_1;}
	}

	void lollipop_1 () {
		text.text = "This lollipop still doesn't seem to be that useful, " +
					"or does it ? ( ͡° ͜ʖ ͡°)\n\n" +
					"Press R to return.";
		
		if(Input.GetKeyDown(KeyCode.R)) 	{myState = States.room_axe;}
	}

	void lock_1 () {
		text.text = "You look at the lock again, and think to yourself: " +
					"maybe I could smash that piece of junk?\n\n" +
					"Press B to break the lock, or R to return.";
		
		if(Input.GetKeyDown(KeyCode.B)) 	{myState = States.corridor;}
		else if(Input.GetKeyDown(KeyCode.R)) 	{myState = States.room_axe;}
	}

	void corridor () {
		text.text = "You entered a dark corridor with a closet and a stairway.\n\n" +
					"Press Up to go upstairs, Down to go downstairs, or C to open the closet.";
		
		if(Input.GetKeyDown(KeyCode.UpArrow)) 		{myState = States.stairs_up;}
		else if(Input.GetKeyDown(KeyCode.DownArrow)) 	{myState = States.stairs_down;}
		else if(Input.GetKeyDown(KeyCode.C)) 		{myState = States.closet;}
	}

	void stairs_up () {
		text.text = "You decided to go upstairs, but Jesús the Janitor knocked you " +
					"out and locked you in the same room you just escaped from!\n\n" +
					"Press Enter to suck it up, and start over.";
		
		if(Input.GetKeyDown(KeyCode.Return)) 	{myState = States.room;}
	}

	void stairs_down () {
		text.text = "You decided to go downstairs, but slipped on a piece of dog turd " +
					"and blacked out. Sometime later you woke up in the room you escaped from! \n\n" +
					"Press Enter to suck it up, and start over.";
		
		if(Input.GetKeyDown(KeyCode.Return)) 	{myState = States.room;}
	}

	void closet () {
		text.text = "You open the closet and see a big red pentagram inside. What is " +
					"this, a portal from DOOM!? Could this be the way out?\n\n" +
					"Press P to enter the portal, or R to return";
		
		if(Input.GetKeyDown(KeyCode.P)) 	{myState = States.freedom;}
		else if(Input.GetKeyDown(KeyCode.R)) 	{myState = States.corridor;}
	}

	void freedom () {
		text.text = "Winner winner chicken dinner! " +
					"You solved this oh-so-difficult game! " +
					"If only you were this successful in real life. \n\n" +
					"Press Enter to start a new game or Escape to exit.";
		
		if(Input.GetKeyDown(KeyCode.Return)) 		{myState = States.room;}
		else if(Input.GetKeyDown(KeyCode.Escape)) 	{Application.Quit();}
	}
}
