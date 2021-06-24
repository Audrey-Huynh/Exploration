using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text HealthText;
    bool isDead = false;
    public static int playerHealth = 10;
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
                SetHealth(playerHealth - EnemyDamage);
            }
        }
    }

    public void SetHealth(int health)
    {
        Text text = HealthText.GetComponent<Text>();
        playerHealth = health;
        if (playerHealth <= 0)
        {
            isDead = true;
            text.text = "Game Over!";
        }
        else
        {
            text.text = "Health: " + playerHealth;
        }
    }

}