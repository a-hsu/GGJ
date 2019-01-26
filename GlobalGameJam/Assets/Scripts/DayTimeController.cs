using UnityEngine;

public class DayTimeController:MonoBehaviour
{
    float currentTime;

    //The current stop time is 120 second or 2 minutes.
    //Once two minutes passes and the player has not found the desired animal, the game is over/restarts.
    //We can change this later if need be.
    const float stopTime = 120.0f;

    public Light dayTimeLight;

    DayTime currentDayTime;

    enum DayTime
    {
       DAY,
       NIGHT
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime=0.0f;
        currentDayTime=DayTime.DAY;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDayTime();
    }

    void UpdateDayTime()
    {
        currentTime += Time.deltaTime;

        dayTimeLight.intensity = 1.0f - currentTime / stopTime;

        //Two minutes has passed and thus it is game over.
        if (currentTime >= 120.0f)
        {

        }
    }
}
