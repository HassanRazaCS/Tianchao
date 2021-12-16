using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject shooter;
    public BulletSpawnData[] spawnDatas;
    public int index = 0;
    public bool isRandomAttack;
    public bool spawnAutomatically;
    [SerializeField] private AudioClip sound;
    BulletSpawnData GetSpawnData()
    {
        return spawnDatas[index];
    }
    float timer;
    public string targetTag;
    private Transform target;

    float[] angles;
    void Start()
    {
        timer = GetSpawnData().cooldown;

        try
        {
            target = GameObject.FindGameObjectWithTag(targetTag).transform;
        }
        catch (Exception e)
        {
            target = transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawnAutomatically)
        {
            if (timer <= 0)
            {
                SpawnBullets();
                timer = GetSpawnData().cooldown;
                if (isRandomAttack)
                {
                    index = UnityEngine.Random.Range(0, spawnDatas.Length);
                }
                else
                {
                    index += 1;
                    if (index >= spawnDatas.Length) index = 0;
                }
                angles = new float[GetSpawnData().numberOfBullets];

            }
            timer -= Time.deltaTime;
        }
    }

    // Select a random angle from min to max for each bullet
    public float[] RandomAngles()
    {
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            angles[i] = UnityEngine.Random.Range(GetSpawnData().minAngle, GetSpawnData().maxAngle);
        }
        return angles;

    }

    public float[] AimedAngles()
    {
        float angleRange = GetSpawnData().maxAngle - GetSpawnData().minAngle;
        Vector3 direction = target.position - transform.position;
        float dirAngle = Mathf.Atan2( direction.y, direction.x )  * Mathf.Rad2Deg;
        float aimedMinAngle = dirAngle - angleRange/2;
        float aimedMaxAngle = dirAngle + angleRange/2;

        for (int i = 0; i< GetSpawnData().numberOfBullets; i++)
        {
            var fraction = (float)i / ((float)GetSpawnData().numberOfBullets - 1);
            var difference = aimedMaxAngle - aimedMinAngle;
            var fractionOfDifference = fraction * difference;

            angles[i] = fractionOfDifference + aimedMinAngle;
            //angles[i] = dirAngle;
        }
        return angles;
    }
    
    // This will set random angles evenly distributed between the min and max Angle.
    public float[] DistributedAngles()
    {
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            var fraction = (float)i / ((float)GetSpawnData().numberOfBullets - 1);
            var difference = GetSpawnData().maxAngle - GetSpawnData().minAngle;
            var fractionOfDifference = fraction * difference;
            angles[i] = transform.rotation.eulerAngles.z + fractionOfDifference + GetSpawnData().minAngle;
        }
        //foreach (var r in angles) print(r);
        return angles;
    }
    public GameObject[] SpawnBullets()
    {
        SoundManager.instance.PlaySound(sound);
        angles = new float[GetSpawnData().numberOfBullets];
        if (GetSpawnData().isRandom)
        {
            RandomAngles();
        } else if (GetSpawnData().isAimed)
        {
            AimedAngles();
        } else
        {
            DistributedAngles();
        }

        // Spawn Bullets
        GameObject[] spawnedBullets = new GameObject[GetSpawnData().numberOfBullets];
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            spawnedBullets[i] = BulletManager.GetBulletFromPoolWithType(GetSpawnData().type);
            if (spawnedBullets[i] == null)
            {
                spawnedBullets[i] = Instantiate(GetSpawnData().bulletResource, transform);
                spawnedBullets[i].transform.localPosition = Vector2.zero;
                BulletManager.bullets.Add(spawnedBullets[i]);
            } else
            {
                spawnedBullets[i].transform.SetParent(transform);
                spawnedBullets[i].transform.localPosition = Vector2.zero;
            }
            var b = spawnedBullets[i].GetComponent<Bullet>();
            b.angle = angles[i];
            b.rotation = GetSpawnData().bulletRotation;
            b.rotationRate = GetSpawnData().bulletRotationRate;
            b.speed = GetSpawnData().bulletSpeed;
            b.acceleration = GetSpawnData().bulletAcceleration;
            b.accelRate = GetSpawnData().bulletAccelRate;
            b.velocity = GetSpawnData().bulletVelocity;
            if (!GetSpawnData().isParent) spawnedBullets[i].transform.SetParent(null);
        }
        return spawnedBullets;
    }
}
