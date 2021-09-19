using UnityEngine;

namespace ZeroHourMono
{
    public class Menu : MonoBehaviour
    {
        public void OnGUI()
        {
            if (Main.MenuOpen)
            {
                Main.MenuRect = GUI.Window(Main.WindowID, Main.MenuRect, Window, GUIContent.none);
            }
        }

        public void Window(int id)
        {
            GUI.Box(new Rect(1f, 1f, (Main.MenuRect).width - 2f, 25f), "", GUI.skin.window);
            GUI.Box(new Rect(1f, 26f, 76f, (Main.MenuRect).height - 27f), "", GUI.skin.window);

            if (GUI.Button(new Rect(1f, 31f, 75f, 25f), "Visuals")) Main.WindowID = 0;
            if (GUI.Button(new Rect(1f, 61f, 75f, 25f), "Misc")) Main.WindowID = 1;
            if (GUI.Button(new Rect(1f, 91f, 75f, 25f), "Config")) Main.WindowID = 2;

            if (id == 0)
            {
                GUI.Label(new Rect((float)(Main.MenuRect.width / 2.0 - 15.0), 1f, 250f, 100f), "Visuals");
                GUI.Box(new Rect(1f, 31f, 75f, 25f), "");
                GUI.Box(new Rect(76f, 26f, (Main.MenuRect).width - 77f, 69f), "");
                GUI.Label(new Rect(78f, 24f, 250f, 100f), "Player Settings");
                Main.PlayerSettings.PlayerEsp = GUI.Toggle(new Rect(78f, 45f, 90f, 25f), Main.PlayerSettings.PlayerEsp, "Player Esp");
                Main.PlayerSettings.EnemyOnly = GUI.Toggle(new Rect(78f, 65f, 90f, 25f), Main.PlayerSettings.EnemyOnly, "Enemy Only");
                Main.PlayerSettings.InfoEsp = GUI.Toggle(new Rect(170f, 25f, 90f, 25f), Main.PlayerSettings.InfoEsp, "Info Esp");
                Main.PlayerSettings.TracerEsp = GUI.Toggle(new Rect(170f, 45f, 90f, 25f), Main.PlayerSettings.TracerEsp, "Tracer Esp");
                Main.PlayerSettings.BoxEsp = GUI.Toggle(new Rect(170f, 65f, 90f, 25f), Main.PlayerSettings.BoxEsp, "Box Esp");
                Main.PlayerSettings.Box3DEsp = GUI.Toggle(new Rect(byte.MaxValue, 25f, 90f, 25f), Main.PlayerSettings.Box3DEsp, "3D Box Esp");
                Main.PlayerSettings.SkeletonEsp = GUI.Toggle(new Rect(byte.MaxValue, 45f, 100f, 25f), Main.PlayerSettings.SkeletonEsp, "Skeleton Esp");
                GUI.Box(new Rect(76f, 95f, (Main.MenuRect).width - 77f, 69f), "");
                GUI.Label(new Rect(78f, 93f, 250f, 100f), "AI Settings");
                Main.AISettings.AIEsp = GUI.Toggle(new Rect(78f, 113f, 90f, 25f), Main.AISettings.AIEsp, "AI Esp");
                Main.AISettings.EnemyOnly = GUI.Toggle(new Rect(78f, 133f, 90f, 25f), Main.AISettings.EnemyOnly, "Enemy Only");
                Main.AISettings.InfoEsp = GUI.Toggle(new Rect(160f, 93f, 90f, 25f), Main.AISettings.InfoEsp, "Info Esp");
                Main.AISettings.TracerEsp = GUI.Toggle(new Rect(160f, 113f, 90f, 25f), Main.AISettings.TracerEsp, "Tracer Esp");
                Main.AISettings.BoxEsp = GUI.Toggle(new Rect(160f, 133f, 90f, 25f), Main.AISettings.BoxEsp, "Box Esp");
                Main.AISettings.Box3DEsp = GUI.Toggle(new Rect(250f, 93f, 90f, 25f), Main.AISettings.Box3DEsp, "3D Box Esp");
                Main.AISettings.SkeletonEsp = GUI.Toggle(new Rect(250f, 113f, 100f, 25f), Main.AISettings.SkeletonEsp, "Skeleton Esp");
                GUI.Box(new Rect(76f, 164f, (Main.MenuRect).width - 77f, 68f), "");
                GUI.Label(new Rect(78f, 162f, 250f, 100f), "Hostage Settings");
                Main.HostageSettings.HostageEsp = GUI.Toggle(new Rect(78f, 182f, 90f, 25f), Main.HostageSettings.HostageEsp, "Hostage Esp");
                Main.HostageSettings.InfoEsp = GUI.Toggle(new Rect(78f, 202f, 90f, 25f), Main.HostageSettings.InfoEsp, "Info Esp");
                Main.HostageSettings.TracerEsp = GUI.Toggle(new Rect(180f, 162f, 90f, 25f), Main.HostageSettings.TracerEsp, "Tracer Esp");
                Main.HostageSettings.BoxEsp = GUI.Toggle(new Rect(180f, 182f, 90f, 25f), Main.HostageSettings.BoxEsp, "Box Esp");
                Main.HostageSettings.Box3DEsp = GUI.Toggle(new Rect(180f, 202f, 90f, 25f), Main.HostageSettings.Box3DEsp, "3D Box Esp");
                Main.HostageSettings.SkeletonEsp = GUI.Toggle(new Rect(250f, 162f, 100f, 25f), Main.HostageSettings.SkeletonEsp, "Skeleton Esp");
                GUI.Box(new Rect(76f, 232f, (Main.MenuRect).width - 77f, 68f), "");
                GUI.Label(new Rect(78f, 230f, 250f, 100f), "Misc Settings");
                Main.MiscSettings.CameraEsp = GUI.Toggle(new Rect(78f, 250f, 90f, 25f), Main.MiscSettings.CameraEsp, "Camera Esp");
                Main.MiscSettings.BreakerEsp = GUI.Toggle(new Rect(78f, 270f, 90f, 25f), Main.MiscSettings.BreakerEsp, "Breaker Esp");
                Main.MiscSettings.TrapEsp = GUI.Toggle(new Rect(170f, 230f, 90f, 25f), Main.MiscSettings.TrapEsp, "Trap Esp");
                Main.MiscSettings.ThrowableEsp = GUI.Toggle(new Rect(170f, 250f, 100f, 25f), Main.MiscSettings.ThrowableEsp, "Throwable Esp");
            } // Visuals
            if (id == 1)
            {
                GUI.Label(new Rect((float)(Main.MenuRect.width / 2.0 - 15.0), 1f, 250f, 100f), "Misc");
                GUI.Box(new Rect(1f, 91f, 75f, 25f), "");

                bool prev = Main.Speed;
                Main.Speed = GUI.Toggle(new Rect(78, 25, 100, 25), Main.Speed, "Speed");
                if (prev != Main.Speed && !prev) Main.Local.walkSpeed = 2.25f;

                Main.NoRecoil = GUI.Toggle(new Rect(78, 50, 100, 25), Main.NoRecoil, "No Recoil");

                prev = Main.InfAmmo;
                Main.InfAmmo = GUI.Toggle(new Rect(78, 75, 100, 25), Main.InfAmmo, "Inf Ammo");
                if (prev != Main.InfAmmo && !prev)
                {
                    var c = Main.Local.myWeaponManager.CurrentWeapon.p_megazine.magsLeft;
                    for (int i = 0; i < c.Count; i++)
                    {
                        c[i].ammoLeft = 30;
                    }
                }

                Main.InfStam = GUI.Toggle(new Rect(78, 100, 100, 25), Main.InfStam, "Inf Stam");

                prev = Main.FB;
                Main.FB = GUI.Toggle(new Rect(78, 125, 100, 25), Main.FB, "Fullbright");
                if (prev != Main.FB) Main.FullBright(Main.FB);
            } // Misc
            if (id == 2)
            {
                GUI.Label(new Rect((float)(Main.MenuRect.width / 2.0 - 15.0), 1f, 250f, 100f), "Config");
                GUI.Box(new Rect(1f, 121f, 75f, 25f), "");
                for (int index = 0; index < 7; ++index)
                {
                    string str = "Team Color";
                    Color color = Main.PlayerSettings.TeamColor;
                    switch (index - 1)
                    {
                        case 0:
                            str = "Enemy Color";
                            color = Main.PlayerSettings.EnemyColor;
                            break;
                        case 1:
                            str = "AI Color";
                            color = Main.AISettings.Color;
                            break;
                        case 2:
                            str = "Hostage Color";
                            color = Main.HostageSettings.Color;
                            break;
                        case 3:
                            str = "Camera Color";
                            color = Main.MiscSettings.CameraColor;
                            break;
                        case 4:
                            str = "Breaker Color";
                            color = Main.MiscSettings.BreakerColor;
                            break;
                        case 5:
                            str = "Trap Color";
                            color = Main.MiscSettings.TrapColor;
                            break;
                        case 6:
                            str = "Grenade Color";
                            color = Main.MiscSettings.ThrowableColor;
                            break;
                    }
                    GUI.color = color;
                    if (GUI.Button(new Rect(78f, (index * 25 + 25), 100f, 25f), str))
                    {
                        Main.ColorShown = !Main.ColorShown;
                        Main.ColorID = index;
                    }
                    GUI.color = Color.white;
                }
                if (Main.ColorShown)
                {
                    switch (Main.ColorID)
                    {
                        case 0:
                            Main.PlayerSettings.TeamColor = ColorPicker(new Rect(220f, 155f, 120f, 140f), Main.PlayerSettings.TeamColor);
                            break;
                        case 1:
                            Main.PlayerSettings.EnemyColor = ColorPicker(new Rect(220f, 155f, 120f, 140f), Main.PlayerSettings.EnemyColor);
                            break;
                        case 2:
                            Main.AISettings.Color = ColorPicker(new Rect(220f, 155f, 120f, 140f), Main.AISettings.Color);
                            break;
                        case 3:
                            Main.HostageSettings.Color = ColorPicker(new Rect(220f, 155f, 120f, 140f), Main.HostageSettings.Color);
                            break;
                        case 4:
                            Main.MiscSettings.CameraColor = ColorPicker(new Rect(220f, 155f, 120f, 140f), Main.MiscSettings.CameraColor);
                            break;
                        case 5:
                            Main.MiscSettings.BreakerColor = ColorPicker(new Rect(220f, 155f, 120f, 140f), Main.MiscSettings.BreakerColor);
                            break;
                        case 6:
                            Main.MiscSettings.TrapColor = ColorPicker(new Rect(220f, 155f, 120f, 140f), Main.MiscSettings.TrapColor);
                            break;
                        case 7:
                            Main.MiscSettings.ThrowableColor = ColorPicker(new Rect(220f, 155f, 120f, 140f), Main.MiscSettings.ThrowableColor);
                            break;
                    }
                }
            } // Config

            GUI.DragWindow(new Rect(0.0f, 2f, (Main.MenuRect).width, 25f));
        }

