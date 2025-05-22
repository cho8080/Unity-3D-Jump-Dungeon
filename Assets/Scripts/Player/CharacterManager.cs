using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager _instance;
    public static CharacterManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gameObject = new GameObject("CharacterManager");
                _instance = gameObject.AddComponent<CharacterManager>();
                DontDestroyOnLoad(gameObject);
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
    public PlayerStatus PlayerStatus
    {
        get { return _status; }
        set { _status = value; }
    }

    private Player _player;
    private PlayerStatus _status;
}
