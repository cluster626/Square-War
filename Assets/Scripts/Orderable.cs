﻿//TODO
//Add tempObject and be able to swap when new object is selected
//
using UnityEngine;
using System.Collections;

public class Orderable : MonoBehaviour {
    public GameObject basePrefab;
    public static GameObject selectedUnit;
    public bool selected = false;
    private Vector3 mousPos, objPos2D;
    private GameObject tempObject;
	// Use this for initialization
	void Start () {
        tempObject = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1)) {
            if (selectedUnit != null) {
                mousPos = Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                mousPos.z = 0;
                selectedUnit.GetComponent<Movable>().destination = 
                    new Vector3(selectedUnit.transform.position.x,
                    selectedUnit.transform.position.y, 0);
                Debug.Log(mousPos + " is mouse position");
                Debug.Log("Moving object " + selectedUnit);           
            }
        }
        Vector3 moveThreshold = new Vector3(0.1f, 0.1f, 0);
        if (Mathf.Abs(mousPos.x - objPos2D.x) >= moveThreshold.x || 
            Mathf.Abs(mousPos.y - objPos2D.y) >= moveThreshold.y) {
            Debug.Log(mousPos + " is mouse position:moving");
            Debug.Log(objPos2D + " is object position:moving");
            selectedUnit.transform.Translate(((mousPos - objPos2D) * 
            selectedUnit.GetComponent<Movable>().speed * Time.deltaTime));
            objPos2D = new Vector3(selectedUnit.transform.position.x,
                selectedUnit.transform.position.y, 0);
            Debug.Log("position x is: " + selectedUnit.transform.position.x + "position z is "
                + selectedUnit.transform.position.z);
           }
	}

    void Move() {

    }
    void OnMouseDown() {
        selectedUnit = gameObject;
        tempObject = gameObject;
        gameObject.GetComponent<Orderable>().selected = true;
        Debug.Log("Selected unit assigned to " + selectedUnit);
    }
}

