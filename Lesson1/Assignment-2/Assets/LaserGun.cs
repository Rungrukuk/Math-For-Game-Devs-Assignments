using UnityEngine;


public class LaserGun : MonoBehaviour
{
    private Vector3 mousePosition;
    private float dotProduct;
    private float angle;
    [HideInInspector]
    public Vector3 shootingMousePos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] Transform shootingPos;
    [SerializeField] private GameObject bullets;
    private float hypotenuse;

    // Update is called once per frame
    void Update()
    {
        if (Camera.main != null) mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.Euler(0, 0, MyFunctions.FindAngle(transform.position,mousePosition));
        if (Input.GetMouseButtonDown(0))
        {

            shootingMousePos = mousePosition;
            var bullet = Instantiate(bulletPrefab, shootingPos);
            bullet.transform.parent = bullets.transform;
        }
        
    }
}
