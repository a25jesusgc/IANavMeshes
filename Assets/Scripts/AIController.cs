using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour { // Clase que controla o comportamento básico da IA

    public NavMeshAgent agent; // Referencia ao compoñente NavMeshAgent para a navegación
    public GameObject target; // Obxecto obxectivo ao que se dirixe a IA
    Animator anim; // Referencia ao compoñente Animator para as animacións

    void Start() { // Inicialízase ao comezar

        agent = GetComponent<NavMeshAgent>(); // Obtén o compoñente NavMeshAgent
        anim = GetComponent<Animator>(); // Obtén o compoñente Animator
    }

    void Update() { // Actualízase en cada frame

        agent.SetDestination(target.transform.position); // Establece o destino ao obxectivo
        if (agent.remainingDistance < 2.0f) { // Se a distancia restante é menor de 2 unidades

            anim.SetBool("isMoving", false); // Desactiva a animación de movemento
        } else { // Se aínda está lonxe do obxectivo

            anim.SetBool("isMoving", true); // Activa a animación de movemento
        }
    }
}
