using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    static int numberCubes;
    static int[] timeLevel;

    static int gameStage; // 0 - menu, 1 - game, 2 - win, 3 - lose
    static int currentCube;

    static GameObject[] go_cube;
    static Quaternion[] initialCubeRotation;
    static GameObject[] go_sphere;
    static Vector3[] initialSpherePosition;

    void Awake()
    {
        init_numberCubes();
        init_timeLevels();

        gameStage = 0;
        currentCube = 0;

        go_cube = new GameObject[numberCubes];
        initialCubeRotation = new Quaternion[numberCubes];

        go_sphere = new GameObject[numberCubes];
        initialSpherePosition = new Vector3[numberCubes];

        for (int i = 0; i < numberCubes; i++)
        {
            go_cube[i] = GameObject.Find("Cubes/Cube" + (i + 1));
            initialCubeRotation[i] = go_cube[i].transform.rotation;

            go_sphere[i] = GameObject.Find("Cubes/Cube" + (i + 1) + "/Sphere" + (i + 1));
            initialSpherePosition[i] = go_sphere[i].transform.position;

            if (i != currentCube)
                go_cube[i].SetActive(false);
        }
    }

    void init_numberCubes() // you must increment the variable by one if you want to add a new level
    {
        numberCubes = 1;
    }

    public static int get_numberCubes()
    {
        return numberCubes;
    }

    void init_timeLevels()  // you must specify the time for the new level
    {
        timeLevel = new int[numberCubes];

        timeLevel[0] = 30;
    }

    public static int get_timeLevel()
    {
        return timeLevel[currentCube];
    }

    public static int get_gameStage()
    {
        return gameStage;
    }

    public static void set_gameStage(int n)
    {
        if (n >= 0 && n <= 3)
            gameStage = n;
    }

    public static int get_currentCube()
    {
        return currentCube;
    }

    public static void set_currentCube(int n)
    {
        if (n >= 0 && n < numberCubes)
            currentCube = n;
    }

    public static GameObject get_go_Cube(int n)
    {
        if (n >= 0 && n < numberCubes)
            return go_cube[n];
        else
            return null;
    }

    public static Quaternion get_initialCubeRotation(int n)
    {
        if (n >= 0 && n < numberCubes)
            return initialCubeRotation[n];
        else
            return new Quaternion();
    }

    public static GameObject get_go_Sphere(int n)
    {
        if (n >= 0 && n < numberCubes)
            return go_sphere[n];
        else
            return null;
    }

    public static Vector3 get_initialSpherePosition(int n)
    {
        if (n >= 0 && n < numberCubes)
            return initialSpherePosition[n];
        else
            return new Vector3();
    }
}
