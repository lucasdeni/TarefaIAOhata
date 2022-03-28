using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    // Criando array e index para os Waypoints
    public Transform[] waypoints;
    int wpIndex = 0;
    // Criando a for�a para mover o objeto
    float speed = 2f;

    //Criando vari�veis para contar o tempo de um waypoint para o outro
    float waitTime = 0.1f;
    float waitCounter = 0f;
    bool waiting = false;

    private void Update()
    {
        if (waiting) // Rotina de espera de um ponto ao outro
        {
            waitCounter += Time.deltaTime;
            if(waitCounter < waitTime)
            {
                return; 
            }
            waiting = false;  // Prossegue pro pr�x ponto
        }
        Transform wp = waypoints[wpIndex];
        if(Vector3.Distance(transform.position, wp.position) < 0.01f) // Objeto chega ao waypoint
        {
            transform.position = wp.position;
            waitCounter = 0f;
            waiting = true; // Espera e confirma o prox waypoint

            wpIndex = (wpIndex + 1) % waypoints.Length; // Define o pr�ximo waypoint    
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, speed * Time.deltaTime); // Objeto se move at� o waypoint
            transform.LookAt(wp.position); // Isso faz o Objeto se adaptar a mudan�a de posi��o do ponto
        }
    }
}
