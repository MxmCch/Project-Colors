using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeanTweenScript : MonoBehaviour
{
    [SerializeField]
    bool isButton;
    [SerializeField]
    bool isDialog;

    [SerializeField]
    float appearSpeed;
    
    Vector3 prevPosition;

    private void Awake() 
    {
        prevPosition = this.transform.position;
    }

    private void OnEnable() 
    {
        if (isButton)
        {
            this.transform.position = prevPosition;
            this.transform.LeanMoveLocalX(8, appearSpeed).setEaseOutQuint();
        }

        if (isDialog)
        {
            var tempColor = this.GetComponent<Image>().color;
            tempColor.a = 0;
            this.GetComponent<Image>().color = tempColor;

            LeanTween.value(this.gameObject, setColorCallback, 0, .9f, .6f).setEaseOutQuint();
        }
    }

    private void setColorCallback(float a)
    {
        var tempColor = this.GetComponent<Image>().color;
        tempColor.a = a;
        this.GetComponent<Image>().color = tempColor;
    }
}
