using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	
	private bool gameOver = false;
	private int lives = 3;
	public int enemiesChasing = 0;
	
	public GameObject winScreen;
	public GameObject loseScreen;
	
	public void EndGame()
	{
		if (gameOver == false)
		{
			gameOver = true;
			loseScreen.SetActive(true);
		}
	}
	
	public void WinGame()
	{
		if (gameOver == false)
		{
			gameOver = true;
			winScreen.SetActive(true);
		}
	}
	
	public void OpenDoor()
	{
		GameObject door = GameObject.Find("Door");
		Destroy(door);
	}
	
	//reduce lives by 1 and reset player position
	public void LoseLife()
	{
		lives -= 1;
		GameObject player = GameObject.Find("Player");
		player.transform.position = new Vector3(0, 0.3f, 0);
		if (lives == 0)
		{
			EndGame();
		}
	}
}
