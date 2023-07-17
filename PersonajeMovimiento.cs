using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PersonajeMovimiento : MonoBehaviour
{
    public float velocidadCorrer;
    public Animator animator;
    private SpriteRenderer spritePlayer;
    private int vidaPersonaje = 3;
    private Sonidos sound;

    [SerializeField] UIManager uIManager;

    Rigidbody2D rb2D;

    public Button btnarriba, btnabajo, btnizquierda, btnderecha, btnAtaca;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spritePlayer = GetComponentInChildren<SpriteRenderer>();
        sound = FindObjectOfType<Sonidos>();
    }

    public void irDerecha()
    {
        rb2D.velocity = new Vector2(velocidadCorrer, rb2D.velocity.y);
        animator.SetFloat("CaminarDerecha", Mathf.Abs(rb2D.velocity.magnitude));

        if(velocidadCorrer > 0)
        {
            spritePlayer.flipX = false;
        }
        else if(velocidadCorrer < 0)
        {
            spritePlayer.flipX = true;
        }
    }

    public void irIzquierda()
    {
        rb2D.velocity = new Vector2(-velocidadCorrer, rb2D.velocity.y);
        animator.SetFloat("CaminarIzquierda", Mathf.Abs(rb2D.velocity.magnitude));

        if(velocidadCorrer > 0)
        {
            spritePlayer.flipX = false;
        }
        else if(velocidadCorrer < 0)
        {
            spritePlayer.flipX = true;
        }
    }

    public void irArriba()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, velocidadCorrer);
        animator.SetFloat("CaminaArriba", Mathf.Abs(rb2D.velocity.magnitude));

        if(velocidadCorrer > 0)
        {
            spritePlayer.flipX = false;
        }
        else if(velocidadCorrer < 0)
        {
            spritePlayer.flipX = true;
        }
    }

    public void irAbajo()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, -velocidadCorrer);
        animator.SetFloat("CaminarAbajo", Mathf.Abs(rb2D.velocity.magnitude));

        if(velocidadCorrer > 0)
        {
            spritePlayer.flipX = false;
        }
        else if(velocidadCorrer < 0)
        {
            spritePlayer.flipX = true;
        }
    }

    public void Ataca()
    {
        if(velocidadCorrer > 0)
        {
            sound.SeleccionAudio(0, 0.5f);
            animator.SetTrigger("Atacar");
        }
    }

    public void StopMoving()
    {
        rb2D.velocity = Vector2.zero;
        animator.SetFloat("CaminaArriba", 0f);
        animator.SetFloat("CaminarAbajo", 0f);
        animator.SetFloat("CaminarIzquierda", 0f);
        animator.SetFloat("CaminarDerecha", 0f); 
    }

    public void CausarHerida()
    {
        if (vidaPersonaje > 0)
        {
            vidaPersonaje --;
            uIManager.RestarCorazones(vidaPersonaje);

            if (vidaPersonaje == 0)
            {
                animator.SetTrigger("Muerte");
                Invoke(nameof(Morir), 1f);
            }
        }
    }

    private void Morir()
    {
        Destroy(this.gameObject);
    }

}
