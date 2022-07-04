using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float speed = 5 ;
    [SerializeField] private LayerMask groundlayer;
    private Rigidbody2D body;
    private Animator anima;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        boxCollider=GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.X) && isGrounded())
            Jump();

        anima.SetBool("run", horizontalInput != 0);
        anima.SetBool("grounded", isGrounded());
    }
      private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anima.SetTrigger("jump");

    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundlayer);
        return raycastHit.collider !=null;
    }
}

