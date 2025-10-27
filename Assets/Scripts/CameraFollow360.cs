using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow360 : MonoBehaviour { // Clase que controla o seguimento da cámara ao xogador con movemento 360 graos

	public Transform player; // Referencia ao transform do xogador
	public float distance = 10; // Distancia da cámara ao xogador
	public float height = 5; // Altura da cámara sobre o xogador
	public Vector3 lookOffset = new Vector3(0,1,0); // Desprazamento para axustar o punto ao que mira a cámara
	float cameraSpeed = 100; // Velocidade de movemento da cámara
	float rotSpeed = 100; // Velocidade de rotación da cámara

	void FixedUpdate () // Actualízase en cada frame de física
	{
		if(player) // Se existe un xogador asignado
		{
			Vector3 lookPosition = player.position + lookOffset; // Calcula a posición á que debe mirar a cámara
			Vector3 relativePos = lookPosition - transform.position; // Calcula a posición relativa entre a cámara e o punto de mira
        	Quaternion rot = Quaternion.LookRotation(relativePos); // Calcula a rotación necesaria para mirar ao xogador
			
			transform.rotation = Quaternion.Slerp(this.transform.rotation, rot, Time.deltaTime * rotSpeed * 0.1f); // Interpola suavemente a rotación da cámara
			
			Vector3 targetPos = player.transform.position + player.transform.up * height - player.transform.forward * distance; // Calcula a posición obxectivo da cámara: detrás e por enriba do xogador
			
			this.transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * cameraSpeed * 0.1f); // Interpola suavemente a posición da cámara cara á posición obxectivo
		}
	}
}
