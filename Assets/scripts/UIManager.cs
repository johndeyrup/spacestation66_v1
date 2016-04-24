using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {
    // Use this for initialization
    public List<Vector3> teleportPositions;
    private Camera cam;
    private bool BuildMode;
    public GameObject BuildOb;
    private GameObject MovingBuildOb;
    private bool ObPlaced;
    public Transform SpaceStation;
    public Canvas canv;
    private float delay;
    public GameObject SpaceShip;
    private GameObject MovingShip;
    public GameObject DockBay;
    private Vector3 DockBayPos;

    void Start () {
        BuildMode = false;
        ObPlaced = false;
        teleportPositions = new List<Vector3>();
        cam = Camera.main;
        teleportPositions.Add(new Vector3(1.0f,0.0f,0.0f));
        MovingShip = (GameObject) Instantiate(SpaceShip, new Vector3(30.0f, -10.0f, 100.0f), Quaternion.identity);
        MovingShip.transform.Rotate(new Vector3(-90f, -90f));
        DockBayPos = DockBay.transform.position;
        DockBayPos += new Vector3(0f, -2f, 0f);
	}

    public void CommandModule()
    {
        cam.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        canv.transform.position = new Vector3(0.0f, 0.0f, 0.98f);
    }

    public void Build()
    {
        BuildMode = true;
        cam.transform.position = new Vector3(0.0f, 0.0f, -8.0f);
        MovingBuildOb = (GameObject) Instantiate(BuildOb, new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
        MovingBuildOb.transform.SetParent(SpaceStation);
        ObPlaced = false;
        delay = 1.0f;
    }

    public void ObsDeck()
    {
        cam.transform.position = new Vector3(0.0f, 3.0f, 0.0f);
        canv.transform.position = new Vector3(-0.5f, 3.3f, 0.98f);
    }

    public void DockingBay()
    {
        cam.transform.position = new Vector3(0.0f, -3.0f, 0.0f);
        canv.transform.position = new Vector3(0.0f, -3.0f, 0.98f);
    }
	
	// Update is called once per frame
	void Update () {
        
        MovingShip.transform.position = Vector3.MoveTowards(MovingShip.transform.position, DockBayPos, .1f);
        if (BuildMode == true & ObPlaced == false)
        {
            delay -= Time.deltaTime;
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 transform_pos = new Vector3(hit.point.x*10, 0.0f, 0.0f);
                MovingBuildOb.transform.position = transform_pos;
                if (Input.GetMouseButtonUp(0) & delay < 0)
                {
                    ObPlaced = true;
                    cam.transform.position = new Vector3(0.0f,0.0f,0.0f);
                    teleportPositions.Add(MovingBuildOb.transform.position);
                }
            }
            else
            {

            }
        }


    }
}
