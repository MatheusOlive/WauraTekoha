using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpScript : MonoBehaviour
{
    public enum XpLevel { Small, Medium, Larger }

    [Header("Escolha o nivel de Xp")]

    [Space]
    public XpLevel XpLevels;
    [Space]

    public int XpValue;
    int SmallXpValue = 10;
    int MediumXpValue = 30;
    int LargerXpValue = 50;


    void Awake()
    {
        if (XpLevels == XpLevel.Small)
        {
            XpValue = SmallXpValue;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (XpLevels == XpLevel.Medium)
        {
            XpValue = MediumXpValue;
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (XpLevels == XpLevel.Larger)
        {
            XpValue = LargerXpValue;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (XpLevels == XpLevel.Small)
        {
            XpValue = SmallXpValue;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (XpLevels == XpLevel.Medium)
        {
            XpValue = MediumXpValue;
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (XpLevels == XpLevel.Larger)
        {
            XpValue = LargerXpValue;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
