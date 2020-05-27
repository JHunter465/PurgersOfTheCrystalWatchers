using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace POTCW
{
    public class BoostEmision : MonoBehaviour
    {
        public Color EmisionColor;
        public float EmisionValue = 14f;
        public Material Material;

        protected Renderer renderer;
        float t = 0;

        private void Start()
        {
            EventManager<Color>.AddHandler(EVENT.SpecialAttackFeedback, UpdateEmision);
        }

        public void UpdateEmision(Color color)
        {
            t = 0;
            Debug.Log("Update EmisionColor");
            Material.SetColor("_EmissiveColor", color * EmisionValue);
            //RendererExtensions.UpdateGIMaterials(Material)
            //StartCoroutine(LerpEmision(color, 14));
        }

        private IEnumerator LerpEmision(Color color, float value)
        {
            t += 0.5f * Time.deltaTime;
            EmisionValue = Mathf.Lerp(EmisionValue, value, t);
            Material.SetColor("_EmissiveColor", color * EmisionValue);
            yield return new WaitForSeconds(value);
        }

    }
}
