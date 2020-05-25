using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LerpEffectValue : MonoBehaviour
{
    [SerializeField] private float start, end, time, backEnd, backTime;

    private VisualEffect effect;

    // Start is called before the first frame update
    void OnEnable()
    {
        effect = GetComponent<VisualEffect>();
        StartCoroutine(lerpSize(start,end, time));
    }

    public IEnumerator lerpSize(float start, float end, float LerpTime)
    {
        float StartTime = Time.time;
        float EndTime = StartTime + LerpTime;

        while (Time.time < EndTime)
        {
            float timeProgressed = (Time.time - StartTime) / LerpTime;  // this will be 0 at the beginning and 1 at the end.
            effect.SetFloat("Size", Mathf.Lerp(start, end, timeProgressed));

            yield return new WaitForFixedUpdate();
        }
        effect.SetFloat("Size", end);

        StartCoroutine(lerpSize(end, backEnd, backTime));
    }
}
