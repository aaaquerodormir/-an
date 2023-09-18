//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerJump : MonoBehaviour
//{
//    private Rigidbody2D rb;
//    private BoxCollider2D boxColl2D;

//    [SerializeField] private LayerMask jumpableGround;
//    private float jumpForce; 
//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        boxColl2D = GetComponent<BoxCollider2D>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//    private void FixedUpdate()
//    {
//        if(Input.GetButtonDown("Jump"))
//        {
//            if (IsGrounded())
//                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//        }
//    }
//    private bool IsGrounded()
//    {
//        return Physics2D.BoxCast(boxColl2D.bounds.center, boxColl2D.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
//    }
       
//}
