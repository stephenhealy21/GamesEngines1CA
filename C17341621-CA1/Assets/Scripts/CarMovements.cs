using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovements : MonoBehaviour
{
    public GameObject wheel1;
    public GameObject wheel2;
    public GameObject wheel3;
    public GameObject wheel4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion tempQuaternion;

        float rotateDegrees = 5f;
        /*
        tempQuaternion = wheel1.transform.rotation;
        tempQuaternion.x = tempQuaternion.x + rotateDegrees;
        wheel1.transform.rotation = tempQuaternion;

        tempQuaternion = wheel2.transform.rotation;
        tempQuaternion.x = tempQuaternion.x + rotateDegrees;
        wheel2.transform.rotation = tempQuaternion;

        tempQuaternion = wheel3.transform.rotation;
        tempQuaternion.x = tempQuaternion.x + rotateDegrees;
        wheel3.transform.rotation = tempQuaternion;

        tempQuaternion = wheel4.transform.rotation;
        tempQuaternion.x = tempQuaternion.x + rotateDegrees;
        wheel4.transform.rotation = tempQuaternion;
        */

        wheel1.transform.Rotate(xAngle:rotateDegrees,yAngle:0,zAngle:0,relativeTo:Space.Self);
        wheel2.transform.Rotate(xAngle:rotateDegrees,yAngle:0,zAngle:0,relativeTo:Space.Self);
        wheel3.transform.Rotate(xAngle:rotateDegrees,yAngle:0,zAngle:0,relativeTo:Space.Self);
        wheel4.transform.Rotate(xAngle:rotateDegrees,yAngle:0,zAngle:0,relativeTo:Space.Self);
    }
}
