using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class DarkenUponDeath : MonoBehaviour
{
    //ColorGrading cg;
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

    //public Image controlsImage;

    [SerializeField]
    private Light[] lights;

    [SerializeField]
    float currentVal;

    public bool lightToDark;

    // Start is called before the first frame update
    void Start()
    {
        //controlsImage.gameObject.SetActive(false);
        //cg = this.GetComponent<ColorGrading>();
        volume = this.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out cgLayer);
        //imageToFade.gameObject.SetActive(false);
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
        //Debug.Log("cgLayer value = " + cgLayer.postExposure.value);

        //controlsImage.gameObject.SetActive(true);
        volume.profile = darkProfile;
        /*
        //cgLayer.postExposure.overrideState = true;
        Mathf.Lerp(currentVal, -15, lerpRate);
        cgLayer.postExposure.Override(currentVal);
        cgLayer.postExposure.value = currentVal;




        foreach(Light light in lights)
        {
            Mathf.Lerp(light.intensity, 0, 0.05f);
        }

        */

        //Debug.Log(currentVal);
        /*if (!imageToFade.gameObject.activeSelf)
        {
            imageToFade.gameObject.SetActive(true);
        }*/
        //Mathf.Lerp(imageToFade.color.a, 1, lerpRate);

        /*Color newColor = new Color(0, 0, 0, Mathf.Lerp(imageToFade.color.a, 1f, lerpRate));
        imageToFade.color = newColor;
        */
        //if (imageToFade.color.a < 0.95)

        //Debug.Log(imageToFade.color.a);
        
        
    }

    public void FromDarkToLight()
    {
        //Debug.Log("Fading to transparent");
        //controlsImage.gameObject.SetActive(false);
        volume.profile = regularProfile;
        //Mathf.Lerp(cgLayer.postExposure.value, 0, lerpRate);

        //Mathf.Lerp(imageToFade.color.a, 0, lerpRate); 

        /*Color newColor = new Color(0, 0, 0, Mathf.Lerp(imageToFade.color.a, 0f, lerpRate));
        imageToFade.color = newColor;
        */
        //if (imageToFade.color.a <= 0.05)
        /*
        if(cgLayer.postExposure.value <= -0.5)
        {
            //imageToFade.gameObject.SetActive(false);
            return false;
        } else { return true; }
        */
    }

    public IEnumerator DarthFader()
    {
        FromLightToDark();
        yield return new WaitForSeconds(fadeTime) ;
        FromDarkToLight();
    }
}
