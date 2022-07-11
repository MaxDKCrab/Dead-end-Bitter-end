using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{

    [SerializeField] private Animator SettingsAnim;
    [SerializeField] private Animator OptionsMenuAnim;
    private PlayerHealthManager healthManager;
    [HideInInspector] public bool inMenu;
    private MouseLook fpsView;
    private Movement playerMove;
    private bool inSettings;
    public Image checkBox1920x1080;
    public Image checkBox1600x900;
    public Image checkBox2560x1440;
    public Image checkBoxFullscreen;
    public Image checkBoxWindowed;
    public Sprite checkedBox;
    public Sprite uncheckedBox;
    private FMOD.Studio.EventInstance pauseSnapshot;

    private void Start()
    {
        playerMove = FindObjectOfType<Movement>();
        healthManager = FindObjectOfType<PlayerHealthManager>();
        fpsView = FindObjectOfType<MouseLook>();
        Screen.SetResolution(1920,1080,Screen.fullScreen);
        pauseSnapshot = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Esq M");
        Screen.fullScreen = true;
        
    }

    private void Update()
    {
        if (Screen.fullScreen)
        {
            checkBoxWindowed.sprite = uncheckedBox;
            checkBoxFullscreen.sprite = checkedBox;
        }
        else
        {
            checkBoxWindowed.sprite = checkedBox;
            checkBoxFullscreen.sprite = uncheckedBox;
        }
        
        if (Screen.currentResolution.width == 1920)
        {
            checkBox1920x1080.sprite = checkedBox;
            checkBox1600x900.sprite = uncheckedBox;
            checkBox2560x1440.sprite = uncheckedBox;
        }
        else if (Screen.currentResolution.width == 1600)
        {
            checkBox1920x1080.sprite = uncheckedBox;
            checkBox1600x900.sprite = checkedBox;
            checkBox2560x1440.sprite = uncheckedBox;
        }
        else
        {
            checkBox1920x1080.sprite = uncheckedBox;
            checkBox1600x900.sprite = uncheckedBox;
            checkBox2560x1440.sprite = checkedBox;
        }
        
        
        
        if (Input.GetKeyDown(KeyCode.Escape) && !inMenu)
        {
            OpenMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && inMenu && !inSettings)
        {
            Time.timeScale = 1;
            pauseSnapshot.stop(STOP_MODE.IMMEDIATE);
            inMenu = false;
            fpsView.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Zoop");
            SettingsAnim.SetTrigger("CloseMenu");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && inMenu && inSettings)
        {
            inSettings = false;
            OptionsMenuAnim.SetTrigger("CloseSettings");
            FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Zoop");
            SettingsAnim.SetTrigger("OpenState");
        }
    }

    private void OpenMenu()
    {
        //pause the game
        Time.timeScale = 0;
        pauseSnapshot.start();
        // do sound snapshot
        
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Zoop");
        
        // bring up options
        inMenu = true;
        fpsView.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        SettingsAnim.SetTrigger("OpenMenu");

    }
    

    public void ResumeButton()
    {
        // unpause game
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        Time.timeScale = 1;
        pauseSnapshot.stop(STOP_MODE.IMMEDIATE);
        
        // do sound snapshot
        
        //close options
        inMenu = false;
        fpsView.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        SettingsAnim.SetTrigger("CloseMenu");
    }

    public void MainMenuButton()
    {
        //send player to MainMenu
        Time.timeScale = 1;
        inMenu = false;
        pauseSnapshot.stop(STOP_MODE.IMMEDIATE);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Vol Music", 0);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        SceneManager.LoadScene(0);
    }

    public void OptionsMenuButton()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        //Close options and open new object
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Zoop");
        SettingsAnim.SetTrigger("SettingsTime");
        OptionsMenuAnim.SetTrigger("OpenSettings");
        inSettings = true;
        //Dont unpause or boot out of menu
    }

    public void Resolution1920x1080()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        Screen.SetResolution(1920,1080, Screen.fullScreen);
    }
    public void Resolution1600x900()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        Screen.SetResolution(1600,900, Screen.fullScreen);
    }
    public void Resolution2560x1440()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        Screen.SetResolution(2560,1440, Screen.fullScreen);
    }
    public void Fullscreen()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        Screen.fullScreen = true;
    }
    public void Windowed()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        Screen.fullScreen = false;
    }


    public void SetVolumeMaster(float master)
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Vol Master", master);
    }
    public void SetVolumeMusic(float music)
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Vol Music", music);
    }
    public void SetVolumeAmbience(float ambience)
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Vol Ambiens", ambience);
    }
    public void SetVolumeVehicle(float vehicle)
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Vol Vehicle", vehicle);
    }

    

    public void RespawnButton()
    {
        ResumeButton();
        healthManager.Death();
        StopAllCoroutines();
        StartCoroutine(DelayedDeath());
    }

    private IEnumerator DelayedDeath()
    {
        playerMove.enabled = false;
        yield return new WaitForSeconds(0.5f);
        healthManager.Death();
        playerMove.enabled = true;
    }

}
