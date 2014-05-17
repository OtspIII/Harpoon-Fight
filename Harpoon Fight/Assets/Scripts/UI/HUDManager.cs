using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour
{

    public UI2DSprite Hands;
    public UILabel YOUDIED;

    public HandsState State { get; private set; }
    public Sprite Loaded;
    public Sprite Unloaded;
    public Sprite Reloading;

    // Use this for initialization
    void Start()
    {
        State = HandsState.Loaded;
        YOUDIED.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetHandsState(HandsState state)
    {
        State = state;
        YOUDIED.gameObject.SetActive(false);
        Hands.gameObject.SetActive(true);
        switch (state)
        {
            case HandsState.Loaded:
                Hands.sprite2D = Loaded;
                break;
            case HandsState.Empty:
                Hands.sprite2D = Unloaded;
                break;
            case HandsState.Reloading:
                Hands.sprite2D = Reloading;
                break;
            case HandsState.Dead:
                YOUDIED.gameObject.SetActive(true);
                Hands.gameObject.SetActive(false);
                break;
        }
    }
}

public enum HandsState
{
    Loaded,
    Empty,
    Reloading,
    Dead
}
