using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text HealthText;
    bool isDead = false;
    public int playerHealth;
    public int EnemyDamage;
    GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {
        //   healthText = GetComponent<TextMeshProUGUI>();
        //   endText = GetComponent<TextMeshProUGUI>();
        HealthText.GetComponent<Text>().text = "Health: " + playerHealth;
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
                HealthText.GetComponent<Text>().text = "Health: " + playerHealth;
                Debug.Log("Health: " + playerHealth);

                if (playerHealth <= 0)
                {
                    //            endText.SetText("Game Over!");
                    HealthText.GetComponent<Text>().text = "Game Over!";
                    Debug.Log("Game Over!");
                    isDead = true;
                }
            }
        }
    }
}