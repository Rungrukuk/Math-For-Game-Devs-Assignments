using UnityEngine;

public class Bullet : MonoBehaviour
{
    private LaserGun laserGun;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rayDistance = 50f;
    void Start()
    {
        laserGun = GameObject.FindWithTag("Player").GetComponent<LaserGun>();
        transform.rotation = Quaternion.LookRotation(Vector3.forward,transform.position -laserGun.transform.position);
    }


    void FixedUpdate()
    {
        transform.Translate(new Vector3(0,0.01f * speed,0));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.rotation * new Vector2(0, rayDistance));

    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position,transform.rotation * new Vector2(0,rayDistance));
    }
}
