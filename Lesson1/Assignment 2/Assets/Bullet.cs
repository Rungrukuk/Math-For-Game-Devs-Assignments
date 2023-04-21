using UnityEngine;

public class Bullet : MonoBehaviour
{
    private LaserGun laserGun;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform rayStartPos;
    private Vector2 bulletVelocity;
    private Vector2 vectorProjection;
    private RaycastHit2D ray;


    void Start()
    {
        laserGun = GameObject.FindWithTag("Player").GetComponent<LaserGun>();

        bulletVelocity = (laserGun.shootingMousePos - laserGun.transform.position);
        bulletVelocity.Normalize();
        rb.velocity = bulletVelocity * speed;
        transform.rotation = Quaternion.Euler(0, 0, MyFunctions.FindAngle(default,rb.velocity));
        vectorProjection = GetVectorProjection(rayStartPos.position,bulletVelocity);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        transform.rotation = Quaternion.identity;
        bulletVelocity -= (2 * vectorProjection);
        bulletVelocity.Normalize();
        rb.velocity = bulletVelocity * speed;
        float angle = MyFunctions.FindAngle(default, rb.velocity);
        Debug.Log(angle);
        transform.rotation = Quaternion.Euler(0,0,angle);
        vectorProjection = GetVectorProjection(rayStartPos.position,rb.velocity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(default,rb.velocity);
        Gizmos.DrawLine(rayStartPos.position,ray.point);
    }

    private Vector2 GetVectorProjection(Vector3 startPos, Vector2 velocity)
    {
        ray = Physics2D.Raycast(startPos, velocity);
        Debug.Log(ray.collider.name);
        return ray.normal * Vector2.Dot(velocity, ray.normal);
    }
}
