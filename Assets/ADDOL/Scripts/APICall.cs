using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APICall : MonoBehaviour
{

    public delegate void OnLoad();
    public static event OnLoad onLoad;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(AppConfig.Inst.WebAPILink);
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(AppConfig.Inst.WebAPILink))
        {
            Debug.Log(www.url);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);
                Meteo.Inst.UpdateValuesFromJSON(www.downloadHandler.text);
                Debug.Log(Meteo.Inst.weather[0].main);
                onLoad?.Invoke();
            }
        }
    }
}
