using UnityEngine;
using System.Collections.Generic;
using System.Collections;

// SOUND ID BANK
public enum SoundClipId
{
    ERROR,
    SFX_POP,
    SFX_BUTTON_CLICK,
    SFX_TILE_ACTIVE,
    SFX_UPGRADE,
    SFX_STONE_BTN,
    SFX_STONE_SLIDE_LONG,
    SFX_SHUTTER,
    SFX_GLITCH_1,
    SFX_GLITCH_2,
    SFX_GLITCH_3,

    SFX_POSTIVE_1,
    SFX_POSTIVE_2,

    SFX_COMPUTER_ON,
    SFX_COMPUTER_BOOT,
    SFX_COMPUTER_BEEP,

    SFX_DRUM_HIT,
    SFX_SWOOSH,
    SFX_WIZARD,

    MUS_WELCOME,
    MUS_FANFAIR,
    MUS_CLEVER,
    MUS_VOX,
    MUS_CONAN,
    MUS_BACKGROUND_4,
    MUS_BACKGROUND_5,
    MUS_BACKGROUND_6,


    MUS_GLITCH,

    MUS_ERROR,


    MUS_BACKGROUND_1,
    MUS_BACKGROUND_2,
    MUS_BACKGROUND_3,
    SFX_FOOTSTEP_GRASS,
    SFX_THUNDER,
    SFX_MENU_CLICK,
    SFX_WIND_HOWL,
    SFX_FOOTSTEP_GROUND,
    SFX_VICTORY
}

/// <summary>
/// enum states for Mama Hawk's burden state
/// </summary>
/*public enum WorldType {
	LOBBY,
	GARDEN,
	FOREST,
	FOREST_2,
	MOUNTAINS,
	GARDEN_2,
	GARDEN_1,
	INTRO,
	MOUNTAINS_2,
	GARDEN_3,
	MARSH,
	HIGHLANDS
}*/

public class AudioController : MonoBehaviour
{
    Dictionary<SoundClipId, string> clips;

    //Dictionary<WorldType, SoundClipId> worldMusic;


    private static readonly string PrefKey_MuteSFX = "muteSFX";
    private static readonly string PrefKey_MuteBGM = "muteBGM";

    static private bool _muteBGM = false;
    static private bool _muteSFX = false;

    private static AudioController singleton;

    static float bgmVol;

    string preveusBgMusic;
    string currentMusic;

    public AudioSource bgm;

    public static AudioController getSingleton()
    {
        if (singleton == null)
        {

            GameObject go = new GameObject("| AudioController |");
            singleton = go.AddComponent<AudioController>();
            singleton.TryInit();

        }

        return singleton;
    }

    void Start()
    {

        if (singleton != this)
        {
            Debug.LogError("Extra Audio Controller: " + gameObject.name, gameObject);
            Destroy(this);
        }
    }

    void TryInit()
    {

        DontDestroyOnLoad(gameObject);

        /*
			 * CHECK USER PREFS
			 */
        //_muteBGM = PlayerPrefsUtil.readBoolPref(PrefKey_MuteBGM, false); // isIntTrue(PlayerPrefs.GetInt("muteBGM" , 0));
        //_muteSFX = PlayerPrefsUtil.readBoolPref(PrefKey_MuteSFX, false);



        if (_muteBGM)
        {
            bgmVol = 0.0f;
        }
        else
        {
            bgmVol = 1.0f;
        }


        this.SetupSoundClips();
        singleton = this;


        // if not first run

        //PlaySoundWithCallback( SoundClipId.MUS_WELCOME , AudioFinished);


        //PlayBGSoundClip(SoundClipId.MUS_BACKGROUND_1);

    }

    public void StartMainBackgroundMusic()
    {

        PlaySoundWithCallback(SoundClipId.MUS_WELCOME, AudioFinished);
    }

    public void StartIntroMusic()
    {
        PlaySoundWithCallback(SoundClipId.MUS_BACKGROUND_6, AudioFinished);
    }

