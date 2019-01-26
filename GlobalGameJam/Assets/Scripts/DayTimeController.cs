using UnityEngine;

public class DayTimeController:MonoBehaviour
{
    float currentTime=0.0f;

    //The current stop time is 120 second or 2 minutes.
    //Once two minutes passes and the player has not found the desired animal, the game is over/restarts.
    //We can change this later if need be.
    const float stopTime=120.0f;

    [SerializeField]
    Light dayTimeLight;

    //This will update the daytime from light to dark.
    void Update()
    {
        UpdateDayTime();
    }

    //This is the main function that will update the daytime.
    //The daytime is determined by the intensity of the player's directional light.
    void UpdateDayTime()
    {
        currentTime+=Time.deltaTime;

        dayTimeLight.intensity=1.0f-currentTime/stopTime;

        //Two minutes has passed and thus it is game over.
        //We reset values so the player can start over.
        if(currentTime>=120.0f)
        {
            ResetDayTime();
        }
    }

    void ResetDayTime()
    {
        currentTime=0.0f;
        dayTimeLight.intensity=1.0f;
    }
}
