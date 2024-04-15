using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    private int maxSamples = 20;
    private float updateInterval = 0.02f;
    [SerializeField]
    private Text _text;

    private void Start()
    {
        StartCoroutine(UpdateFPSCounter());
    }

    private IEnumerator UpdateFPSCounter()
    {
        List<int> fpsSamples = new List<int>();

        while (true)
        {
            if(fpsSamples.Count > maxSamples)
            {
                _text.text = ((int)fpsSamples.Average()).ToString();
                fpsSamples.Clear();
            }

            fpsSamples.Add((int)(1f / Time.unscaledDeltaTime));
            
            yield return new WaitForSeconds(updateInterval);
        }
    }
}
