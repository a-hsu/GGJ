using UnityEngine;

public class DayTimeController:MonoBehaviour
{
    bool dayTimeActive = true;

    static float currentTime=0.0f;

    //The current stop time is 120 second or 2 minutes.
    //Once two minutes passes and the player has not found the desired animal, the game is over/restarts.
    //We can change this later if need be.
    const float stopTime=120.0f;

    [SerializeField]
    static Light dayTimeLight;

    private void Awake()
    {
        dayTimeLight = GetComponent<Light>();
    }

    //This will update the daytime from light to dark.
    void Update()
    {
        UpdateDayTime();
    }

    //This is the main function that will update the daytime.
    //The daytime is determined by the intensity of the player's directional light.
    void UpdateDayTime()
    {
        if (dayTimeActive && currentTime < 120.0f)
        {
            currentTime += Time.deltaTime;

            dayTimeLight.intensity = 1.0f - currentTime / stopTime;
        }
    }

    public static void ResetDayTime()
    {
        currentTime=0.0f;
        dayTimeLight.intensity=1.0f;
    }

    public static float getCurrentTime()
    {
        return currentTime;
    }
}
