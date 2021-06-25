using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSpawner : MonoBehaviour
{

    public GameObject iron;

    public float timespawn;
    private float currenttimespwan;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currenttimespwan > 0)
        {
            currenttimespwan -= Time.deltaTime;
        }
        else
        {
            Spawn();
            currenttimespwan = timespawn;
        }
    }

    public void Spawn()
    {
        Instantiate(iron, transform.position, transform.rotation);
    }

}
