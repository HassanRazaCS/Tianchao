using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 velocity;
    public float angle;
    public float rotation;
    public float rotationRate;
    public float speed;
    public float acceleration;
    public float accelRate;

    public string type;
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.Translate(velocity * speed * Time.deltaTime);
        angle += rotation * Time.deltaTime;
        rotation += rotationRate * Time.deltaTime;
        speed += acceleration * Time.deltaTime;
        acceleration += accelRate * Time.deltaTime;
        
        if (transform.position.x <= -10||transform.position.x >= 5||transform.position.y <= -5.5||transform.position.y >= 5.5) gameObject.SetActive(false);
    }
}
