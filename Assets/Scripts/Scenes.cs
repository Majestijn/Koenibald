using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class Scenes
{

    private static string parameter;//De parameter die opgeslagen is

    public static void Load(string sceneName, string parameters)
    {
        Scenes.parameter = parameters;//sla de parameter op
        SceneManager.LoadScene(sceneName);//laad de nieuwe scene
    }
    public static string getParam() => parameter;//getter voor parameter

    public static void setParam(string param) => parameter = param;//setter voor de parameter

}
