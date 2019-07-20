using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade;

    public float forcaPulo;

   private bool verificaChao;

    public Transform chaoVerificador;

    public Transform spritePlayer;

    private Animator animador;

    public bool estaNoChao;

    public float movimentacao = 0f;

    private void Start()
    {
        animador = spritePlayer.GetComponent<Animator>();
        animador.SetBool("chao", estaNoChao);
        animador.SetFloat("movimento", movimentacao);
    }


    private void Update()
    {
        Movimentacao();
    }

    void Movimentacao()
    {
        verificaChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Chao"));
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if(Input.GetButtonDown("Jump") && verificaChao)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
        } 
    }
}
