using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int startLives;
    int lives;
    public Vector3 spawnPoint;
    public float bulletCooldown;
    float bulletTimer;
    public int score;
    public int startPower;
    public int power;
    [SerializeField] private AudioClip deathSound;

    void Start()
    {
        lives = startLives;
        spawnPoint = transform.position;
        score = 0;
        power = startPower;
    }
    void Update()
    {
        bulletTimer -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet" && bulletTimer <= 0)
        {
            SoundManager.instance.PlaySound(deathSound);
            lives -= 1;
            Debug.Log("Lives: "+lives);
            bulletTimer = bulletCooldown;
            transform.position = spawnPoint;
            if (lives<=0)
            {
                FindObjectOfType<GameOver>().EndGame();
            }
        }
    }
}
