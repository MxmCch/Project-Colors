using UnityEngine;

public class EmotionClass : MonoBehaviour
{
    public int hope;
    public int curiosity;
    public int unbelief;
    public int cynicism;
    
    public void ChangeEmotions(int ho,int cu,int un,int cy)
    {
        hope = ho;
        curiosity = cu;
        unbelief = un;
        cynicism = cy;
    }
}