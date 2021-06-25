using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text HealthText;
    public Text KillText;
    public Text IronText;
    bool isDead = false;
    public static int playerHealth = 100;
    public int EnemyDamage;
    GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {
        //   healthText = GetComponent<TextMeshProUGUI>();
        //   endText = GetComponent<TextMeshProUGUI>();
        HealthText.GetComponent<Text>().text = "Health: " + playerHealth;
        KillText.GetComponent<Text>().text = "Kills: " + PlayerLoco.kills;
        IronText.GetComponent<Text>().text = "Iron: " + PlayerLoco.iron;
    }



    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (isDead == false)
        {
            if (other.gameObject.CompareTag("EnemyArrow"))
            {
                SetHealth(playerHealth - 15);
            }

            if(other.gameObject.CompareTag("Enemy"))
            {
                SetHealth(playerHealth = 10);
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
            FindObjectOfType<GameManager>().EndGame();
        }
        else
        {
            text.text = "Health: " + playerHealth;
        }
    }

    public void SetKill(int kill)
    {
        Text ktext = KillText.GetComponent<Text>();
        PlayerLoco.kills = kill;
        ktext.text = "Kills: " + kill;
    }

    public void SetIron(int irons)
    {
        Text itext = IronText.GetComponent<Text>();
        PlayerLoco.iron = irons;
        itext.text = "Iron: " + irons;
    }

}