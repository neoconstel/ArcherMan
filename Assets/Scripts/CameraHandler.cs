using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    // the settings of the screen and camera at perfect testing conditions
    public int reverenceScreenWidth;
    public int reverenceScreenHeight;
    public float reverenceCameraOrthographicSize;

    public new Camera camera;


    // Start is called before the first frame update
    void Start()
    {
        // adjust the camera orthographic size to fit the aspect ratio of the screen, based on the reference values
        camera.orthographicSize = (reverenceScreenWidth * reverenceCameraOrthographicSize)/(reverenceScreenHeight * camera.aspect);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
