using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoints : MonoBehaviour
{
    public float playerHealth;
    public Slider healthFill;
    public float maxHealth;
	
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        healthFill.value = maxHealth;
        playerHealth = maxHealth;
    }

    public void changeHealth(float amount)
    {
        playerHealth += amount;
        //playerHealth = Mathf.Clamp(playerHealth, 0, maxHealth);
        healthFill.value = playerHealth / maxHealth;

        if (playerHealth > 100)
        {
            playerHealth = 100;
        }
        if (playerHealth <= 0)
        {
            // do something here
        }
    }



}
