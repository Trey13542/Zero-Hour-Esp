using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZeroHourMono
{
  public class Main : MonoBehaviour
  {
        #region Main Vars
        public static Camera Cam;
        public static UserInput Local;
        public static List<IDLogger> LocalTeam = new List<IDLogger>();

        public IEnumerator MainUpdate, MiscUpdate;
        #endregion
        #region Menu Vars
        public static bool MenuOpen = true;
        public static bool ColorShown = false;
        public static Rect MenuRect = new Rect(0f, 0f, 350f, 300f);
        public static int WindowID = 0;
        public static int ColorID = 0;
        #endregion
        #region Esp Vars
        public static List<EntityPlayer> Players = new List<EntityPlayer>();
        public static List<ZH_AINav> AI = new List<ZH_AINav>();
        public static List<SpyCamSystem> Cameras = new List<SpyCamSystem>();
        public static List<DoorTrapSystem> Traps = new List<DoorTrapSystem>();
        public static Transform Hostage = null;
        public static BreakerBoxSystem BreakerBox = null;

        public static Material DrawMat;
        public static List<Transform> HostageBones = new List<Transform>();
        #endregion
        #region Misc Vars
        public static bool Speed, NoRecoil, InfStam, InfAmmo, FB;
        #endregion

        public void Start()
        {
            DrawMat = new Material(Shader.Find("Hidden/Internal-Colored"))
            {
                hideFlags = (HideFlags)61
            };

            DrawMat.SetInt("_SrcBlend", 5);
            DrawMat.SetInt("_DstBlend", 10);
            DrawMat.SetInt("_Cull", 0);
            DrawMat.SetInt("_ZWrite", 0);

            MainUpdate = MainUpdateFunc(0f);
            MiscUpdate = MiscUpdateFunc(0f);

            StartCoroutine(MainUpdate);
            StartCoroutine(MiscUpdate);
        }
        public void Update()
        {
            if (GameObject.Find("Anti-Cheat Toolkit")) Destroy(GameObject.Find("Anti-Cheat Toolkit"));
            InputManager();

            if (Speed)
            {
                Local.walkSpeed = 10f;
            }
            if (NoRecoil)
            {
                var p = Local.myWeaponManager.CurrentWeapon.Properties;
                p.HeatRate = 0f;
                p.recoilAmount = 0f;
                p.recoilRecoverTime = 0f;

                p.upwardKick = 0f;
                p.upwardKickSpeed = 0f;

                p.MaxSwaySpeed = 0f;
                p.MaxSpray = 0f;
                p.MinSpray = 0f;
                p.WeaponMovementSway = 0f;

                var cr = Local.GetComponentInChildren<CameraRig>();
                cr.RecoilX = 0f;
                cr.RecoilY = 0f;
                cr.assignedSpread = 0f;
            }
            if (InfStam)
            {
                var c = Local.myWeaponManager.CurrentWeapon;
                c.ex_Weight = 0f;
                c.Properties.Weight = 0f;
                c.Properties.StaminaDrain = 0f;
            }
            if (InfAmmo)
            {
                var c = Local.myWeaponManager.CurrentWeapon.p_megazine.magsLeft;
                for (int i = 0; i < c.Count; i++)
                {
                    c[i].ammoLeft = 99999;
                }
            }
        }
        public void InputManager()
        {
            if (Input.GetKeyDown(KeyCode.Insert)) MenuOpen = !MenuOpen;
            if (Input.GetKeyDown(KeyCode.Delete)) Loader.Unload();
        }

        public static void FullBright(bool on)
        {
            Light[] lights = Local.gameObject.GetComponentsInChildren<Light>();
            Light FBL = null;
            for (int i = 0; i < lights.Length; i++)
            {
                if (lights[i].name == "FullBrightLight") FBL = lights[i];
            }

            if (FBL == null) FBL = Local.gameObject.AddComponent<Light>();

            if (on)
            {
                FBL.name = "FullBrightLight";
                FBL.color = Color.white;
                FBL.type = LightType.Point;
                FBL.shadows = LightShadows.None;
                FBL.range = 9999f;
                FBL.spotAngle = 9999f;
                FBL.intensity = .75f;
            }
            else
            {
                Destroy(FBL);
            }
        }

        #region Update Lists
        public IEnumerator MainUpdateFunc(float time)
        {
            yield return new WaitForSeconds(time);

            try
            {
                #region Main Stuff
                if (!Cam) Cam = Camera.main;
                Local = GameNetworks.Instance.LP_User;
                LocalTeam = GameSettings.Instance.TeamLogger.BlueTeam.Contains(Local.myLogger) ? GameSettings.Instance.TeamLogger.BlueTeam : GameSettings.Instance.TeamLogger.RedTeam;
                #endregion
                #region Player List
                var p = FindObjectsOfType<UserInput>();
                Players.Clear();
                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i] != Local)
                        Players.Add(new EntityPlayer(p[i]));
                }
                #endregion
                #region AI List
                AI = FindObjectOfType<ZH_AIManager>().AliveEnemies;
                #endregion
            }
            catch { }

            MainUpdate = MainUpdateFunc(3f);
            StartCoroutine(MainUpdate);
        }
        public IEnumerator MiscUpdateFunc(float time)
        {
            yield return new WaitForSeconds(time);

            try
            {
                #region Hostage
                foreach (Transform t in FindObjectsOfType<Transform>())
                {
                    if (t.name == "Bomb_Final(Clone)" || t.name == "Hostage_Final(Clone)")
                    {
                        Hostage = t;
                        HostageBones = Utility.GetAllBones(Hostage);
                        break;
                    }
                }
                #endregion
                #region Lists
                Cameras = FindObjectOfType<SpyCamGlobal>().AllSpyCams.ToList();
                Traps = GameSettings.Instance.DoorTrapLogger.Traps;
                BreakerBox = GameSettings.Instance.BreakerBoxLogger;
                #endregion
            }
            catch { }

            MiscUpdate = MiscUpdateFunc(5f);
            StartCoroutine(MiscUpdate);
        }
        #endregion
        #region Settings
        public class PlayerSettings
        {
            public static bool PlayerEsp = false;
            public static bool EnemyOnly = false;
            public static bool InfoEsp = false;
            public static bool TracerEsp = false;
            public static bool BoxEsp = false;
            public static bool Box3DEsp = false;
            public static bool SkeletonEsp = false;
            public static Color TeamColor = Color.cyan;
            public static Color EnemyColor = Color.red;
        }

        public class AISettings
        {
            public static bool EnemyOnly = false;
            public static bool AIEsp = false;
            public static bool InfoEsp = false;
            public static bool TracerEsp = false;
            public static bool BoxEsp = false;
            public static bool Box3DEsp = false;
            public static bool SkeletonEsp = false;
            public static Color Color = Color.red;
        }

        public class HostageSettings
        {
            public static bool HostageEsp = false;
            public static bool InfoEsp = false;
            public static bool TracerEsp = false;
            public static bool BoxEsp = false;
            public static bool Box3DEsp = false;
            public static bool SkeletonEsp = false;
            public static Color Color = Color.green;
        }

        public class MiscSettings
        {
            public static bool CameraEsp = false;
            public static bool BreakerEsp = false;
            public static bool TrapEsp = false;
            public static bool ThrowableEsp = false;
            public static Color CameraColor = Color.magenta;
            public static Color BreakerColor = Color.yellow;
            public static Color TrapColor = Color.red;
            public static Color ThrowableColor = Color.red;
        }
        #endregion

    }
}