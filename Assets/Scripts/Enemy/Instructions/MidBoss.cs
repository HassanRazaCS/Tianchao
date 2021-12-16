using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// WHERE WE WILL MANUALLY CONTROL THE BULLET SPAWNER
public class MidBoss : MonoBehaviour
{
    public BulletSpawner bulletSpawner;
    private GameObject shooter;
    public GameObject cutscene;
    private float startTime;

    private bool[] tasks = new bool[1000000];
    private bool[] repeatedTasks = new bool[1000000];

    private bool turn;
    private bool startCutscene;

    private void Start()
    {
        Time.fixedDeltaTime = 0.001f;
        shooter = bulletSpawner.transform.parent.gameObject;
        startTime = Time.timeSinceLevelLoad;;
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < 1000; i += 1)
        {
            if (TimeManager.ifTimeIs(startTime+1+i/1000f, ref repeatedTasks[i]))
            {
                shooter.transform.position = Vector3.MoveTowards(shooter.transform.position, new Vector3 (-2.5f, 2f, 0f), 10*Time.fixedDeltaTime);
            }
        }
        if (TimeManager.ifTimeIs(startTime+1f, ref tasks[2]))
        {
            shooter.transform.position = Vector3.MoveTowards(new Vector3 (-11.5f, 5.5f, 0f), new Vector3 (-2.5f, 2f, 0f), 5);
        }

        for (int i = 0; i < 20; i += 1)
        {
            if (TimeManager.ifTimeIs(startTime+5+i/4f, ref repeatedTasks[i]))
            {
                if (i<5) bulletSpawner.index = 0;
                else bulletSpawner.index = 1;
                bulletSpawner.SpawnBullets();
            }
        }
        for (int i = 0; i < 2500; i++)
        {
            if (TimeManager.ifTimeIs(startTime+5+i/1000f, ref turn))
            {
                bulletSpawner.transform.Rotate(0f, 0f, 0.1f, Space.Self);
            }
        }

        if (TimeManager.ifTimeIs(startTime+11.5f, ref tasks[2]))
        {
            bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, 0);
            bulletSpawner.index = 1;
            bulletSpawner.SpawnBullets();
        }
        if (TimeManager.ifTimeIs(startTime+12f, ref tasks[3]))
        {
            bulletSpawner.index = 1;
            bulletSpawner.SpawnBullets();
        }
        if (TimeManager.ifTimeIs(startTime+13f, ref tasks[4]))
        {
            bulletSpawner.index = 2;
            bulletSpawner.SpawnBullets();
        }
        if (TimeManager.ifTimeIs(startTime+15f, ref tasks[5]))
        {
            bulletSpawner.index = 3;
            bulletSpawner.SpawnBullets();
        }
        for (int i = 0; i < 50; i += 1)
        {
            if (TimeManager.ifTimeIs(startTime+15+i/10f, ref repeatedTasks[25+i]))
            {
                bulletSpawner.index = 4;
                bulletSpawner.SpawnBullets();
            }
        }
        for (int i = 0; i < 10; i += 1)
        {
            if (TimeManager.ifTimeIs(startTime+17+i/2f, ref repeatedTasks[75+i]))
            {
                bulletSpawner.index = 5;
                bulletSpawner.SpawnBullets();
            }
        }
        for (int i = 0; i < 10; i += 1)
        {
            if (TimeManager.ifTimeIs(startTime+17+i/2f, ref repeatedTasks[75+i]))
            {
                bulletSpawner.index = 5;
                bulletSpawner.SpawnBullets();
            }
        }
        for (int i = 0; i < 115; i += 1)
        {
            if (TimeManager.ifTimeIs(startTime+20+i/25f, ref repeatedTasks[85+i]))
            {
                bulletSpawner.index = 6;
                bulletSpawner.SpawnBullets();
            }
        }
        for (int i = 0; i < 1000; i += 1)
        {
            if (TimeManager.ifTimeIs(startTime+25+i/1000f, ref repeatedTasks[i]))
            {
                shooter.transform.position = Vector3.MoveTowards(shooter.transform.position, new Vector3 (3f, 0f, 0f), 10*Time.fixedDeltaTime);
            }
        }
        if (TimeManager.ifTimeIs(startTime+27f, ref tasks[1]))
        {
            
            for (int i = 0; i < 5; i++)
            {
                bulletSpawner.index = 6;
                bulletSpawner.SpawnBullets();
                bulletSpawner.index = 2;
                bulletSpawner.SpawnBullets();
                bulletSpawner.transform.Rotate(0f, 0f, 75f, Space.Self);
                bulletSpawner.SpawnBullets();
                bulletSpawner.transform.Rotate(0f, 0f, -75f, Space.Self);
            }
        }

        if (TimeManager.ifTimeIs(startTime+45f, ref startCutscene))
        {
            cutscene.SetActive(true);
        }
        
    }
}
