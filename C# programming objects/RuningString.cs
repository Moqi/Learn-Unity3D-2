using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class RuningString : MonoBehaviour {

    [SerializeField] private string fullString;
    [SerializeField] [Range(.1f,1)] private float speed;
    [SerializeField]
    private Rect labelRect;

    private string currentText="";
    private float timmer;


	// Use this for initialization
	void Start () {
        //SetTimer();

	}
	
	// Update is called once per frame
	void Update () {
	if (Time.time > timmer)
    {
        
        if (currentText.Length == fullString.Length )
        {
            currentText = "";
        }

        currentText = fullString.Substring(0, currentText.Length + 1);
        SetTimer();

    }
	}

    private void OnGUI ()
    {
        GUI.Label(labelRect, currentText);

    }

    private void SetTimer()
    {
        timmer = Time.time + speed;

    }
}
