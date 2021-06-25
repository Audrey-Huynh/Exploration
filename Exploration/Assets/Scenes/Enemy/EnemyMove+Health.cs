using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    //insert player below
    public GameObject player;
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

    }
    void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Arrow"))
		{
			health = health - 25;
			Debug.Log(health);
		}

		if (other.gameObject.CompareTag("Player"))
		{
			health = health - 20;
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


