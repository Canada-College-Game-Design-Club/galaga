using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDmanager : MonoBehaviour
{
	public float gameFrameRate;      // holds the average frame rate
	public int gameScore;               // starts at 0 and increments as you score
	public float gameTimer;             // countdown timer
	public Rect HUDdisplay;             // rectangular area to draw frame counter in
	public GUIStyle HUDstyle;           // set the text style of the frame counter
	public bool bWinner;            // display the WINNER text on the HUD

	// Start is called before the first frame update
	void Start()
	{
		HUDdisplay = new Rect(0, 50, 200, 200);
		HUDstyle.alignment = TextAnchor.LowerLeft;
		HUDstyle.fontSize = 30;
		HUDstyle.normal.textColor = new Color(0.0f, 1.0f, 0.0f);  // dark blue solid

		ResetGame();
	}

	// Update is called once per frame
	void Update()
	{
		// continously updates frame rate every frame
		gameFrameRate = Time.frameCount / Time.time;

		// decrement timer
		gameTimer -= Time.deltaTime;

		// check if ESCAPE pressed, quit app
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	// Display HUD values
	private void OnGUI()
	{
		string text = string.Format("FPS: {0:0}\nScore: {1:0}\nTimer: {2:0}", gameFrameRate, gameScore, gameTimer);
		if (bWinner)
		{
			text += "\nWINNER";
		}
		if (IsGameOver())
		{
			text += "\nPress Return to restart";
		}
		GUI.Label(HUDdisplay, text, HUDstyle);
	}

	// Reset game values 
	public void ResetGame()
	{
		gameTimer = 200.0f;      // start with 60 seconds
		gameScore = 0;          // start with no score
		bWinner = false;
	}

	// Returns true of the game timer expires
	public bool IsGameOver()
	{
		if (gameTimer > 0.0f)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	// adds a value to game score
	public void AddScore(int reward)
	{
		gameScore += reward;
	}

	// adjusts the timer +/-
	public void AdjustTimer(float adjustment)
	{
		gameTimer += adjustment;
	}

	// display WINNER in the HUD
	public void Winner()
	{
		bWinner = true;
	}
}