using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed = 10f;
    public float gravity = 9.81f; // Aceleração da gravidade
    private Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o collider que entrou em contato é o do jogador
        if (other.CompareTag("mano"))
        {
            // Destroi o jogador
            Destroy(other.gameObject);
        }
    }
    void Start()
    {

        rb = GetComponent<Rigidbody>(); // Obtém o componente Rigidbody do objeto
        rb.velocity = transform.forward * speed; // Aplica velocidade inicial ao objeto
    }
    void FixedUpdate()
    {
        // Aplica a força da gravidade ao objeto
        rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }
}