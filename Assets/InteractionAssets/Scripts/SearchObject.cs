using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchObject : MonoBehaviour
{
    public enum itemCode
    {
        Empty,
        Cookie,
        Potion
    }
    public itemCode contents;
    public Color color;
    public Color original;

    private void Start()
    {
        color = GetComponent<SpriteRenderer>().color;
        original = GetComponent<SpriteRenderer>().color;
    }


    private void Update()
    {
        updateSprite();
        Debug.Log(contents);
    }

    private void updateSprite()
    {
        if (contents == itemCode.Cookie)
        {
            color = Color.cyan;
            GetComponent<SpriteRenderer>().color = color;
        }
        else if (contents == itemCode.Potion)
        {
            color = Color.green;
            GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = original;
        }
    }


}
