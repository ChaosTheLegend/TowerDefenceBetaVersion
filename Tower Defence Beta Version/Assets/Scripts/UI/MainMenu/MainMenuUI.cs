using System;
using System.Collections;
using System.Collections.Generic;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    private Button[] _buttons;

    private void Awake() => _buttons = GetComponentsInChildren<Button>();

    private void Start() => InitButtons(SinglePlayer, MultiPlayer, Quit);

    private void SinglePlayer()
    {
        Debug.Log("SinglePlayer");
        //TODO DO PANEL WITH SINGLE PLAYER SETTINGS;
    }

    private void MultiPlayer()
    {
        Debug.Log("MultiPlayer");
        //TODO DO PANEL WITH MULTI PLAYER LOBBY AND CONNECTION;
    }

    private void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    private void InitButtons(params UnityAction[] actions)
    {
        try
        {
            for (var i = 0; i < _buttons.Length; i++)
                _buttons[i].onClick.AddListener(actions[i]);
        }
        catch (Exception)
        {
            Debug.LogError("There are unsigned buttons.");
        }
    }
}