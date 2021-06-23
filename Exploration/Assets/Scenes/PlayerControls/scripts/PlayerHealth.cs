using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    TextMeshProUGUI healthText;
    TextMeshProUGUI endText;
    bool isDead = false;
    public static int playerHealth = 10;
    public static int EnemyDamage;
    public GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {
     //   healthText = GetComponent<TextMeshProUGUI>();
     //   endText = GetComponent<TextMeshProUGUI>();
    }



    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (isDead == false)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                playerHealth = playerHealth - EnemyDamage;
        //        healthText.SetText("Health: " + playerHealth);
                Debug.Log("Health: " + playerHealth);

                if (playerHealth <= 0)
                {
        //            endText.SetText("Game Over!");
                    Debug.Log("Game Over!");
                    isDead = true;
                }
            }
        }
    }
}