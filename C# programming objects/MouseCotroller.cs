using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MouseCotroller : MonoBehaviour {

    [SerializeField]
    private ColorPanel colorPanel;

    [SerializeField]
    private Rect OnButtonRect;

    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private GameObject brush;
    [SerializeField] [Range(0.1f,0.5f)]
    private float distance;


    private Vector3 lastPoint;
    private bool onPaintFlag;
    private string buttonLabel = "Paint";



	void OnGUI () {

        if (GUI.Button(OnButtonRect, buttonLabel)) {
            
            onPaintFlag = !onPaintFlag;

            if (onPaintFlag)
            {
                buttonLabel = "Off Paint";
            }
            else {
                buttonLabel = "Paint";
            }

        }
	}
	
	
	void Update () {

        if (!onPaintFlag) {
            return;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            //print(mainCamera.ScreenToWorldPoint(Input.mousePosition));
            var tempUpdate = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(tempUpdate, lastPoint) > distance)
            {
                CreateBrush(tempUpdate);
            }


            
        }
                
	}

    private void CreateBrush(Vector3 position)
    {
        var temp = Instantiate(brush) as GameObject;
        if (temp != null)
        {
            
            temp.transform.position = position;

            var tempRenderer = temp.GetComponent<Renderer>();
            tempRenderer.material.color = colorPanel.CurrentColor;

            lastPoint = position;


        }
    }

}