    void SetupSoundClips()
    {

        /*worldMusic = new Dictionary<WorldType, SoundClipId> ();

		worldMusic.Add( WorldType.INTRO, SoundClipId.MUS_BACKGROUND_3 );
		worldMusic.Add( WorldType.GARDEN_1, SoundClipId.MUS_BACKGROUND_1 );
		worldMusic.Add( WorldType.GARDEN_2, SoundClipId.MUS_BACKGROUND_1 );
		worldMusic.Add( WorldType.GARDEN_3, SoundClipId.MUS_BACKGROUND_4 ); // Aatum hills level
		worldMusic.Add( WorldType.FOREST, SoundClipId.MUS_BACKGROUND_5 );
		worldMusic.Add( WorldType.FOREST_2, SoundClipId.MUS_BACKGROUND_5 );


		worldMusic.Add( WorldType.MOUNTAINS_2, SoundClipId.MUS_BACKGROUND_2 );

		worldMusic.Add( WorldType.MARSH, SoundClipId.MUS_BACKGROUND_3 );
		worldMusic.Add( WorldType.HIGHLANDS, SoundClipId.MUS_BACKGROUND_4 );

*/

        clips = new Dictionary<SoundClipId, string>();


        clips.Add(SoundClipId.ERROR, "audio/sfx/050148855-bubble-pop-button-2");
        clips.Add(SoundClipId.SFX_POP, "audio/sfx/050148855-bubble-pop-button-2");
        clips.Add(SoundClipId.SFX_BUTTON_CLICK, "audio/sfx/025029147-perfect-click-button-sfx");
        clips.Add(SoundClipId.SFX_UPGRADE, "audio/sfx/056721199-unlock");
        clips.Add(SoundClipId.SFX_TILE_ACTIVE, "audio/sfx/052908111-sweet-button-click-5");
        clips.Add(SoundClipId.SFX_STONE_BTN, "audio/sfx/051451795-move-stone");
        clips.Add(SoundClipId.SFX_STONE_SLIDE_LONG, "audio/sfx/024968596-stone-slide_part");
        clips.Add(SoundClipId.SFX_SHUTTER, "audio/sfx/shutter");
        clips.Add(SoundClipId.SFX_GLITCH_1, "audio/sfx/Distortion_3");
        clips.Add(SoundClipId.SFX_GLITCH_2, "audio/sfx/Glitch_Fade");
        clips.Add(SoundClipId.SFX_GLITCH_3, "audio/sfx/Glitch Static");
        clips.Add(SoundClipId.SFX_COMPUTER_BOOT, "audio/sfx/Boot - SOUND EFFECT - Reboot Start");
        clips.Add(SoundClipId.SFX_COMPUTER_ON, "audio/sfx/Computer_Magic-Microsift-1901299923");
        clips.Add(SoundClipId.SFX_COMPUTER_BEEP, "audio/sfx/Beep-SoundBible.com-923660219");
        clips.Add(SoundClipId.SFX_DRUM_HIT, "audio/sfx/84346__sandyrb__ss-boom-01");
        clips.Add(SoundClipId.SFX_SWOOSH, "audio/sfx/swoosh");
        clips.Add(SoundClipId.SFX_WIZARD, "audio/sfx/074718218-victory-award-prize-sound");
        clips.Add(SoundClipId.SFX_POSTIVE_1, "audio/sfx/Positive_07");
        clips.Add(SoundClipId.SFX_POSTIVE_2, "audio/sfx/Positive_06");




        clips.Add(SoundClipId.MUS_WELCOME, "audio/music/Largo");
        clips.Add(SoundClipId.MUS_FANFAIR, "audio/music/bartok_fanfair");
        clips.Add(SoundClipId.MUS_CLEVER, "audio/music/bartok_clever");
        clips.Add(SoundClipId.MUS_VOX, "audio/music/VoxHumana");
        //clips.Add( SoundClipId.MUS_BACKGROUND_5, "audio/music/SaturnoWarmUp");


        clips.Add(SoundClipId.MUS_BACKGROUND_1, "audio/music/Waltz_of_the_Flowers_life_getting_to_work");
        clips.Add(SoundClipId.MUS_BACKGROUND_2, "audio/music/Waltz_of_the_Flowers_life_begans");
        clips.Add(SoundClipId.MUS_BACKGROUND_3, "audio/music/The_Moldau");
        clips.Add(SoundClipId.MUS_BACKGROUND_4, "audio/music/debussy");
        clips.Add(SoundClipId.MUS_BACKGROUND_5, "audio/music/RavelBolero");
        clips.Add(SoundClipId.MUS_CONAN, "audio/music/Jupiter_dance_hall");
        clips.Add(SoundClipId.MUS_GLITCH, "audio/music/Distortion_Hum");
        clips.Add(SoundClipId.MUS_BACKGROUND_6, "audio/music/microtonal-music-by-prent-rodgers_at-the-terminus-of-the-blue");

        /*clips.Add( SoundClipId.MUS_BACKGROUND_2, "Sounds/music/Autumn Day");
		clips.Add( SoundClipId.MUS_BACKGROUND_3, "Sounds/music/montauk_point_short");


		clips.Add( SoundClipId.MUS_BACKGROUND_4, "Sounds/music/fretless_short");
		clips.Add( SoundClipId.MUS_BACKGROUND_5, "Sounds/music/Porch Swing Days - faster");

		clips.Add( SoundClipId.MUS_ERROR, "Sounds/music/carpe_diem_short");

		clips.Add( SoundClipId.MUS_WINNING, "Sounds/music/Blue_Danube_by_Strauss");
		clips.Add( SoundClipId.MUS_ANIMAL_SIGHTED, "Sounds/music/Untitled Rhythm_short");
	*/



    }
    /*
    public void muteSFX(bool setMuteSFX)
    {
        if (setMuteSFX == _muteSFX)
        {
            return;
        }
        //if(_muteSFX)
        _muteSFX = setMuteSFX;
        PlayerPrefsUtil.writeBoolPref(PrefKey_MuteSFX, _muteSFX);
        if (!_muteSFX)
        {
            // let user know sound effects are one
            AudioController.getSingleton().PlaySFX("Sounds/Tiny Button Push-SoundBible.com-513260752");
        }

        //sync ();
    }

    public void muteBGM(bool setMuteBGM)
    {
        if (setMuteBGM == _muteBGM)
        {
            return;
        }
        //if(_muteSFX)
        _muteBGM = setMuteBGM;
        PlayerPrefsUtil.writeBoolPref(PrefKey_MuteBGM, _muteBGM);
        if (!_muteBGM)
        {
            // let user know sound effects are one
            AudioController.getSingleton().PlaySFX("Sounds/Tiny Button Push-SoundBible.com-513260752");
        }

        sync();
    }
    */
    public bool getMuteSFX()
    {
        return _muteSFX;
    }

