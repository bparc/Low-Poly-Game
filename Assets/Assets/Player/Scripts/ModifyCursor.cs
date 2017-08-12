using UnityEngine;
using System.Collections;

public class ModifyCursor : MonoBehaviour {

    public Texture2D crosshair;
    public bool isActive = true;

     private Rect position;

    private GameObject mainCamera;
    private GameObject mainHero;

    

	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainHero   = GameObject.FindGameObjectWithTag("Character");

        position = new Rect((Screen.width - crosshair.width) / 2, (Screen.height - crosshair.height) / 2, crosshair.width, crosshair.height);
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
         isActive = !isActive;


        if (isActive){
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            mainCamera.GetComponent<LookAt>().enabled  = true;
            mainHero.GetComponent<Movement>().isActive = true;
        }
        else {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            mainCamera.GetComponent<LookAt>().enabled  = false;
            mainHero.GetComponent<Movement>().isActive = false;
        }
    }

    void OnGUI() {
        if (isActive)
         GUI.DrawTexture(position, crosshair);
    }
}
