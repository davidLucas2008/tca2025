using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovementTopDownRigidbody : MonoBehaviour
{
    public float followDistance = 10f; // Distância para começar a seguir
    public float stopDistance = 2f;    // Distância mínima para parar
    public float speed = 3f;           // Velocidade do inimigo

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        // Evita rotação no Rigidbody
        rb.freezeRotation = true;
    }

    void FixedUpdate() // Movimento físico
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= followDistance && distance > stopDistance)
        {
            // Calcula direção para o jogador
            Vector2 direction = (player.position - transform.position).normalized;

            // Move com física
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

            // Faz o inimigo olhar para o jogador
            transform.up = direction;
        }
    }
}