using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    bool isDead = false;
    public int playerHealth;
    public int enemyDamage;
    public GameObject Player;
    TextMeshProUGUI healthText;
    TextMeshProUGUI endText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
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
                playerHealth = playerHealth - enemyDamage;
                healthText.SetText("Health: " + playerHealth);
                Debug.Log(playerHealth);

                if (playerHealth <= 0)
                {
                    isDead = true;
                    endText.SetText("Game Over!");
                    Debug.Log("Game Over!");
                }
            }
        }
    }
}