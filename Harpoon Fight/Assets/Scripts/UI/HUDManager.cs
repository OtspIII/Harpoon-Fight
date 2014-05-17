using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour
{

    public UI2DSprite Hands;
    public HandsState State { get; private set; }
    public Sprite Loaded;
    public Sprite Unloaded;
    public Sprite Reloading;

    // Use this for initialization
    void Start()
    {
        State = HandsState.Loaded;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetHandsState(HandsState state)
    {
        State = state;
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
        }
    }
}

public enum HandsState
{
    Loaded,
    Empty,
    Reloading
}
