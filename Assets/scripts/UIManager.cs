using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {
    // Use this for initialization
    public List<Vector3> teleportPositions;
    void Start () {
        teleportPositions = new List<Vector3>();
        teleportPositions.Add(new Vector3(1.0f,0.0f,0.0f));
	}

    public void Teleport()
    {
        //Debug.Log(teleportPositions);
    }
	
	// Update is called once per frame
	void Update () {


    }
}
