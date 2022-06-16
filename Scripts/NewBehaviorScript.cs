using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float speed = 5 ;
    private Rigidbody2D body;
    private Animator anima;
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.X))
            Jump();

        anima.SetBool("run", horizontalInput != 0);
        anima.SetBool("grounded", grounded);
    }
      private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anima.SetTrigger("jump");
        grounded = false;
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

}

