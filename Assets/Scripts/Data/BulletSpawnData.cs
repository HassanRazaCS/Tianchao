using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BulletSpawnData", order = 1)]
public class BulletSpawnData : ScriptableObject
{
    public GameObject bulletResource;
    public float minAngle;
    public float maxAngle;
    public int numberOfBullets;
    public bool isRandom;
    public bool isAimed;
    public bool isParent = true;
    public float cooldown;
    public float bulletRotation;
    public float bulletRotationRate;
    public float bulletSpeed;
    public float bulletAcceleration;
    public float bulletAccelRate;
    public Vector2 bulletVelocity;
    public string type;
}
