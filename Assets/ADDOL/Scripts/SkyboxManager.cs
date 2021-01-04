using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{

    public List<Material> ListSkybox = new List<Material>();
    public bool UseApi;
    public int UseSky;
    public bool isRaining;
    public ParticleSystem Rain;

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

        Debug.Log(Rain);
        if (isRaining == true)
        {
            Rain.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateSkybox()
    {
        //Meteo.Inst.weather[0].description = "mist";
        switch (Meteo.Inst.weather[0].main)
        {
            case "Clear":
                RenderSettings.skybox = ListSkybox[7];
                break;
            case "Dust":
                RenderSettings.skybox = ListSkybox[2];
                break;
            case "Clouds":
                RenderSettings.skybox = ListSkybox[1];
                break;
            case "Rain":
                RenderSettings.skybox = ListSkybox[3];
                Rain.Play();
                Debug.Log("is raining : " + Rain.isPlaying);
                break;
            case "Thunderstorm":
                RenderSettings.skybox = ListSkybox[6];
                Rain.Play();
                break;
            case "Mist":
                RenderSettings.skybox = ListSkybox[4];
                break;
            default:
                RenderSettings.skybox = ListSkybox[5];
                break;
        }

    }
}
