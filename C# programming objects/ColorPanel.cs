using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ColorPanel : MonoBehaviour {

    [SerializeField]
    private Renderer brushExample;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Rect buttonOnRect, redRect, greenRect, blueRect, alfaRect;

    [SerializeField]
    private string backgroundLabel, brushLabel;

    [SerializeField]
    private Color backgroundColor, brushColor;


    private bool turnedON = false;
    private float red = 0.5f, green = 0.5f, blue = 0.5f, alfa = 0.5f;
    private string labelButtonON;
    private Color currentColor;

    public Color CurrentColor {
        get {

            return brushColor;
        }
    
    }


	void Start () {
        labelButtonON = brushLabel;

        if (mainCamera != null)
        {
            mainCamera.backgroundColor = backgroundColor;
        }
        
        if (brushExample != null)
        {
            brushExample.material.color = brushColor;
        }

        red = backgroundColor.r;
        green = backgroundColor.g;
        blue = backgroundColor.b;
        alfa = backgroundColor.a;

	}
	
    private void OnGUI()
    {
        

        red = GUI.HorizontalSlider(redRect, red, 0f, 1f);
        green = GUI.HorizontalSlider(greenRect, green, 0f, 1f);
        blue = GUI.VerticalSlider(blueRect, blue, 0f, 1f);
        alfa = GUI.VerticalSlider(alfaRect, alfa, 0f, 1f);

        currentColor = new Color(red, green, blue, alfa);

        if (labelButtonON.Equals(brushLabel) && mainCamera != null)
        {
            mainCamera.backgroundColor = currentColor;
        }
        else if(brushExample != null) {



            brushExample.material.color = currentColor;
        }


        if (GUI.Button(buttonOnRect, labelButtonON))
        {
            if (labelButtonON.Equals(brushLabel))
            {
                backgroundColor = currentColor;
                labelButtonON = backgroundLabel;

                red = brushColor.r;
                green = brushColor.g;
                blue = brushColor.b;
                alfa = brushColor.a;

            }
            else
            {
                brushColor = currentColor;
                labelButtonON = brushLabel;

                red = backgroundColor.r;
                green = backgroundColor.g;
                blue = backgroundColor.b;
                alfa = backgroundColor.a;
            }
        }

    }
}
