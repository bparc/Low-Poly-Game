using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour{
     public GameObject target;
     public Vector2 cameraPosition;

    [Header("Speed Values")]
      public int speedX = 10;
      public int speedY = 5;
      public int scrollSpeed = 5;

    [Header("Limit Values")]
      public float range = 2f;
      public float distance = 3.5f;
      public float minDistance = 1.9f;
      public float maxDistance = 5.0f;

     private Vector3 radius;
     private Vector3 textPosition;
     private RaycastHit cameraHit, objectHit;

     private TakingObject objectCollider;

    //bool isRadius = false;

    void Update(){
        radius.x += Input.GetAxis("Mouse X") * speedX;
        radius.y -= Input.GetAxis("Mouse Y") * speedY;
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        radius.y = Mathf.Clamp(radius.y, -10.0f, 40.0f);


        if (this.objectCollider != null){
            (this.objectCollider.GetComponent<Renderer>()).material.color = this.objectCollider.materialColor;



            this.objectCollider = null;
        }
    }

    void LateUpdate(){
        Vector3 direction = new Vector3(cameraPosition.x, cameraPosition.y, -distance);
        Quaternion rotation = Quaternion.Euler(radius.y, radius.x, 0.0f);

        transform.position = rotation * direction + target.transform.position;
        transform.rotation = rotation;


        if(Physics.Linecast(target.transform.position + new Vector3(0, 1.2f, 0), transform.position, out cameraHit) && cameraHit.collider.isTrigger == false)
            transform.position = cameraHit.point;


        if (Physics.Raycast(transform.position, transform.forward, out objectHit, distance + range)){
            this.objectCollider = (objectHit.collider.gameObject).GetComponent<TakingObject>();

            if(objectCollider != null){
                this.objectCollider.GetComponent<Renderer>().material.color = Color.red; /// TODO (by RhAnjiE) - "Change selection type"
                textPosition = GetComponent<Camera>().WorldToScreenPoint(objectHit.transform.position);

                if (Input.GetKeyDown(KeyCode.E)){
                    (this.objectCollider).Activate();

                    //...
                }

                return;
            }
        } 
    }


    private void OnGUI(){
        if (this.objectCollider != null){ //debug
            GUI.contentColor = Color.green;

            GUI.Label(new Rect(textPosition.x - (objectCollider.objectName.Length * 7) / 2, Screen.height - textPosition.y, objectCollider.objectName.Length * 7, 100), objectCollider.objectName);
        }
    }
}
