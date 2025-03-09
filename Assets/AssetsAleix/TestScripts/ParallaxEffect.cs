using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    /*Target follows camera. If we put the player in the target, the assets will move horizontally*/

    public Transform target; 

    /*We modify the factor's value depending on how much we want it to slow*/

    public float parallaxFactor = 0.5f; 

    private Vector3 lastCameraPosition;

    void Start()
    {
        /*If the target has not been assigned, we use the main camera*/

        if (target == null)
        {
            target = Camera.main.transform;
        }
        /*We save in lastcamera position the initial position of our camera to see how much we have moved in the next update*/
        lastCameraPosition = target.position;
    }

    void Update()
    {
        /*We test how much the camera has moved since the previous update*/
        Vector3 deltaMovement = target.position - lastCameraPosition;
        /*We aply the parallax effect*/
        transform.position += new Vector3(deltaMovement.x * parallaxFactor, deltaMovement.y * parallaxFactor, 0);
        /*Camera position is updated*/
        lastCameraPosition = target.position;
    }
}
