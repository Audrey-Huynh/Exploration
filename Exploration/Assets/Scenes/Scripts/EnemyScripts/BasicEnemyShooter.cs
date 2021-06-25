using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 10f;
    public float downwardsPull = 5f;


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.down * downwardsPull * Time.deltaTime);
        Destroy(this.gameObject, lifetime);
    }
}