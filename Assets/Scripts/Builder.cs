using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Builder : MonoBehaviour {
	enum addState{
		add,
		none
	};

	public float dist;
	public KeyCode addKey;
	public List<GameObject> addObjects;

	GameObject addIndicator;
	public int selectedObjectIndex;

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
			if(Input.GetKeyDown(KeyCode.Q)){
				SwitchModule(selectedObjectIndex + 1);
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
		addIndicator = GetNewObject ();
	}

	public void EndAdd(){
		// Check if exists first
		Destroy (addIndicator);
	}

	void SwitchModule(int index){
		Destroy (addIndicator);

		selectedObjectIndex = index;
		if (selectedObjectIndex >= addObjects.Count) {
			selectedObjectIndex -= addObjects.Count;
		}

		addIndicator = GetNewObject ();
	}

	GameObject GetNewObject(){
		return (GameObject) Instantiate(addObjects[selectedObjectIndex], GetPlacementPosition(), GetPlacementRotation());
	}

	void SetIndicatorPosition(){
		addIndicator.transform.position = GetPlacementPosition ();
		addIndicator.transform.rotation = GetPlacementRotation ();
	}

	void CreateObjectInScene(){
		GetNewObject ();
	}

	Vector3 GetPlacementPosition(){
		Transform ct = Camera.main.transform;
		float y = ct.transform.rotation.eulerAngles.y;
		Vector3 pos = ct.TransformVector(new Vector3(0,0, dist * Mathf.Cos(y)));
		pos.z = 0;
		float value = Mathf.Sin ((y * (Mathf.PI / 180.0f)));
		Vector3 output = new Vector3 (0, 0, (1.0f / value));

		print (value);

		return output;
	}

	Quaternion GetPlacementRotation(){
		Transform ct = Camera.main.transform;

		Quaternion rotation = ct.rotation;
		rotation.x = 0;
		rotation.y = 0;
		rotation.z = 0;
		return rotation;
	}
}