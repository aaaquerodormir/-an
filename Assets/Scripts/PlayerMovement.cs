using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    float jumptime;
    private float Move;
    public Animator anima;
    public Rigidbody2D rb;
    public ParticleSystem fire;
    public bool isJumping;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        anima.SetFloat("Velocity", Mathf.Abs(Move));

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        RaycastHit2D hit;

        Reverser();

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down);
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            anima.SetFloat("Height", hit.distance);
            JumpRoutine(hit);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }

    void Reverser()
    {
        if (Move > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Move < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void JumpRoutine(RaycastHit2D hit)
    {
        // Verifica a distância do chão e aplica uma força de pulo se necessário.
        if (hit.distance < 0.1f)
        {
            jumptime = 3;
        }

        if (isJumping)
        {
            jumptime = Mathf.Lerp(jumptime, 0, Time.fixedDeltaTime * 10);
            rb.AddForce(Vector2.up * jumptime, ForceMode2D.Impulse);
        }
    }
}
