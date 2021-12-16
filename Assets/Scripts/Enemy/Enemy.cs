using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startHp;
    int hp;
    [SerializeField] private AudioClip deathSound;

    void Start()
    {
        hp = startHp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            SoundManager.instance.PlaySound(deathSound);
            hp -= 1;
            Debug.Log("Enemy HP: "+hp);
            if (hp<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
