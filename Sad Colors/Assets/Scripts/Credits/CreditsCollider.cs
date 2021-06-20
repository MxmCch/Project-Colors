using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("End Of Credits");
        CreditsScript.speed = 0;
    }
}
