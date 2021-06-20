using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public GameObject credits;
    public float staticTime = 2f;
    public float moveSpeed = 1f;
    public static float speed;

    private void Start()
    {
        speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        } else if (staticTime > 0)
        {
            staticTime -= Time.deltaTime;
        }

        if (speed > 0 && staticTime <= 0) credits.transform.Translate(Vector3.up * Time.deltaTime * speed * 100);

    }
}
