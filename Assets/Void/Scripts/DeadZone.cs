using UnityEngine;

public class DeadZone : MonoBehaviour 
{
	void OnTriggerEnter()
	{
		VoidGameManager.Instance.LoseLife();
	}
}
