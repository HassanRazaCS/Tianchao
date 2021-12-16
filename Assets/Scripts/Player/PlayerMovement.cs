using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float baseSpeed;
    private float focusSpeed;
    public GameObject hitbox;
    private float spriteColorA;
    void Start()
    {
        baseSpeed = speed;
        focusSpeed = baseSpeed/2;
        spriteColorA = 0;
    }
    void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = focusSpeed;
            if (spriteColorA < 0.75)
            {
                spriteColorA = spriteColorA + (4 * Time.deltaTime);
            }
            hitbox.transform.Rotate(Vector3.forward * -45 * Time.deltaTime);
        } else
        {
            speed = baseSpeed;
            if (spriteColorA > 0) spriteColorA = spriteColorA - (4 * Time.deltaTime);
        }
        hitbox.GetComponent<SpriteRenderer>().material.color = new Color(hitbox.GetComponent<SpriteRenderer>().material.color.r, hitbox.GetComponent<SpriteRenderer>().material.color.g, hitbox.GetComponent<SpriteRenderer>().material.color.b, spriteColorA);


        Vector3 borderPos = transform.position;
        if (transform.position.x < -9){borderPos.x = -9;}
        else if (transform.position.x > 4){borderPos.x = 4;}
        if (transform.position.y < -5){borderPos.y = -5;}
        else if (transform.position.y > 5){borderPos.y = 5;}
        transform.position = borderPos;
    }
}
