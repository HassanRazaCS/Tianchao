using UnityEngine;
using System.Collections.Generic;
public class BulletManager : MonoBehaviour

                                                    //NOTE TO SELF: THINK OF A WAY TO TURN THIS INTO A QUEUE
{
    public static List<GameObject> bullets;
    private void Start()
    {
        bullets = new List<GameObject>();
    }
    public static GameObject GetBulletFromPool()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].active)
            {
                var b = bullets[i].GetComponent<Bullet>();
                bullets[i].SetActive(true);
                return bullets[i];
            }
        }
        return null;
    }
    public static GameObject GetBulletFromPoolWithType(string type)
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i] != null)
            {
                if (!bullets[i].active && bullets[i].GetComponent<Bullet>().type == type)
                {
                    var b = bullets[i].GetComponent<Bullet>();
                    bullets[i].SetActive(true);
                    return bullets[i];
                }
            }
            
        }
        return null;
    }
}
