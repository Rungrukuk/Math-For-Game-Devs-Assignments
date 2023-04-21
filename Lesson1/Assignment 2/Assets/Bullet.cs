using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private LaserGun laserGun;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform rayStartPos;
    private float currentAngle;
    private Vector2 bulletVelocity;
    // private Vector2 hitObjVector;
    // private RaycastHit2D hit;
    
    void Start()
    {
        laserGun = GameObject.FindWithTag("Player").GetComponent<LaserGun>();
        bulletVelocity = (laserGun.shootingMousePos - laserGun.transform.position);
        bulletVelocity.Normalize();
        rb.velocity = bulletVelocity * speed;
        // hit = Physics2D.Raycast(rayStartPos.position,rb.velocity * 200);
        // hitObjVector = new Vector2(Mathf.Sin(hit.transform.rotation.eulerAngles.z * Mathf.PI/180),Mathf.Cos(hit.transform.rotation.eulerAngles.z* Mathf.PI/180));
        // hitObjVector *= hit.point;
        //hitObjVector -= hit.point;
    }
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Quaternion myRotation = other.transform.rotation;
        if (myRotation.eulerAngles.z == 90)
        {
            rb.velocity *= new Vector2(-1, 1);
        }
        else
        {
            rb.velocity *= new Vector2(1, -1);
        }
        
        // float xVelocity = Mathf.Sin(myRotation.eulerAngles.z);
        // float yVelocity = Mathf.Cos(myRotation.eulerAngles.z);
        // if (xVelocity>yVelocity)
        // {
        //     xVelocity *= -1;
        // }
        //
        // if (yVelocity>xVelocity)
        // {
        //     yVelocity *= -1;
        // }
        // rb.velocity *= new Vector2(xVelocity,yVelocity);
        // bulletVelocity -= hitObjVector;
        // bulletVelocity.Normalize();
        // rb.velocity = bulletVelocity * 20;
    }
}
