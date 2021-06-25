using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //insert player below
    public GameObject player;
    PlayerHealth playerHealth;
    float speed = 4;
    float radius = 10;
    float runRadius = 5;
    float runSpeed = 5;
    float health = 50;
    void Start () 
    {

    }
    void Update () 
    {
        //basic lookat player
        transform.LookAt(player.transform);
        if (Vector3.Distance (transform.position, player.transform.position) <= radius) 
        {
            //basic walk towards player
          transform.Translate (Vector3.forward * speed * Time.deltaTime);  
        }
        if (Vector3.Distance (transform.position, player.transform.position) <= runRadius) 
        {
            //basic run towards player
            transform.Translate (Vector3.forward * speed * runSpeed * Time.deltaTime); 
        }

        if (health <= 0)
        {
            ++PlayerLoco.kills;
            playerHealth.SetKill(PlayerLoco.kills);
        }

    }
    void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Arrow"))
		{
			health = health - 25;
			Debug.Log(health);
		}

		if (other.gameObject.CompareTag("sword"))
		{
<<<<<<< Updated upstream:Exploration/Assets/Scenes/Enemy/EnemyMove+Health.cs
			health = health - 25;
=======
			health = health - 20;
>>>>>>> Stashed changes:Exploration/Assets/Scenes/Enemy/EnemyMovement.cs
			transform.Translate(0, 0, (float)-0.5);
			Debug.Log(health);
		}

		if (other.gameObject.CompareTag("Bullet"))
		{
			health = health - 20;
			Debug.Log(health);
		}
	}
}



<<<<<<< Updated upstream:Exploration/Assets/Scenes/Enemy/EnemyMove+Health.cs
=======

>>>>>>> Stashed changes:Exploration/Assets/Scenes/Enemy/EnemyMovement.cs

