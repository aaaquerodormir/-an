    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Animator anima; // Referência ao Animator do personagem.
    private Rigidbody2D rdb; // Referência ao Rigidbody2D do personagem.
    private float xmov; // Variável para guardar o movimento horizontal.
    private float jumpState = 0f; // Variável para controlar o estado do pulo.
    public bool temChave;

    [SerializeField] private int speed = 5; // Velocidade do personagem.
    [SerializeField] private float jumpForce = 8f; // Força do pulo.

    // Crie uma variável para representar a camada das plataformas.
    [SerializeField] private LayerMask platformLayer;

    private void Start()
    {
        temChave = false;
        rdb = GetComponent<Rigidbody2D>(); // Obter a referência ao Rigidbody2D no início.
    }

    private void Update()
    {
        // Captura o movimento horizontal do jogador.
        xmov = Input.GetAxis("Horizontal");

        // Verifica se o botão de pulo foi pressionado.
        if (Input.GetButtonDown("Jump"))
        {
            // Verifica se o jogador está em contato com a camada das plataformas ou no ar antes de permitir o pulo.
            if (IsGrounded() || Mathf.Abs(rdb.velocity.y) < 0.01f)
            {
                rdb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpState = 1f; // Inicia o pulo.
            }
        }
        else
        {
            jumpState = 0f; // Define jumpState como 0 quando o botão de pulo não está pressionado.
        }
    }

    private void FixedUpdate()
    {
        Reverser(); // Chama a função que inverte o personagem.
        anima.SetFloat("Velocity", Mathf.Abs(rdb.velocity.x)); // Define a velocidade no Animator.
        anima.SetFloat("Height", jumpState); // Define o estado do pulo no Animator.

        // Adiciona uma força para mover o personagem.
        rdb.velocity = new Vector2(xmov * speed, rdb.velocity.y);
    }

    // Verifica se o jogador está em contato com a camada das plataformas usando raycast.
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, platformLayer);

        return hit.collider != null;
    }

    // Função para inverter a direção do personagem (visual).
    private void Reverser()
    {
        if (rdb.velocity.x > 0.1f) transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (rdb.velocity.x < -0.1f) transform.rotation = Quaternion.Euler(0, 180, 0);
    }


}
