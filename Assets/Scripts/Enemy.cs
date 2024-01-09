using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector] public float speed;
    public float health = 100;
    public int reward = 50;
    public GameObject deathEffect;
    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float _amount)
    {
        health -= _amount;

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);

        PlayerStats._money += reward;
        Destroy(gameObject);
    }

    public void Slow(float _slowAmount)
    {
        speed = startSpeed * (1f- _slowAmount);
    }
}
