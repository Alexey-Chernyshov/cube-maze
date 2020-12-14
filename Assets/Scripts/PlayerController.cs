using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish" && GlobalVariables.get_gameStage() == 1)
            GlobalVariables.set_gameStage(2);
    }
}
