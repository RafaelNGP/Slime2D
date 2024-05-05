using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameControl control;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que colidiu tem a tag "Attack"
        if (collision.gameObject.tag == "Attack")
        {
            // Chama o método para retirar vida
            TakeDamage(25);
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        // Reduz a vida do inimigo
        health -= damage;

        // Verifica se a vida do inimigo chegou a 0
        if (health <= 0)
        {
            Die(); // Chama o método para "matar" o inimigo
        }
    }

    void Die()
    {
        // Destroi o objeto do inimigo
        control.EnemyKilled();
        Destroy(gameObject);
    }
}
