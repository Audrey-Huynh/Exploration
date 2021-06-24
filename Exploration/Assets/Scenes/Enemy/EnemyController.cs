using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {
    //insert player at player
    public GameObject player;
    float speed = 4;

    float cooldown = 5;

    float distance = 60;

    public ParticleSystem particleSystem;

    public AudioSource audioSource;

    float sprint = 2;
    float walkRadius = 40;
    float runRadius = 20;


    void Start () {

    }


    void Update () {
        //Looks at player depending on distance, walks and runs in other instances
        transform.LookAt(player.transform);
        if (Vector3.Distance (transform.position, player.transform.position) <= walkRadius) {
            transform.Translate (Vector3.forward * speed * Time.deltaTime);
            }
        if (Vector3.Distance (transform.position, player.transform.position) <= runRadius) {
            transform.Translate (Vector3.forward * speed * sprint * Time.deltaTime);
            audioSource.Play();
            }
        }

    }

