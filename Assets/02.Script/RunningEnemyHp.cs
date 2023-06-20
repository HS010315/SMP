using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningEnemyHp : MonoBehaviour
{
    public int startingHealth = 100;
    private int currentHealth;
    bool isDead;
void Start()
    {
        currentHealth = startingHealth;     // 현재 체력 초기화
    }

    public void TakeDamage(int amount)
    {
        if (isDead)                         // 이미 죽었다면 함수를 더 이상 실행하지 않음
        return;

        currentHealth -= amount;            // 현재 체력 감소

        if (currentHealth <= 0)             // 적의 체력이 0 이하이면 적을 죽임
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        GetComponent<RunningEnemyController>().enabled = false;

        Destroy(gameObject, 2f);
    }
}