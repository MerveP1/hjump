using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HellixRotator : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationSpeedAndroid;

    //public float rotationSpeedAndroid = 50f;

    private void Update()
    { 
        // for pc 
        if(Input.GetMouseButton(0))
        { 
            float mouseX = Input.GetAxisRaw ("Mouse X");
           transform.Rotate (0f, -mouseX * rotationSpeed * Time.deltaTime, 0f);
        }

        // for android

       if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
       {
            float XDeltaPos = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate (transform.position.x, -XDeltaPos * rotationSpeedAndroid * Time.deltaTime, transform.position.z);
       }


    }

}
