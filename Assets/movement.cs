using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Vector3 input;
    private float velocidade = 2.0f;
    private bool correndo = false; 
    private float velocidadeCorrida = 4.0f; 

    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input.Set(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        character.Move(input * velocidade * Time.deltaTime);
        character.Move(Vector3.down * Time.deltaTime);

        //corrida
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            correndo = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            correndo = false;
        }

        if (correndo)
        {
            character.Move(input * velocidadeCorrida * Time.deltaTime);
        }
        else
        {
            character.Move(input * velocidade * Time.deltaTime);
        }

        if (input != Vector3.zero)
        {
            animator.SetBool("andando", true);
            transform.forward = Vector3.Slerp(transform.forward, input, Time.deltaTime * 10);
        }
        else
        {
            animator.SetBool("andando", false);
        }

        if (correndo)
        {
            animator.SetBool("correndoParameter", true);
            transform.forward = Vector3.Slerp(transform.forward, input, Time.deltaTime * 10);
        }
        else
        {
            animator.SetBool("correndoParameter", false);
        }
    }
}
