using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;

    //[SerializeField]
    //Dropdown resolutionDropdown;

    //[SerializeField]
    //Dropdown qualityDropdown;

    [SerializeField]
    Slider volumeSlider;

    //[SerializeField]
    //Toggle fullScreenToggle;

    //Resolution[] resolutions;
    SessionManagerController sessionManager;

    void Awake()
    {
        sessionManager = SessionManagerController.GetInstancia() as SessionManagerController;
    }

    void Start()
    {
        //resolutions = Screen.resolutions;
        //List<string> options = new List<string>();
        //int currentOption = 0, optionCount =0;

        //Array.ForEach
        //    (
        //        resolutions,
        //        resolution =>
        //        {
        //            options.Add(resolution.width + " x " + resolution.height);
        //            if
        //                (
        //                    resolution.width == Screen.currentResolution.width &&
        //                    resolution.height == Screen.currentResolution.height
        //                )
        //            {
        //                currentOption = optionCount;
        //            }
        //            optionCount++;
        //        }
        //    );

        //resolutionDropdown.ClearOptions();
        //resolutionDropdown.AddOptions(options);
        //resolutionDropdown.value = currentOption;
        //resolutionDropdown.RefreshShownValue();

        //optionCount = 0;
        //options = new List<string>();
        //foreach (string name in QualitySettings.names)
        //{
        //    options.Add(name);
        //    if (optionCount == QualitySettings.GetQualityLevel())
        //    {
        //        currentOption = optionCount;
        //    }
        //    optionCount++;
        //}

        //qualityDropdown.ClearOptions();
        //qualityDropdown.AddOptions(options);
        //qualityDropdown.value = currentOption;
        //qualityDropdown.RefreshShownValue();

        float volume = 0F;
        audioMixer.GetFloat("volume", out volume);
        volumeSlider.value = volume;

        //fullScreenToggle.isOn = Screen.fullScreen;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    //public void SetFullScreen(bool isFullScreen)
    //{
    //    Screen.fullScreen = isFullScreen;
    //}

    //public void SetResolution(int index)
    //{
    //    Resolution resolution = resolutions[index];
    //    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    //}

    //public void SetQuality(int quality)
    //{
    //    QualitySettings.SetQualityLevel(quality);
    //}

    //public void Save()
    //{
    //    Level level =
    //        new Level
    //        {
    //            Scene = SceneManager.GetActiveScene().buildIndex,
    //            Score = sessionManager.GetScore()
    //        };

    //    BrickController[] bricks = FindObjectsOfType<BrickController>();
    //    Array.ForEach
    //        (
    //            bricks,
    //            brick =>
    //            {
    //                level.Bricks.Add
    //                    (
    //                        new Level.Brick
    //                        {
    //                            BrickType = brick.GetBrickType(),
    //                            Sprite = brick.GetSprite(),
    //                            Position = brick.transform.position,
    //                            Rotation = brick.transform.rotation,
    //                            HitsCount = brick.GetHitsCount(),
    //                            BreakSounds = brick.GetBreakSounds(),
    //                            DamageSprites = brick.GetDamageSprites()
    //                        }
    //                    ); ;
    //            }
    //        );
    //    level.Save();
    //}

    //public void Load()
    //{
    //    Level level = Level.Load();
    //    BrickController[] bricks = FindObjectsOfType<BrickController>();
    //    Array.ForEach
    //        (
    //            bricks,
    //            brick => Destroy(brick.gameObject)
    //        );
    //    sessionManager.ResetScore();
    //    sessionManager.AddScore(level.Score);

    //    Transform[] transforms = FindObjectsOfType<Transform>();
    //    Transform parent = null;

    //    Array.ForEach
    //        (
    //            transforms,
    //            t =>
    //            {
    //                if (t.gameObject.name == "Bricks")
    //                {
    //                    parent = t;
    //                }
    //            }
    //        );

    //    level.Bricks.ForEach
    //        (
    //            brick =>
    //            {
    //                GameObject instancia = Instantiate(brickPrefab, brick.Position, brick.Rotation, parent);
    //                BrickController controller = instancia.GetComponent<BrickController>();

    //                controller.SetBrickType(brick.BrickType);
    //                controller.SetSprite(brick.Sprite);
    //                controller.SetBreakSounds(brick.BreakSounds);
    //                controller.SetDamageSprites(brick.DamageSprites);
    //                controller.SetHitsCount(brick.HitsCount);
    //            }
    //        );
    //}
}