        public Color ColorPicker(Rect rect, Color color)
        {
            GUI.Box(rect, "");
            color.r = GUI.HorizontalSlider(new Rect(rect.x + 5f, rect.y + 5f, 100f, 25f), color.r, 0f, 1f);
            color.g = GUI.HorizontalSlider(new Rect(rect.x + 5f, rect.y + 30f, 100f, 25f), color.g, 0f, 1f);
            color.b = GUI.HorizontalSlider(new Rect(rect.x + 5f, rect.y + 55f, 100f, 25f), color.b, 0f, 1f);

            Color color1 = new Color(color.r * 255, color.g * 255, color.b * 255);
            Color color2 = Color.white;

            Color.RGBToHSV(color1, out color2.r, out color2.g, out color2.b);

            GUI.Label(new Rect(rect.x + 5f, rect.y + 70f, 250f, 100f), $"RGB: ({color1.r}, {color1.g}, {color1.b})");
            GUI.Label(new Rect(rect.x + 5f, rect.y + 85f, 250f, 100f), $"HSV: ({color2.r}, {color2.g}, {color2.b})");

            GUI.color = color;
            Texture2D texture2D = new Texture2D(20, 20);
            GUI.Label(new Rect(rect.x + 5f, rect.y + 100f, 250f, 100f), texture2D);
            GUI.color = Color.white;
            return color;
        }
    }
}
