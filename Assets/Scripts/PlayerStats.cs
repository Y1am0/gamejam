using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       //if (Input.GetKeyDown(KeyCode.Space))
       // {
       //     TakeDamage(20);
       // }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Damage Taken! Current Health: " + currentHealth);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }   
    }
}
