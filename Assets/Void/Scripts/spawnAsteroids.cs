using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnAsteroids : MonoBehaviour 
{
	public int lives = 3;
	public int asteroids = 32;
	public Text livesText;
	public float resetDelay = 1f;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject asteroidPrefab;
	public GameObject deathParticles;
	public GameObject planetPrefab;

	public static spawnAsteroids instance = null;

	private GameObject clonePlanet;

	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		Setup();
	}
		
	public void Setup () 
	{
		clonePlanet = Instantiate (planetPrefab, transform.position, Quaternion.identity) as GameObject;

		float radius = 9f;
		for (int i = 0; i < 20; i++)
		{
			float angle = i * Mathf.PI*2f / 20;
			Vector3 newPos = new Vector3(Mathf.Cos(angle)*radius, Mathf.Sin(angle)*radius, 0);
			Instantiate(asteroidPrefab, newPos, Quaternion.identity);
		}
		radius = 6.5f;
		for (int i = 0; i < 12; i++)
		{
			float angle = i * Mathf.PI*2f / 12;
			Vector3 newPos = new Vector3(Mathf.Cos(angle)*radius, Mathf.Sin(angle)*radius, 0);
			Instantiate(asteroidPrefab, newPos, Quaternion.identity);
		}
	}

	void CheckGameOver()
	{
		if (asteroids < 1)
		{
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}

		if (lives < 1)
		{
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}

	}

	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate(deathParticles, clonePlanet.transform.position, Quaternion.identity);
		Destroy(clonePlanet);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver();
	}

	void SetupPaddle()
	{
		clonePlanet = Instantiate(planetPrefab, transform.position, Quaternion.identity) as GameObject;
	}

	public void DestroyAsteroids()
	{
		asteroids--;
		CheckGameOver();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}