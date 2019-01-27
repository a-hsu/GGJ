using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTester : MonoBehaviour
{
    public AudioController audio;
    // Start is called before the first frame update
    void Start()
    {
        AudioController.getSingleton().StartMainBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioController.getSingleton().PlaySFX(SoundClipId.SFX_BUTTON_CLICK, 1, 1, 0);
        }
    }
}
