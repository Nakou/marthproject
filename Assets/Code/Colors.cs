using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{

    [SerializeField] public Color white;
    [SerializeField] public Color red;
    [SerializeField] public Color green;
    [SerializeField] public Color blue;
    [SerializeField] public Color yellow;
    [SerializeField] public Color cyan;
    [SerializeField] public Color purple;

    public COLORGAME defineColor(bool redSelected, bool greenSelected, bool blueSelected)
    {
        COLORGAME currentSelectedColor = COLORGAME.NULL;
        if (!redSelected && !greenSelected && !blueSelected)
        {
            currentSelectedColor = COLORGAME.NULL;
        }
        if (redSelected && !greenSelected && !blueSelected)
        {
            currentSelectedColor = COLORGAME.RED;
        }
        if (!redSelected && greenSelected && !blueSelected)
        {
            currentSelectedColor = COLORGAME.GREEN;
        }
        if (!redSelected && !greenSelected && blueSelected)
        {
            currentSelectedColor = COLORGAME.BLUE;
        }
        if (redSelected && greenSelected && !blueSelected)
        {
            currentSelectedColor = COLORGAME.YELLOW;
        }
        if (!redSelected && greenSelected && blueSelected)
        {
            currentSelectedColor = COLORGAME.CYAN;
        }
        if (redSelected && !greenSelected && blueSelected)
        {
            currentSelectedColor = COLORGAME.PURPLE;
        }
        if (redSelected && greenSelected && blueSelected)
        {
            currentSelectedColor = COLORGAME.WHITE;
        }
        return currentSelectedColor;
    }

    public Color getColor(COLORGAME color)
    {
        Color retVal;
        switch (color)
        {
            case COLORGAME.RED:
                retVal = red;
                break;
            case COLORGAME.GREEN:
                retVal = green;
                break;
            case COLORGAME.BLUE:
                retVal = blue;
                break;
            case COLORGAME.YELLOW:
                retVal = yellow;
                break;
            case COLORGAME.CYAN:
                retVal = cyan;
                break;
            case COLORGAME.PURPLE:
                retVal = purple;
                break;
            case COLORGAME.WHITE:
                retVal = white;
                break;
            default:
                retVal = white;
                break;
        }
        return retVal;
    }

    public enum COLORGAME
    {
        RED,
        GREEN,
        BLUE,
        YELLOW,
        CYAN,
        PURPLE,
        WHITE,
        NULL
    }
}