    public bool getMuteBGM()
    {
        return _muteBGM;
    }


    void OnDestroy()
    {
        if (singleton == this)
        {
            singleton = null;
        }
    }

    public void PlaySFX(string url, float volume = 1.0f, float pitch = 1.0f, float delay = 0)
    {
        StartCoroutine(CoroutinePlaySFX(url, volume, pitch, delay));
    }

    public void PlaySFX(SoundClipId id, float volume = 1.0f, float pitch = 1.0f, float delay = 0)
    {
        // Get url based on key
        string url = GetSoundClip(id);


        StartCoroutine(CoroutinePlaySFX(url, volume, pitch, delay));
    }

    public void PlaySFXIfOnScreen(SoundClipId id, GameObject go, float volume = 1.0f, float pitch = 1.0f, float delay = 0)
    {

        // Re-write?

    }

    public void PlaySFXRandomFromArray(string[] arrayOfUrls, float volume = 1.0f, float pitch = 1.0f, float delay = 0)
    {

        string name = arrayOfUrls[Random.Range(0, arrayOfUrls.Length)];
        AudioController.getSingleton().PlaySFX(name, volume, pitch, delay);
    }

    string GetSoundClip(SoundClipId id)
    {

        string url;

        if (clips.ContainsKey(id))
        {
            url = clips[id];
        }
        else
        {
            Debug.LogError("Sound not found id= " + id);
            url = clips[SoundClipId.ERROR];
        }

        return url;
    }

    /*	public SoundClipId GetWorldMusic (WorldType id)
        {

            SoundClipId url;

            if (worldMusic.ContainsKey (id)) {
                url = worldMusic [id];
            } else {
                Debug.LogError ("Sound not found id= " + id);
                url = SoundClipId.MUS_ERROR;
            }

            return url;
        }*/

    IEnumerator CoroutinePlaySFX(string url, float volume, float pitch, float delay)
    {
        //stuff
        yield return new WaitForSeconds(Time.timeScale * delay);

        if (_muteSFX)
        {
            // It's muted
            //return;
        }
        else
        {

            AudioClip ac = Resources.Load(url) as AudioClip;

            if (ac == null)
            {

                Debug.Log("MISSING Sound effect url");
                //return;
            }
            else
            {

                GameObject sfx = new GameObject(); // create the temp object
                sfx.transform.position = Vector3.zero; // set its position
                AudioSource aSource = sfx.AddComponent<AudioSource>(); // add an audio source
                aSource.clip = ac; // define the clip
                aSource.volume = volume;
                aSource.Play(); // start the sound
                aSource.pitch = pitch;
                DontDestroyOnLoad(sfx);
                Destroy(sfx, ac.length + 0.5f); // destroy object after clip duration
            }
        }
    }


    public string getPreveusBGMusic()
    {
        return preveusBgMusic;
    }

    //static GameObject this;
    public void PlayBGSoundClip(SoundClipId id, float volume = 1.0f, bool loop = true, float startTime = 0)
    {

        string url = GetSoundClip(id);

        PlayBG(url, volume, loop, startTime);
    }


