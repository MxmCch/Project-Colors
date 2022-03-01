using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHeadReaction : MonoBehaviour
{
    Coroutine turnHead;
    Coroutine returnHead;
    
    Quaternion prevRotation;
    Vector3 prevDirection;
    bool isTriggered;
    GameObject player;
    float rotationSpeed = 1.8f;

    private void Awake() 
    {
        prevDirection = transform.forward;
        prevRotation = Quaternion.LookRotation(prevDirection);
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            Vector3 toDirection = player.transform.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(toDirection);

            transform.rotation = Quaternion.Euler(0,Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime).eulerAngles.y,0);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            returnHead = StartCoroutine(turnNPC_head(prevRotation,prevDirection));
        }
    }

    IEnumerator turnNPC_head(Quaternion rotationTo, Vector3 directionTo)
    {
        while(transform.forward != directionTo)
        {
            transform.rotation = Quaternion.Euler(0,Quaternion.Lerp(transform.rotation, rotationTo, rotationSpeed * Time.deltaTime).eulerAngles.y,0);
            
            yield return new WaitForFixedUpdate();
        }
    }
}
