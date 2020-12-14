using UnityEngine;

public class RotateController : MonoBehaviour
{
    static Transform target;
    float speedRotate = 5;

    public static void set_target()
    {
        target = GlobalVariables.get_go_Cube(GlobalVariables.get_currentCube()).transform;
    }

    void Update()
    {
        if (GlobalVariables.get_gameStage() != 1 || !Input.GetMouseButton(0))
            return;

        float rotX = Input.GetAxis("Mouse X") * speedRotate * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * speedRotate * Mathf.Deg2Rad;


        if (Mathf.Abs(rotX) > Mathf.Abs(rotY))
            target.RotateAroundLocal(target.up, -rotX);
        else
            target.RotateAround(Camera.main.transform.right, rotY);
    }
}