    public void PlayBG(string url, float volume = 1.0f, bool loop = true, float startTime = 0)
    {
        //if(bgm.clip != null)

        preveusBgMusic = currentMusic;
        currentMusic = url;

        AudioClip ac = Resources.Load(url) as AudioClip;

        if (ac == null)
        {

            Debug.Log("MISSING Sound effect url");
            return;
        }




        //bg = new GameObject(); // create the temp object
        //bg.transform.position = Vector3.zero; // set its position
        //bgm = bgm; // add an audio source
        if (bgm == null)
        {
            bgm = this.gameObject.AddComponent<AudioSource>();
        }


        // save preveus trake

        //}

        bgm.clip = ac; // define the clip
        bgm.loop = loop;
        bgm.time = startTime;
        bgm.volume = (_muteBGM) ? 0.0f : bgmVol;
        bgm.Play(); // start the sound
                    //DontDestroyOnLoad(bg);

        //Destroy(sfx, ac.length + 0.5f); // destroy object after clip duration
    }



    public SoundClipId GetSoundIdForBackgroundMusic()
    {

        SoundClipId id;
        //if (){//gamestate) {
            id = SoundClipId.MUS_BACKGROUND_1;

        //}

        /*
            // Assention music
        if (GameController.instance.uiAscention.activeInHierarchy || GameController.instance.welcome.gameObject.activeInHierarchy)
        {
            id = SoundClipId.MUS_BACKGROUND_6;
            return id;
        }




        if (ItemInfo.findItem(ItemDefs.TECH_EMERGENT_TECHNOLIGY).purchased)
        {
            id = SoundClipId.MUS_BACKGROUND_3; //SoundClipId.MUS_BACKGROUND_6;
        }
        else if (ItemInfo.findItem(ItemDefs.TECH_SURVIVAL).purchased)
        {

            //id = SoundClipId.MUS_BACKGROUND_4;
            id = SoundClipId.MUS_BACKGROUND_3;
        }
        else if (ItemInfo.findItem(ItemDefs.ITEM_MONKEY).purchased)
        {

            id = SoundClipId.MUS_BACKGROUND_5;
        }
        else if (ItemInfo.findItem(ItemDefs.ITEM_LIZARD).purchased)
        {

            id = SoundClipId.MUS_BACKGROUND_5;  // Satern // Boli

        }
        else if (ItemInfo.findItem(ItemDefs.ITEM_SPONGE).purchased)
        {

            id = SoundClipId.MUS_BACKGROUND_4; // Debussy
        }
        else if (ItemInfo.findItem(ItemDefs.ITEM_AMINO_ACID).purchased)
        {

            id = SoundClipId.MUS_BACKGROUND_1;
        }
        else
        {

            id = SoundClipId.MUS_BACKGROUND_2;
        }

        */

        // When a click end what should the next song be

        // There should be defuluts for sgmenets of the game 
        // But then when a spcial effent happens we need to be able to play that song.


        return id;
    }

    /*
    public void PlayBGInterlude(SoundClipId id)
    {

        PlaySoundWithCallback(id, AudioFinished);
    }
    */
    Coroutine audioCallBackCoroutine = null;

    public delegate void AudioCallback();
    public void PlaySoundWithCallback(SoundClipId clipId, AudioCallback callback)
    {
        PlayBGSoundClip(clipId);

        if (audioCallBackCoroutine != null)
        {
            StopCoroutine(audioCallBackCoroutine);
        }

        audioCallBackCoroutine = StartCoroutine(DelayedCallback(bgm.clip.length, callback));
    }
    private IEnumerator DelayedCallback(float time, AudioCallback callback)
    {

        yield return StartCoroutine(WaitForRealSeconds(time));

        //yield return new WaitForSeconds(time);
        callback();
    }

    public static IEnumerator WaitForRealSeconds(float delay)
    {
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + delay)
        {
            yield return null;
        }
    }

    void AudioFinished()
    {

        PlaySoundWithCallback(GetSoundIdForBackgroundMusic(), AudioFinished);

        //GetSoundIdForBackgroundMusic


        Debug.Log("Audio Done!");
    }


    public void StopBG()
    {
        if (bgm)
        {
            bgm.Stop();
        }

        if (audioCallBackCoroutine != null)
        {
            StopCoroutine(audioCallBackCoroutine);
        }
        audioCallBackCoroutine = null;
        //if(bg){

        //Destroy(bg);
        //}
    }

    void sync()
    {
        bgmVol = (_muteBGM) ? 0.0f : 1.0f;
        bgm.volume = bgmVol;
    }


    /*
	 * AD HOOKS
	 */
    float volBeforeAd;
    public void AdStart()
    {

        volBeforeAd = bgm.volume;
        bgmVol = 0;
        bgm.volume = bgmVol;
    }

    public void AdFinished()
    {

        bgmVol = volBeforeAd;
        bgm.volume = bgmVol;
    }
}