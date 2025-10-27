using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour { // Clase que xestiona os axentes de navegación da IA

    public GameObject destination; // Obxecto que marca o destino visual
    List<NavMeshAgent> agents = new List<NavMeshAgent>(); // Lista de todos os axentes NavMesh

    void Start() { // Inicialízase ao comezar

        GameObject[] a = GameObject.FindGameObjectsWithTag("AI"); // Busca todos os obxectos coa etiqueta "AI"
        foreach (GameObject go in a) { // Percorre cada obxecto atopado

            agents.Add(go.GetComponent<NavMeshAgent>()); // Engade o compoñente NavMeshAgent á lista
        }
    }


    void Update() { // Actualízase en cada frame

        if (Input.GetMouseButtonDown(0)) { // Se se preme o botón esquerdo do rato

            RaycastHit hit; // Variable para almacenar a información do raio
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) { // Lanza un raio desde a cámara cara á posición do rato

                Vector3 targetPosition = hit.point; // Obtén a posición onde impactou o raio
                destination.transform.position = targetPosition; // Move o marcador visual ao punto de destino
                foreach (NavMeshAgent a in agents) { // Percorre todos os axentes

                    a.SetDestination(hit.point); // Establece o destino de cada axente
                }
            }
        }
    }
}
