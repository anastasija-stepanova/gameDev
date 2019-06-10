using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorManager
{
    public static Color GetColorFromAvailable(AvailableColors color)
    {
        string htmlColor = "";
        
        switch (color)
        {
                case AvailableColors.Red:
                    htmlColor = "#E92727";
                    break;
                case AvailableColors.Gray:
                    htmlColor = "#212F32";
                    break;
                case AvailableColors.Blue:
                    htmlColor = "#308EA2";
                    break;
                case AvailableColors.Green:
                    htmlColor = "#30AB36";
                    break;
        }

        Color returnColor;

        if (ColorUtility.TryParseHtmlString(htmlColor, out returnColor))
        {
            return returnColor;
        }

        return Color.white;
    }
}
