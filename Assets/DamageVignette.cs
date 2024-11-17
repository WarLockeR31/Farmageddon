using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DamageVignette : MonoBehaviour
{
    [SerializeField]
    private float maxIntensity; 

    [SerializeField]
    private float pause;


    private float intensity = 0f;

    PostProcessVolume _volume;
    Vignette _vignette;

    [SerializeField]
    private Shake shake;
    public Shake Shake { get { return shake; } }

    private static DamageVignette instance;
    private void Awake()
    {
        instance = this;
    }
    public static DamageVignette getInstance()
    {
        if (instance == null)
        {
            instance = new DamageVignette();
        }
        return instance;
    }


    // Start is called before the first frame update
    void Start()
    {
        _volume = GetComponent<PostProcessVolume>();

        _volume.profile.TryGetSettings(out _vignette);

        if (!_vignette)
        {
            Debug.Log("Error, vignette empty");
        }
        else
        {
            _vignette.enabled.Override(false);
        }
    }

    public void DamageTaken()
    {
        StopAllCoroutines();
        StartCoroutine(TakeDamageEffect());
    }

    IEnumerator TakeDamageEffect()
    {
        intensity = maxIntensity;

        _vignette.enabled.Override(true);
        _vignette.intensity.Override(maxIntensity);

        yield return new WaitForSeconds(pause);

        while (intensity > 0f)
        {
            intensity -= 0.01f;

            if (intensity < 0f)
                intensity = 0f;

            _vignette.intensity.Override(intensity);

            yield return new WaitForEndOfFrame();
        }

        _vignette.enabled.Override(false);
        yield break;
    }
}
