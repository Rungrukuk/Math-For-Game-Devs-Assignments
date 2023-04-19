
using UnityEngine;

public class Movenet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float movementSpeed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal")>0)
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal")<0)
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }
}
