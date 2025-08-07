using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidade = 5f;
    private Rigidbody2D rb;
    private Vector2 movimento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Entrada do jogador
        movimento.x = Input.GetAxisRaw("Horizontal"); // A/D ou ←/→
        movimento.y = Input.GetAxisRaw("Vertical");   // W/S ou ↑/↓

        // Normaliza para não andar mais rápido na diagonal
        movimento = movimento.normalized;
    }

    void FixedUpdate()
    {
        // Movimento com física
        rb.MovePosition(rb.position + movimento * velocidade * Time.fixedDeltaTime);
    }
}
