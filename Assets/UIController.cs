using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public float bulletsFired = 0;
    public float enemiesHit = 0;

    public void updateBulletsFired()
    {
        bulletsFired++;
    }

    public void updateEnemiesHit()
    {
        enemiesHit++;
    }

    void Update()
    {
        TMPro.TextMeshProUGUI accuracy = GameObject.Find("aimAccuracy").GetComponent<TMPro.TextMeshProUGUI>();

        if (enemiesHit > bulletsFired)
        {
            enemiesHit = bulletsFired;
        }

        accuracy.text = "Accuracy: " + ((enemiesHit / bulletsFired) * 100) + "%";


    }
}
