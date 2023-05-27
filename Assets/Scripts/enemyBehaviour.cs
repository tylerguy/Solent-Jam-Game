using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyBehaviour : MonoBehaviour
{
    public float health = 100f;
    // Start is called before the first frame update
    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // if enemy collides with bullet, take damage
        if (collision.gameObject.tag == "Bullet")
        {
            takeDamage(10);
            GameObject.Find("Canvas").GetComponent<UIController>().updateEnemiesHit();
            Destroy(collision.gameObject);
        }



    }
}
