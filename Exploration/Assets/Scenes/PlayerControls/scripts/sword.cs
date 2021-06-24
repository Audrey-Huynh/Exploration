using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour 
{ 

    public static int kills = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            Debug.Log("Kills: " + ++kills);
        }
    }

}
