using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{

    public GameObject Held;
    public Texture2D Target;
    public CharacterMotor IC;
    public CharacterController CC;
    public float ReloadTime;
    public float DashTime;
    PlayerState State;
    float Timer;
    public GameObject BallType;
    public GameObject MyEyes;
    public float ShotPower;
    public float DoubleTapTime;
    public float DashSpeed;
    float TapTimer;
    LastTap LTap;
    Vector3 DashDir;
    public AudioClip ReloadSound;
    public AudioClip FireSound;
    public AudioClip DodgeSound;
    public string ControlName;

    // Use this for initialization
    void Start()
    {
        //UnityEditor.EditorGUIUtility.AddCursorRect(new Rect(0,0,20,20),UnityEditor.MouseCursor.FPS);
        //Screen.showCursor = false;
        Screen.lockCursor = true;
        State = PlayerState.Idle;
        LTap = LastTap.None;
        //CC = (CharacterController)GetComponent("CharacterController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer > 0)
            Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            TimerDone();
            //PlayerState old = State;
            State = FindState();
        }
        if (TapTimer > 0)
        {
            TapTimer -= Time.deltaTime;
            if (TapTimer <= 0)
                LTap = LastTap.None;
        }
        if (CanAct())
        {
            IC.canControl = true;
            if (Held == null)
            {
                if (GetInput("Reload") == 1)
                {
                    GameObject ball = (GameObject)Instantiate(BallType);
                    PickUpObject(ball);
                    Hashtable ht = new Hashtable();
                    ht.Add("x", 0.1f);
                    ht.Add("y", 0.1f);
                    ht.Add("islocal", true);
                    ht.Add("time", ReloadTime);
                    iTween.ShakePosition(MyEyes, ht);
                    audio.PlayOneShot(ReloadSound);
                }
            }
            if (GetInput("Dive") == 1 && (GetInput("Horizontal") != 0 || GetInput("Vertical") != 0))
            {
                float forward = GetInput("Vertical");
                float right = GetInput("Horizontal");
                float sum = Mathf.Abs(forward) + Mathf.Abs(right);
                if (sum < 1)
                {
                    float mult = 1 / sum;
                    forward *= mult;
                    right *= mult;
                }
                Vector3 dir = new Vector3(DashSpeed * right, 0, DashSpeed * forward);
                Dash(dir);   
            }
            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    if (LTap == LastTap.Left)
            //        Dash(new Vector3(-DashSpeed, 0, 0));
            //    else
            //    {
            //        LTap = LastTap.Left;
            //        TapTimer = DoubleTapTime;
            //    }
            //}
            //else if (Input.GetKeyDown(KeyCode.D))
            //{
            //    if (LTap == LastTap.Right)
            //        Dash(new Vector3(DashSpeed, 0, 0));
            //    else
            //    {
            //        LTap = LastTap.Right;
            //        TapTimer = DoubleTapTime;
            //    }
            //}
            //else if (Input.GetKeyDown(KeyCode.W))
            //{
            //    if (LTap == LastTap.Forward)
            //        Dash(new Vector3(0, 0, DashSpeed));
            //    else
            //    {
            //        LTap = LastTap.Forward;
            //        TapTimer = DoubleTapTime;
            //    }
            //}
            //else if (Input.GetKeyDown(KeyCode.S))
            //{
            //    if (LTap == LastTap.Back)
            //        Dash(new Vector3(0, 0, -DashSpeed));
            //    else
            //    {
            //        LTap = LastTap.Back;
            //        TapTimer = DoubleTapTime;
            //    }
            //}
        }
        else
        {
            IC.canControl = false;
            if (State == PlayerState.Reloading)
            {
                float size = (Held.transform.localScale.z + transform.localScale.z) / 2;
                float lerp = Mathf.Lerp(-0.7f, -0.4f, (ReloadTime - Timer) / ReloadTime);
                Held.transform.localPosition = new Vector3(0, lerp, size);
            }
            else if (State == PlayerState.Tumbling)
            {
                float x = Mathf.Lerp(DashDir.x, 0, (DashTime - Timer) / DashTime);
                float y = Mathf.Lerp(DashDir.y, 0, (DashTime - Timer) / DashTime);
                float z = Mathf.Lerp(DashDir.z, 0, (DashTime - Timer) / DashTime);
                CC.Move(new Vector3(x, y, z));
                Vector3 eyePos = MyEyes.transform.localPosition;
                if (Timer > 0.1f)
                    eyePos.y = Mathf.Lerp(0.3f, -0.3f, (DashTime - (Timer - 0.1f)) / (DashTime - 0.1f));
                else
                    eyePos.y = Mathf.Lerp(-0.3f, 0.3f, (0.1f - Timer) / 0.1f);
                MyEyes.transform.localPosition = eyePos;
            }
        }
        if ((CanAct() || State == PlayerState.Tumbling) && Held != null && GetInput("Fire1") == 1)
        {
            Held.rigidbody.isKinematic = false;
            Held.rigidbody.velocity = transform.TransformDirection(Vector3.forward * ShotPower);
            Held.transform.parent = null;
            Held = null;
            audio.PlayOneShot(FireSound);
        }
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2 - 8, Screen.height / 2 - 8, 18, 18), Target);
    }

    //void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.transform.parent == null)
    //        return;
    //    GameObject what = collision.gameObject.transform.parent.gameObject;
    //    if (what.CompareTag("Holdable") && State != PlayerState.Shooting)
    //    {
    //        PickUpObject(what);
    //    }

    //}

    bool CanAct()
    {
        if (State == PlayerState.Dead || State == PlayerState.Reloading || State == PlayerState.Tumbling)
            return false;
        return true;
    }

    void PickUpObject(GameObject what)
    {
        what.transform.parent = MyEyes.transform;
        //float size = (what.transform.localScale.z + transform.localScale.z) / 2;
        what.transform.localPosition = new Vector3(0, -0.2f, 0);
        what.rigidbody.isKinematic = true;
        Held = what;
        State = PlayerState.Reloading;
        Timer = ReloadTime;
    }

    PlayerState FindState()
    {
        if (!CC.isGrounded)
            return PlayerState.Jumping;
        return PlayerState.Idle;
    }

    void TimerDone()
    {
        switch (State)
        {
            case PlayerState.Reloading:
                //MyEyes.transform.localPosition = new Vector3(0, 0.5f, 0);
                break;
            case PlayerState.Tumbling:
                DashDir = Vector3.zero;
                break;
        }
    }

    void Dash(Vector3 dir)
    {
        dir = transform.TransformDirection(dir);
        DashDir = dir;
        Timer = DashTime;
        State = PlayerState.Tumbling;
        LTap = LastTap.None;
        TapTimer = 0;
    }

    public float GetInput(string input)
    {
        if (input != "")
            input += " " + ControlName;
        return Input.GetAxis(input);
    }

}

public enum PlayerState
{
    Idle,
    Walking,
    Jumping,
    Reloading,
    Tumbling,
    Dead
}

public enum LastTap
{
    None,
    Forward,
    Back,
    Left,
    Right
}
