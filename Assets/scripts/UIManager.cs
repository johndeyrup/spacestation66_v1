using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {
    // Use this for initialization
    public List<Vector3> teleportPositions;
    private Camera cam;
    private bool BuildMode;
    void Start () {
        BuildMode = false;
        teleportPositions = new List<Vector3>();
        cam = Camera.main;
        teleportPositions.Add(new Vector3(1.0f,0.0f,0.0f));
	}

    public void Build()
    {
        BuildMode = true;
        cam.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        cam.transform.position = new Vector3(0.0f, 10.0f, 0.0f);

    }

    public void Teleport()
    {
        //Debug.Log(teleportPositions);
    }
	
	// Update is called once per frame
	void Update () {
        if (BuildMode == true)
        {
            
        }


    }
}
