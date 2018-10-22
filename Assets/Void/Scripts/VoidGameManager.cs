using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VoidGameManager : MonoBehaviour 
{
	public static VoidGameManager Instance;

    public int StartingLives;
    public float InnerRingRadius;
    public int InnerRingAsteroidCount;
    public float OuterRingRadius;
    public int OuterRingAsteroidCount;
	public float GameOverResetDelay;
	public float NewLifeResetDelay;

	public Text LivesText;
	public GameObject GameOver;
	public GameObject YouWon;
	public GameObject[] AsteroidPrefabs;
	public GameObject DeathParticles;
	public GameObject DestroyerPrefab;
    public GameObject RingPrefab;

	int currNumAsteroids;
    int currNumLives;
	GameObject destroyer;
    HashSet<int> destroyedAsteroidIds = new HashSet<int>();

	void Awake() 
	{
		if (Instance == null)
        {
			Instance = this;
        }
		else if (Instance != this)
        {
			Destroy(gameObject);
        }
		Setup();
	}
		
	void Setup() 
	{
        Time.timeScale = 1f;
        currNumAsteroids = InnerRingAsteroidCount + OuterRingAsteroidCount;
        currNumLives = StartingLives;
        SpawnPlanet();
        SpawnAsteroids();
	}

	void SpawnPlanet()
	{
        destroyer = Instantiate(DestroyerPrefab, transform.position, Quaternion.identity) as GameObject;
	}

    void SpawnAsteroids()
    {
        GameObject innerRing = Instantiate(RingPrefab, transform.position, Quaternion.identity);
        innerRing.name = "Inner Ring";
        GameObject outerRing = Instantiate(RingPrefab, transform.position, Quaternion.identity);
        outerRing.name = "Outer Ring";

        for (int i = 0; i < OuterRingAsteroidCount; ++i)
        {
            float angle = i * Mathf.PI * 2f / OuterRingAsteroidCount;
            Vector3 position = new Vector3(Mathf.Cos(angle) * OuterRingRadius, Mathf.Sin(angle) * OuterRingRadius, 0);
            Instantiate(AsteroidPrefabs[Random.Range(0, 2)], position, Quaternion.identity, outerRing.transform);
        }

        for (int i = 0; i < InnerRingAsteroidCount; ++i)
        {
            float angle = i * Mathf.PI * 2f / InnerRingAsteroidCount;
            Vector3 position = new Vector3(Mathf.Cos(angle) * InnerRingRadius, Mathf.Sin(angle) * InnerRingRadius, 0);
            Instantiate(AsteroidPrefabs[Random.Range(0, 2)], position, Quaternion.identity, innerRing.transform);
        }
    }

	bool IsGameOver()
	{
		if (currNumAsteroids < 1 || currNumLives < 1)
		{
            if (currNumAsteroids < 1)
            {
			    GameOver.SetActive(false);
			    YouWon.SetActive(true);
            }
            else
            {
			    YouWon.SetActive(false);
			    GameOver.SetActive(true);
            }
            LivesText.gameObject.SetActive(false);
            LivesText.transform.parent.gameObject.SetActive(false);
            Time.timeScale = 0.25f;
            Invoke("ResetGame", GameOverResetDelay);
            return true;
		}
        return false;
	}

	public void LoseLife()
	{
		--currNumLives;
        LivesText.text = LivesText.text.Substring(0, LivesText.text.Length - 2);
		Instantiate(DeathParticles, destroyer.transform.position, Quaternion.identity);
		Destroy(destroyer);
        if (IsGameOver())
        {
            return;
        }

		Invoke("SpawnPlanet", NewLifeResetDelay);
	}

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	public void DestroyAsteroid(int asteroidId)
	{
        if (destroyedAsteroidIds.Contains(asteroidId))
        {
            return;
        }
        destroyedAsteroidIds.Add(asteroidId);
		--currNumAsteroids;
        IsGameOver();
	}
}
