using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HF
{
    public enum Spawnable
    {
        Harpoon,
        RoomWall,
        RoomDoor
    }

    public enum StageType
    {
        Boring,
        Lane5
    }

    public enum RoomType
    {
        Boring,
        CoreRoom
    }

    public enum ControlScheme
    {
        MouseKeyboard,
        JoystickOne
    }

    public enum PlayerSlot
    {
        PlayerOne,
        PlayerTwo
    }

    public enum SoundClip
    {
        Fire,
        Reload
    }

    public enum GameMode
    {
        Deathmatch
    }
}
