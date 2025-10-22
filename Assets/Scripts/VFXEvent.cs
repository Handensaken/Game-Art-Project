using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.VFX;

public class VFXEvent : MonoBehaviour
{
    [SerializeField]
    private VisualEffect visualEffect_swirl;

    [SerializeField]
    private VisualEffect visualEffect_ball;
    [SerializeField]
    private VisualEffect visualEffect_FinalEmbers;
      [SerializeField]
    private VisualEffect _heat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //  visualEffect.SendEvent(Shader.PropertyToID("Test"));
    }
    public void StartBibbidi()
    {
        visualEffect_swirl.enabled = true;
        visualEffect_swirl.SetFloat(Shader.PropertyToID("Size"), 150);

        visualEffect_swirl.SendEvent(Shader.PropertyToID("Swirl"));
        size = 0;
        _heat.enabled = true;
      //  _heat.SetFloat(Shader.PropertyToID("Distortion"), 0.015f);
        StartCoroutine(lerpDistortion(0f, 0.015f));


    }
    public void swirl2()
    {
      //  _heat.SetFloat(Shader.PropertyToID("Distortion"), 0.025f);

        StartCoroutine(lerpDistortion(0.015f, 0.025f));


        visualEffect_swirl.SendEvent(Shader.PropertyToID("Swirl"));
        visualEffect_swirl.SetFloat(Shader.PropertyToID("Size"), 215);
        //   visualEffect.SetFloat(Shader.PropertyToID("FireballSize"), 0.8f);
        visualEffect_swirl.SetFloat(Shader.PropertyToID("EmberSpawnRate"), 20);
        StartCoroutine(wait(0.5f, 0.8f));
    }
    public void SpawnFire()
    {
        StartCoroutine(wait(0, 0.5f));
        visualEffect_ball.enabled = true;


    }
    public void Condense()
    {
        visualEffect_swirl.SendEvent(Shader.PropertyToID("StopEmbers"));
        visualEffect_swirl.SetFloat(Shader.PropertyToID("SizeFuckoff"), 0);
        StartCoroutine(wait(0.5f, 0.2f));
       // visualEffect_ball.transform.parent = null;
        visualEffect_ball.SetBool(Shader.PropertyToID("Attract"), true);
    }



    float size;
    float f;

    private IEnumerator wait(float currentSize, float targetSize)
    {
        size = 0;
        f = 0;
        for (int i = 0; i < 1000; i++)
        {
            yield return new WaitForSeconds(0.001f);
            f += 0.004f;
            if (f > 1) f = 1;
            size = Mathf.Lerp(currentSize, targetSize, f);
            visualEffect_ball.SetFloat(Shader.PropertyToID("GlobalSize"), size);
        }
    }

    float distortion;
    private IEnumerator lerpDistortion(float currentSize, float targetSize)
    {
        f = 0;
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            f += 0.02f;
            distortion = Mathf.Lerp(currentSize, targetSize, f);
            _heat.SetFloat(Shader.PropertyToID("Distortion"), distortion);
        }
    }

    public void Gather()
    {
        // _heat.SetFloat(Shader.PropertyToID("Distortion"), 0.07f);
        StartCoroutine(lerpDistortion(0.025f, 0.07f));
//visualEffect_swirl.SetFloat(Shader.PropertyToID("HeatSize"), 50);
     //   visualEffect_swirl.SetFloat(Shader.PropertyToID("HeatDistortion"), 0.7f);
        visualEffect_FinalEmbers.enabled = true;
        Debug.Log("Gathering");
    }

    public void BOOM()
    {
        _heat.enabled = false;
        visualEffect_swirl.enabled = false;
        visualEffect_FinalEmbers.enabled = false;
        visualEffect_ball.enabled = false;

    }
}
