using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibeChanger : MonoBehaviour
{
    EmotionClass _EmotionClass;
    ParticleSystem _ParticleSystem;
    ParticleSystem.ColorOverLifetimeModule col;
    public Gradient grad;

    GameObject noPostCamera;
    public bool runthis;
    //2.5 full color
    //5 no color
    public float distance;
    [SerializeField]
    bool cutscene;

    public GradientAlphaKey[] _GradientAlphaKeys = new GradientAlphaKey[] {new GradientAlphaKey(0.0f, 0.6f) , new GradientAlphaKey(0.0f, 0.8f), new GradientAlphaKey(0.0f, 1.0f)};
    public GradientColorKey[] _GradientColorKeys = new GradientColorKey[] {new GradientColorKey(Color.white, 0.6f) , new GradientColorKey(Color.white, 0.8f), new GradientColorKey(Color.white, 1.0f)};

    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "NoPostCamera")
        {
            noPostCamera = other.gameObject;
            ChangeColor(
                Color.yellow*_EmotionClass.hope/255,
                Color.red*_EmotionClass.cynicism/255,
                Color.green*_EmotionClass.curiosity/255,
                Color.blue*_EmotionClass.unbelief/255
            );
            
            float EmptyEmotion = _EmotionClass.hope+_EmotionClass.cynicism+_EmotionClass.curiosity+_EmotionClass.unbelief;
            if (EmptyEmotion == 0)
            {
                GradientColorKey[] check = grad.colorKeys;
                check[2].color = Color.white;
                _GradientAlphaKeys = new GradientAlphaKey[] {new GradientAlphaKey(0.0f, 0.6f) , new GradientAlphaKey(0.0f, 0.8f), new GradientAlphaKey(0.0f, 1.0f)};
                grad.SetKeys(_GradientColorKeys,_GradientAlphaKeys);
            }
            else
            {
                GradientColorKey[] check = grad.colorKeys;
                check[2].color = Color.white;
                _GradientAlphaKeys[2] = new GradientAlphaKey(0f,1f);
                grad.SetKeys(check,_GradientAlphaKeys);
            }
            col.color = grad;
            runthis = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "NoPostCamera")
        {
            grad.SetKeys(_GradientColorKeys,_GradientAlphaKeys);
            col.color = grad;
            noPostCamera = null;
            runthis = false;
        }
    }

    private void OnEnable() 
    {
        _ParticleSystem = gameObject.GetComponent<ParticleSystem>();
        col = _ParticleSystem.colorOverLifetime;
        grad = col.color.gradient;
        _EmotionClass = this.transform.parent.gameObject.GetComponent<EmotionClass>();
        ChangeColor(
            Color.yellow*_EmotionClass.hope/255,
            Color.red*_EmotionClass.cynicism/255,
            Color.green*_EmotionClass.curiosity/255,
            Color.blue*_EmotionClass.unbelief/255
        );
    }

    private void Start() 
    {
        grad.SetKeys(_GradientColorKeys,_GradientAlphaKeys);
        col.color = grad;
    }

    private void FixedUpdate() 
    {
        if (noPostCamera != null && runthis)
        {
            distance = Vector3.Distance(this.gameObject.transform.position, noPostCamera.transform.position);
            float alphaFloat = Mathf.Clamp01(4.6f-distance);
            if (cutscene)
            {
                alphaFloat=1;
            }
            GradientAlphaKey[] alphaKeysZ = new GradientAlphaKey[grad.alphaKeys.Length];
            alphaKeysZ[1] = new GradientAlphaKey(alphaFloat,0.8f);
            grad.SetKeys(grad.colorKeys,alphaKeysZ);
            col.color = grad;
        }
        
    }

    public void ChangeColor(params Color[] aColors)
    {
        Color newColor = CombineColors(aColors);
        newColor.a = 1;
        grad = new Gradient();
        grad.SetKeys( new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(newColor, 0.8f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.6f) , new GradientAlphaKey(1.0f, 0.8f), new GradientAlphaKey(0.0f, 1.0f)  } );
        col.color = grad;
    }

    public static Color CombineColors(params Color[] aColors)
    {
        Color result = new Color(0,0,0);
        foreach(Color c in aColors)
        {
            result += c;
        }
        return result;
    }
}
