using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidade = 5f;
    private Rigidbody2D rb;
    private Vector2 movimento;
    private Animator anim;

    public GameObject prefabBomba; // arraste o prefab da bomba no Inspector
public Vector2 offsetBomba = Vector2.zero; // opcional: para ajustar a posição do spawn

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Entrada do jogador
        movimento.x = Input.GetAxisRaw("Horizontal"); // A/D ou ←/→
        movimento.y = Input.GetAxisRaw("Vertical");   // W/S ou ↑/↓

        // Normaliza para não andar mais rápido na diagonal
        movimento = movimento.normalized;

        if (Input.GetKeyDown("a"))
        {
            //Debug.Log("A");
            anim.SetBool("isLeft", true);
        }
        else { anim.SetBool("isLeft", false); }
        if (Input.GetKeyDown("d"))
        {
            //Debug.Log("D");
            anim.SetBool("isRight", true);
        }
        else { anim.SetBool("isRight", false); }
        if (Input.GetKeyDown("s"))
        {
            //Debug.Log("S");
            anim.SetBool("isDown", true);
        }
        else { anim.SetBool("isDown", false); }
        if (Input.GetKeyDown("w"))
        {
            //Debug.Log("W");
            anim.SetBool("isUp", true);
        }
        else { anim.SetBool("isUp", false); }
           if (Input.GetKeyDown(KeyCode.Space))
        {
            if (prefabBomba != null)
            {
                Vector2 posicaoSpawn = rb.position + offsetBomba;
                Instantiate(prefabBomba, posicaoSpawn, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("Prefab da bomba não está atribuído no Inspector!");
            }
        }
    }

    void FixedUpdate()
    {
        // Movimento com física
        rb.MovePosition(rb.position + movimento * velocidade * Time.fixedDeltaTime);

    }
}
