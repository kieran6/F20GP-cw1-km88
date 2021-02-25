using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
	
	NavMeshAgent agent;
	GameObject player;
	GameManager gm;
	bool chasing;
	
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.Find("Player");
		agent = GetComponent<NavMeshAgent>();
		agent.destination = player.transform.position;
        agent.speed = 2.5f;
		gm = FindObjectOfType<GameManager>();
		chasing = false;
		agent.isStopped = true;
    }

    void FixedUpdate()
    {
        agent.destination = player.transform.position;
		if((agent.remainingDistance < 6 && gm.enemiesChasing < 3) && !chasing)
		{
			chasing = true;
			gm.enemiesChasing++;
			agent.isStopped = false;
		}
		if(agent.remainingDistance >= 6 && chasing)
		{
			chasing = false;
			gm.enemiesChasing--;
			agent.isStopped = true;
		}
    }
	
	void OnCollisionEnter(Collision col)
	{
		if (col.collider.gameObject.tag == "Player")
		{
			FindObjectOfType<GameManager>().LoseLife();
			Defeated();
		}
		
		if (col.collider.gameObject.tag == "Sword")
		{
			Defeated();
		}
	}
	
	public void Defeated()
	{
		Destroy(this.gameObject);
		if (chasing)
		{
			gm.enemiesChasing--;
		}
	}
}
