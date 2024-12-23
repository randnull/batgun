using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text waveText;
    public Text timeText;
    
    private int currWave = 1;
    private float remainingTime = 0f;
    
    void Update()
    {
        if (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimer();
        }
    }

    public void StartWave(int wave, float waveDuration)
    {
        currWave = wave;
        remainingTime = waveDuration;
        UpdateWave();
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timeText.text = remainingTime.ToString("0.00");
    }
    
    void UpdateWave()
    {
        waveText.text = "Волна " + currWave;   
    }
}