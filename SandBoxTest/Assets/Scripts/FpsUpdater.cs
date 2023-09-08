using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FpsUpdater : MonoBehaviour
{
    float fps;

    float updateTimer = 0.1f;

    [SerializeField] TextMeshProUGUI fpsTitle;
    // Start is called before the first frame update
    private void UpdateFPSDisplay()
    {
        updateTimer -= Time.deltaTime;
        if(updateTimer <= 0 )
        {
            fps = 1f / Time.unscaledDeltaTime;
            fpsTitle.text = "FPS: " + Mathf.Round(fps);
            updateTimer = 0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFPSDisplay();
    }
}
