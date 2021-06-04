using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSchermScript : MonoBehaviour
{
    public GameObject start, schoolDead, schoolVictory, sewerDead, sewerVictory, seaDead, seaVictory, gardenDead,gardenVictory;

    void Start()
    {
        var scenePar = Scenes.getParam();


        switch (scenePar) //kijk welke info in de static class opgeslagen is en laad met deze informatie de juiste prefab zodat de user het correcte canvas ziet
        {
            case "schoolDead":
                Instantiate(schoolDead);
                break;

            case "schoolVictory":
                Instantiate(schoolVictory);
                break;

            case "sewerDead":
                Instantiate(sewerDead);
                break;

            case "sewerVictory":
                Instantiate(sewerVictory);
                break;

            case "seaDead":
                Instantiate(seaDead);
                break;

            case "seaVictory":
                Instantiate(seaVictory);
                break;
            case "gardenDead":
                Instantiate(gardenDead);
                break;

            case "gardenVictory":
                Instantiate(gardenVictory);
                break;

            default:
                Instantiate(start);
                break;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
