
using UnityEngine;

public class key : MonoBehaviour
{
	void OnCollisionEnter()
	{
		FindObjectOfType<GameManager>().OpenDoor();
		Destroy(GameObject.Find("Key"));
	}
}
