using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour{

     public GameObject target;

      public Vector2 cameraPosition;

      public int speedX = 10;
      public int speedY = 5;
      public int scrollSpeed = 5;
      public float range = 2f;


      public float distance = 3.5f;
      private Vector3 radius;

     private RaycastHit cameraHit, objectHit;
     private TakingObject objectCollider;

      private Color oldColor;

    //bool isRadius = false; is assigned but its value is never used

    void Update()
    {
        radius.x += Input.GetAxis("Mouse X") * speedX;
        radius.y -= Input.GetAxis("Mouse Y") * speedY;
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

        distance = Mathf.Clamp(distance, 3f, 5.0f);
        radius.y = Mathf.Clamp(radius.y, -10.0f, 40.0f); //todo

        if (this.objectCollider != null){
            this.objectCollider.GetComponent<Renderer>().material.color = this.oldColor;

            this.objectCollider = null;
        }
    }

    void LateUpdate(){
        Vector3 direction = new Vector3(cameraPosition.x, cameraPosition.y, -distance);
        Quaternion rotation = Quaternion.Euler(radius.y, radius.x, 0.0f);

        transform.position = rotation * direction + target.transform.position;
        transform.rotation = rotation;


        if(Physics.Linecast(target.transform.position + new Vector3(0, 1.2f, 0), transform.position, out cameraHit)) //todo
            transform.position = cameraHit.point;

        if (Physics.Raycast(transform.position, transform.forward, out objectHit, distance + range)){
            this.objectCollider = (objectHit.collider.gameObject).GetComponentInParent<TakingObject>();

            if(objectCollider != null){
                this.oldColor = objectCollider.GetComponent<Renderer>().material.color;
                this.objectCollider.GetComponent<Renderer>().material.color = Color.red; //todo

                if (Input.GetKeyDown(KeyCode.E)){
                    //...

                    (this.objectCollider).GetComponent<Renderer>().material.color = this.oldColor;
                    (this.objectCollider).Activate();
                }
            }
        } 
    }


    private void OnGUI(){
        if (this.objectCollider != null){ //debug
            GUI.contentColor = Color.red;

            GUI.Label(new Rect(Screen.width - 130, Screen.height - 85, 200, 100), "Użyj " + objectCollider.objectName);
        }
    }
}
