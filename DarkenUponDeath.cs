using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class DarkenUponDeath : MonoBehaviour
{
    public float lerpRate;

    public Image imageToFade;

    public float fadeTime;
    [SerializeField]
    PostProcessLayer activeLayer;
    [SerializeField]
    PostProcessVolume volume;
    [SerializeField]
    PostProcessProfile regularProfile;
    [SerializeField]
    PostProcessProfile darkProfile;
    [SerializeField]
    ColorGrading cgLayer;
    
    [SerializeField]
    private Light[] lights;

    [SerializeField]
    float currentVal;

    public bool lightToDark;

    // Start is called before the first frame update
    void Start()
    {
        volume = this.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out cgLayer);

        lights = FindObjectsOfType(typeof(Light)) as Light[];
    }

    // Update is called once per frame
    void Update()
    {
        if (lightToDark)
        {
            lightToDark = false;
            StartCoroutine(DarthFader());
        }
    }

    public void FromLightToDark()
    {
        Debug.Log("Fading to black");
        volume.profile = darkProfile;
        
    }

    public void FromDarkToLight()
    {
        volume.profile = regularProfile;
    }

    public IEnumerator DarthFader()
    {
        FromLightToDark();
        yield return new WaitForSeconds(fadeTime) ;
        FromDarkToLight();
    }
}
