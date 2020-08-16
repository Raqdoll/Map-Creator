using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Square : MonoBehaviour
{
    public Color32 color_empty;
    public Color32 color_block;
    public Color32 color_normal;
    public Color32 color_p1;
    public Color32 color_p2;

    public int currentState = 0;
    //0 Normal
    //1 Empty
    //2 Block
    //3 P1
    //4 P2

    private Image img;

    void Start()
    {
        img = GetComponent<Image>();
    }

    //Can be called to reset this square
    public void ResetThis()
    {
        currentState = 0;
        img.color = color_normal;
    }

    //Can be called to destroy this square
    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    //Adds +1 to the current square and changes color & value accordingly, used when clicking the square
    public void ChangeMode()
    {
        switch (currentState)
        {
            case 0:
                currentState++;
                img.color = color_empty;
                break;
            case 1:
                currentState++;
                img.color = color_block;
                break;
            case 2:
                currentState++;
                img.color = color_p1;
                break;
            case 3:
                currentState++;
                img.color = color_p2;
                break;
            case 4:
                currentState = 0;
                img.color = color_normal;
                break;
            default:
                currentState = 0;
                img.color = color_normal;
                break;
        }
    }
    //Sets the square's value and color to the given value
    public void SetState(int state)
    {
        img = GetComponent<Image>();
        switch (state)
        {
            case 0:
                currentState = state;
                img.color = color_normal;
                break;
            case 1:
                currentState = state;
                img.color = color_empty;
                break;
            case 2:
                currentState = state;
                img.color = color_block;
                break;
            case 3:
                currentState = state;
                img.color = color_p1;
                break;
            case 4:
                currentState = state;
                img.color = color_p2;
                break;
            default:
                currentState = 0;
                img.color = color_normal;
                break;
        }
    }
}
