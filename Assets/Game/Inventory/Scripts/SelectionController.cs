using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectionController : MonoBehaviour {
    public RectTransform grid;

    void Start() {

    }

	void Update () {
        UpdatePosition();
	}

    void UpdatePosition() {
        GameObject selectedGameObject = EventSystem.current.currentSelectedGameObject;

        if (!selectedGameObject) {
            return;
        }

        if (selectedGameObject.transform.parent == grid) {
            transform.position = selectedGameObject.transform.position;
        }
    }
}