using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    [SerializeField]
    bool topBlack;

    [SerializeField]
    bool bottomBlack;

    private void OnEnable() {
        if (topBlack)
        {
            //this.transform.position = new Vector2(this.transform.position.x, 930);
            this.transform.LeanMoveY(930,2).setEaseOutCubic();
        }
        if (bottomBlack)
        {
            this.transform.LeanMoveY(200,2).setEaseOutCubic();
        }
    }
}
