﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class csUIManager : MonoBehaviour {

	public Canvas uiCanvas;
	public Canvas topUiCanvas;
	private string restartScene;

	public static csUIManager instance = null;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Update () {
		if (SceneManager.GetActiveScene ().name == "00-Intro" || SceneManager.GetActiveScene ().name == "98-PrintScore")
		{
			if (topUiCanvas.enabled == true) 
			{
				topUiCanvas.enabled = false;
			}
		} 
		else 
		{
			topUiCanvas.enabled = true;
		}
	}

	public void Menu_Clicked ()
	{
		uiCanvas.enabled = true;
	}

	public void Resume_Clicked ()
	{
		uiCanvas.enabled = false;
	}

	public void MainMenu_Clicked ()
	{
		uiCanvas.enabled = false;
		SceneManager.LoadScene ("00-Intro");
	}

	public void Exit_Clicked ()
	{
		Application.Quit ();
		Debug.Log ("quit complete");
	}

	public void Restart_Clicked ()
	{
		restartScene = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene (restartScene);
	}

}