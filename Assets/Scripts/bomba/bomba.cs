using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float tempoParaExplodir = 3f; // Tempo até explodir
    private Animator animator;
    private bool jaExplodiu = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        // Ativa a animação de "Parado" automaticamente ao iniciar (caso necessário)
        animator.Play("Parado");

        // Chama a explosão depois do tempo definido
        Invoke(nameof(Explodir), tempoParaExplodir);
    }

    void Explodir()
    {
        if (jaExplodiu) return;

        jaExplodiu = true;

        // Ativa a animação de explosão ao mudar o parâmetro "Explodiu" no Animator
        animator.SetBool("Explodiu", true);

        // Desativa colisão durante a explosão
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

        // Espera a animação acabar antes de destruir o objeto
        float duracaoAnimacao = GetAnimationLength("Explosao");
        Destroy(gameObject, duracaoAnimacao);
    }

    // Função que retorna o tempo da animação pelo nome
    float GetAnimationLength(string nomeAnimacao)
    {
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        foreach (var clip in ac.animationClips)
        {
            if (clip.name == nomeAnimacao)
                return clip.length;
        }
        return 1f; // Tempo padrão
    }
}
