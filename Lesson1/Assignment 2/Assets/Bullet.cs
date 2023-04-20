using UnityEngine;

public class Bullet : MonoBehaviour
{
    private LaserGun laserGun;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody2D rb;
    private float currentAngle;
    private Vector2 bulletVelocity;
    
    void Start()
    {
        laserGun = GameObject.FindWithTag("Player").GetComponent<LaserGun>();
        bulletVelocity = (laserGun.shootingMousePos - laserGun.transform.position);
        bulletVelocity.Normalize();
        rb.velocity = bulletVelocity * speed;
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
    }
}
