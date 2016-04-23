using UnityEngine;
using System.Collections;

public class Placement : MonoBehaviour {
	enum addState{
		add,
		none
	};

	public float dist;
	public KeyCode addKey;
	public MeshRenderer addObject;

	MeshRenderer addIndicator;

	addState currentAddState;
	// Use this for initialization
	void Start () {
		currentAddState = addState.none;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(addKey)){
			SetState();
		}

		if (currentAddState == addState.add) {
			// Update the position of the object
			SetIndicatorPosition();

			if(Input.GetKeyDown(KeyCode.A)){
				CreateObjectInScene();
			}
		}
	}

	void SetState(){
		if (currentAddState == addState.add) {
			currentAddState = addState.none;
			EndAdd();
		}
		else {
			currentAddState = addState.add;
			StartAdd();
		}

		print ("current adding state set to " + currentAddState);
	}

	public void StartAdd(){
		// Make sure it does not exist yet
		addIndicator = (MeshRenderer) Instantiate(addObject, transform.position, transform.rotation);
	}

	public void EndAdd(){
		// Check if exists first
		Destroy (addIndicator);
	}

	void SetIndicatorPosition(){
		addIndicator.transform.position = GetPlacementPosition ();
		addIndicator.transform.rotation = GetPlacementRotation ();
	}

	void CreateObjectInScene(){
		Instantiate (addObject, GetPlacementPosition(), GetPlacementRotation());
	}

	Vector3 GetPlacementPosition(){
		Transform ct = Camera.main.transform;

		return ct.TransformVector(new Vector3(0,0, dist));
	}

	Quaternion GetPlacementRotation(){
		Transform ct = Camera.main.transform;

		Quaternion rotation = ct.rotation;
		rotation.x = 0;
		return rotation;
	}
}