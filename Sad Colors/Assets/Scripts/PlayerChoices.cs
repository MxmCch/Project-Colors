using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoices : MonoBehaviour
{
    [Header("Good Choices")]
    public bool eatHealty;
    public bool save_kitten;
    public bool help_elderly;

    [Header("Bad Choices")]
    public bool kill_bugs;
    public bool eatBad;

    [Header("General Choices")]
    public bool eat;
    public bool pet_cat_regulary;
    public bool feed_fish;
    public bool feed_cat;
    public bool feed_cat_fish;
}
