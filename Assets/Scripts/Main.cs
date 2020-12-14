using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    GameObject go_start;
    GameObject go_level;
    Text txt_level;
    GameObject go_time;
    Text txt_time;
    GameObject go_result;
    Text txt_result;

    float timeGame = 0;
    float timeResult = 0;

    void Awake()
    {
        go_start = GameObject.Find("UI/btn_start");
        go_start.SetActive(true);

        go_level = GameObject.Find("UI/txt_level");
        txt_level = go_level.GetComponent<Text>();
        txt_level.text = "Level: " + (GlobalVariables.get_currentCube() + 1);
        go_level.SetActive(true);

        go_time = GameObject.Find("UI/txt_time");
        txt_time = go_time.GetComponent<Text>();
        go_time.SetActive(false);

        go_result = GameObject.Find("UI/txt_result");
        txt_result = go_result.GetComponent<Text>();
        go_result.SetActive(false);
    }

    public void btn_startClick()
    {
        go_start.SetActive(false);
        go_level.SetActive(false);

        timeGame = GlobalVariables.get_timeLevel();
        txt_time.text = "Time: " + ((int)timeGame).ToString() + " sec";
        go_time.SetActive(true);

        RotateController.set_target();
        GlobalVariables.set_gameStage(1);
    }

    void Update()
    {
        int gameStage = GlobalVariables.get_gameStage();

        if (gameStage == 0)
            return;

        if (gameStage == 1 && timeGame > 0)
        {
            timeGame = timeGame - Time.deltaTime;
            txt_time.text = "Time: " + ((int)timeGame).ToString() + " sec";
            if (timeGame <= 0)
                GlobalVariables.set_gameStage(3);
        }
        else if ((gameStage == 2 || gameStage == 3) && timeResult <= 0)
        {
            go_time.SetActive(false);

            timeResult = 2.5f;
            if (gameStage == 2)
                txt_result.text = "YOU WIN !!!";
            if (gameStage == 3)
                txt_result.text = "YOU LOSE :(";
            go_result.SetActive(true);
        }
        else if ((gameStage == 2 || gameStage == 3) && timeResult > 0)
        {
            timeResult = timeResult - Time.deltaTime;
            if (timeResult <= 0)
            {
                go_result.SetActive(false);

                int currentCube = GlobalVariables.get_currentCube();

                GameObject Cube = GlobalVariables.get_go_Cube(currentCube);
                Cube.transform.rotation = GlobalVariables.get_initialCubeRotation(currentCube);
                GameObject Sphere = GlobalVariables.get_go_Sphere(currentCube);
                Sphere.transform.position = GlobalVariables.get_initialSpherePosition(currentCube);
                Cube.SetActive(false);

                if (currentCube < (GlobalVariables.get_numberCubes() - 1))
                    GlobalVariables.set_currentCube(currentCube + 1);

                GlobalVariables.get_go_Cube(GlobalVariables.get_currentCube()).SetActive(true);
                txt_level.text = "Level: " + (GlobalVariables.get_currentCube() + 1);
                go_level.SetActive(true);
                go_start.SetActive(true);
                GlobalVariables.set_gameStage(1);
            }
        }
    }
}
