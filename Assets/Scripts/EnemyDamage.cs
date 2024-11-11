using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage: MonoBehaviour
{
    public PlayerStats playerStats;
    public int damage = 10;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStats.TakeDamage(damage);
        }
    }
}
