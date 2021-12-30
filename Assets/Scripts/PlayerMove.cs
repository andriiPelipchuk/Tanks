using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 5;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 route = new Vector3(horizontal, vertical);

        rigidbody.MovePosition(transform.position + route  * speed * Time.deltaTime);

        Direction();
    }

    private void Direction()
    {
        if(Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, -180);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Crush");
    }
}