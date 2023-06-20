using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
        void OnCollisionEnter(Collision collision)
    {
        EnemyHp enemy = collision.gameObject.GetComponent<EnemyHp>();
            if (enemy != null)
            {
                enemy.TakeDamage(10);
            }
        RunningEnemyHp runningenemy = collision.gameObject.GetComponent<RunningEnemyHp>();
            if (runningenemy != null)
            {
                runningenemy.TakeDamage(10);
            }
    }
}
