using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour { // Clase que controla o movemento e animacións do xogador

	Rigidbody rb; // Referencia ao compoñente Rigidbody para o movemento físico
    public float speed = 10.0F; // Velocidade de movemento do xogador
    float rotationSpeed = 50.0F; // Velocidade de rotación do xogador
    Animator animator; // Referencia ao compoñente Animator para as animacións
    static public bool dead = false; // Indica se o xogador está morto

    void Start(){ // Inicialízase ao comezar
        rb = this.GetComponent<Rigidbody>(); // Obtén o compoñente Rigidbody
        animator = GetComponentInChildren<Animator>(); // Obtén o Animator dos obxectos fillos
        animator.SetBool("Idling", true); // Activa a animación de reposo inicial
    }
	
	void FixedUpdate () { // Actualízase en cada frame de física
	
        float translation = Input.GetAxis("Vertical") * speed; // Calcula o movemento vertical baseándose na entrada e velocidade
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed; // Calcula a rotación baseándose na entrada horizontal e velocidade
        translation *= Time.deltaTime; // Axusta o movemento ao tempo do frame
        rotation *= Time.deltaTime; // Axusta a rotación ao tempo do frame
        Quaternion turn = Quaternion.Euler(0f,rotation,0f); // Crea un quaternion para aplicar a rotación
        rb.MovePosition(rb.position + this.transform.forward * translation); // Move o xogador cara adiante segundo a súa dirección
        rb.MoveRotation(rb.rotation * turn); // Aplica a rotación ao xogador

        if(translation != 0) // Se hai movemento, desactiva a animación de reposo
        {
            animator.SetBool("Idling", false);
        }
        else // Se non hai movemento, activa a animación de reposo
        {
            animator.SetBool("Idling", true);
        }

        if (dead) // Se o xogador está morto
        {
            animator.SetTrigger("isDead"); // Activa a animación de morte
            this.enabled = false; // Desactiva o script para deter o control
        }


    }
}
