using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{

    public List<Material> ListSkybox = new List<Material>();
    /*public Material SkyNightMoon;
    public Material SkypinkGlorious;
    public Material BlueSunset;
    public Material DeepDusk;
    public Material ColdSunset;
    public Material ColdNight;
    public Material NightSky;
    public Material DaySky;*/
    public bool UseApi;
    public int UseSky;

    // Start is called before the first frame update
    void Start()
    {
        if (UseApi == true)
        {
            APICall.onLoad += UpdateSkybox;
        }
        else if (UseSky < ListSkybox.Count)
        {
            RenderSettings.skybox = ListSkybox[UseSky];
        }
        else
        {
            RenderSettings.skybox = ListSkybox[0];
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateSkybox()
    {
        switch (Meteo.Inst.weather[0].description)
        {
            case "clear sky":
                RenderSettings.skybox = ListSkybox[7];
                break;
            case "few clouds":
                RenderSettings.skybox = ListSkybox[2];
                break;
            case "broken clouds":
                RenderSettings.skybox = ListSkybox[1];
                break;
            case "rain":
                RenderSettings.skybox = ListSkybox[3];
                break;
            case "thunderstorm":
                RenderSettings.skybox = ListSkybox[6];
                break;
            case "mist":
                RenderSettings.skybox = ListSkybox[4];
                break;
            default:
                RenderSettings.skybox = ListSkybox[5];
                break;
        }

    }
}
