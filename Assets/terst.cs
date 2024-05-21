using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terst : MonoBehaviour
{
    // vari�veis do Animator
    private Animator animator;
    private bool andando = false;
    private bool correndoParameter = false;

    // vari�vel que determina a velocidade do player
    public float velocity = 5f;
    public float velocityRun = 7f;
    public float rotation = 180.0f;

    // vari�vel que determina se esta ou n�o tocando o ch�o
    bool isGrounded = false;
    // vari�vel que determina a for�a do pulo
    public float jumpforce = 5.0f;
    // vari�vel que determina a massa do personagem
    public float mass = 5.0f;
    // vari�vel da classe de rigidbody
    private Rigidbody rigidbody;

    void Start()
    {
        // a vari�vel de rigidbody recebe o rigidbody do player
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.mass = mass;

        // obt�m o componente Animator
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // vari�veis que determina as teclas e a dire��o do player
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Verifica se o player est� se movendo para frente ou para os lados
        andando = x != 0f || y != 0f;

        // Verifica se o player est� correndo
        correndoParameter = Input.GetKey(KeyCode.LeftShift) && andando;

        // Atualiza os par�metros de anima��o
        animator.SetBool("andando", andando);
        animator.SetBool("correndoParameter", correndoParameter);

        // Move o personagem
        Vector3 movement = new Vector3(x, 0, y) * (correndoParameter ? velocityRun : velocity) * Time.deltaTime;
        transform.Translate(movement);

        // verifica se o player tem condi��o de pular, sendo elas, pressionar a tecla de pulo e estar no ch�o
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // adiciona uma for�a pra cima no rigidbody do player
            rigidbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // verifica se o player teve contato com o objeto "ground"
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
}