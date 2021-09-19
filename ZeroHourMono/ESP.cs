using System.Collections.Generic;
using UnityEngine;

namespace ZeroHourMono
{
    public class ESP : MonoBehaviour
    {
        public void OnGUI()
        {
            if (Event.current.type != EventType.Repaint) return;

            if (Main.PlayerSettings.PlayerEsp)
            {
                foreach (EntityPlayer p in Main.Players)
                {
                    p.RecalcStuff();
                    if (p.Alive)
                    {
                        if (Utility.IsOnScreen(p.W2SHead))
                        {
                            Color c = p.OnTeam ? Main.PlayerSettings.TeamColor : Main.PlayerSettings.EnemyColor;
                            GUI.color = c;

                            if (p.OnTeam && !Main.PlayerSettings.EnemyOnly || !p.OnTeam && !Main.PlayerSettings.EnemyOnly)
                            {
                                if (Main.PlayerSettings.InfoEsp)
                                {
                                    GUI.Label(new Rect(p.W2SHead.x, Screen.height - p.W2SHead.y, 250, 100), $"[{p.Distance}m] {p.Name}"); // Head ( [5m] Bob )
                                    GUI.Label(new Rect(p.W2SFoot.x, Screen.height - p.W2SFoot.y, 250, 100), $"{p.WeaponName}"); // Foot ( Pistol )
                                }
                                if (Main.PlayerSettings.TracerEsp)
                                {
                                    DrawLine(new Vector2(Screen.width / 2, Screen.height), new Vector2(p.W2SFoot.x, Screen.height - p.W2SFoot.y), c, 2);
                                }
                                if (Main.PlayerSettings.BoxEsp)
                                {
                                    DrawBox(p.W2SFoot, p.W2SHead, c);
                                }
                                if (Main.PlayerSettings.Box3DEsp)
                                {
                                    Draw3DBox(p.Bounds, c);
                                }
                                if (Main.PlayerSettings.SkeletonEsp)
                                {
                                    DrawAllBones(p.Bones, c);
                                }
                            }
                            else if (!p.OnTeam && Main.PlayerSettings.EnemyOnly)
                            {
                                if (Main.PlayerSettings.InfoEsp)
                                {
                                    GUI.Label(new Rect(p.W2SHead.x, Screen.height - p.W2SHead.y, 250, 100), $"[{p.Distance}m] {p.Name}"); // Head ( [5m] Bob )
                                    GUI.Label(new Rect(p.W2SFoot.x, Screen.height - p.W2SFoot.y, 250, 100), $"{p.WeaponName}"); // Foot ( Pistol )
                                }
                                if (Main.PlayerSettings.TracerEsp)
                                {
                                    DrawLine(new Vector2(Screen.width / 2, Screen.height), new Vector2(p.W2SFoot.x, Screen.height - p.W2SFoot.y), c, 2);
                                }
                                if (Main.PlayerSettings.BoxEsp)
                                {
                                    DrawBox(p.W2SFoot, p.W2SHead, c);
                                }
                                if (Main.PlayerSettings.Box3DEsp)
                                {
                                    Draw3DBox(p.Bounds, c);
                                }
                                if (Main.PlayerSettings.SkeletonEsp)
                                {
                                    DrawAllBones(p.Bones, c);
                                }
                            }
                        }
                    }
                }
            }

            if (Main.AISettings.AIEsp)
            {
                foreach (ZH_AINav ai in Main.AI)
                {
                    List<Transform> b = Utility.GetAllBones(ai.ManualReference.anim);

                    Vector3 w = Utility.W2S(new Vector3(b[0].position.x, b[13].position.y, b[0].position.z));
                    Vector3 wH = Utility.W2S(b[0].position);

                    if (Utility.IsOnScreen(w))
                    {
                        if (Main.AISettings.InfoEsp)
                        {
                            GUI.Label(new Rect(w.x, Screen.height - w.y, 250, 100), $"[{(int)Utility.GetDistance(ai.transform.position)}m] AI - {ai.myWeapon.Properties.GunName}");
                        }
                        if (Main.AISettings.TracerEsp)
                        {
                            DrawLine(new Vector2(Screen.width / 2, Screen.height), new Vector2(w.x, Screen.height - w.y), Main.AISettings.Color, 2f);
                        }
                        if (Main.AISettings.BoxEsp)
                        {
                            DrawBox(w, wH, Main.AISettings.Color);
                        }
                        if (Main.AISettings.Box3DEsp)
                        {
                            Draw3DBox(ai.GetComponentInChildren<CapsuleCollider>().bounds, Main.AISettings.Color);
                        }
                        if (Main.AISettings.SkeletonEsp)
                        {
                            Color c = Main.AISettings.Color;

                            DrawBones(b[0], b[1], c, 0);
                            DrawBones(b[1], b[2], c, 0);

                            DrawBones(b[1], b[3], c, 0);
                            DrawBones(b[3], b[4], c, 0);
                            DrawBones(b[4], b[5], c, 0);
                            DrawBones(b[5], b[6], c, 0);

                            DrawBones(b[1], b[7], c, 0);
                            DrawBones(b[7], b[8], c, 0);
                            DrawBones(b[8], b[9], c, 0);
                            DrawBones(b[9], b[10], c, 0);

                            DrawBones(b[2], b[11], c, 0);
                            DrawBones(b[11], b[12], c, 0);
                            DrawBones(b[12], b[13], c, 0);

                            DrawBones(b[2], b[14], c, 0);
                            DrawBones(b[14], b[15], c, 0);
                            DrawBones(b[15], b[16], c, 0);
                        }
                    }
                }
            }
            if (Main.HostageSettings.HostageEsp)
            {
                Vector3 w = Utility.W2S(new Vector3(Main.HostageBones[2].position.x, Main.HostageBones[13].position.y, Main.HostageBones[2].position.z));
                Vector3 wH = Utility.W2S(Main.HostageBones[2].position);

                if (Utility.IsOnScreen(w))
                {
                    GUI.color = Main.HostageSettings.Color;

                    if (Main.HostageSettings.InfoEsp)
                    {
                        GUI.Label(new Rect(w.x, Screen.height - w.y, 250, 100), $"[{(int)Utility.GetDistance(Main.Hostage.transform.position)}m] Hostage");
                    }
                    if (Main.HostageSettings.TracerEsp)
                    {
                        DrawLine(new Vector2(Screen.width / 2, Screen.height), new Vector2(w.x, Screen.height - w.y), Main.HostageSettings.Color, 2f);
                    }
                    if (Main.HostageSettings.BoxEsp)
                    {
                        DrawBox(w, wH, Main.HostageSettings.Color);
                    }
                    if (Main.HostageSettings.Box3DEsp)
                    {
                        Draw3DBox(Main.Hostage.GetComponentInChildren<CapsuleCollider>().bounds, Main.HostageSettings.Color);
                    }
                    if (Main.HostageSettings.SkeletonEsp)
                    {
                        List<Transform> b = Utility.GetAllBones(Main.Hostage.transform);
                        Color c = Main.HostageSettings.Color;

                        DrawBones(b[2], b[1], c, 0);
                        DrawBones(b[1], b[0], c, 0);

                        DrawBones(b[1], b[3], c, 0);
                        DrawBones(b[3], b[4], c, 0);
                        DrawBones(b[4], b[5], c, 0);
                        DrawBones(b[5], b[6], c, 0);

                        DrawBones(b[1], b[7], c, 0);
                        DrawBones(b[7], b[8], c, 0);
                        DrawBones(b[8], b[9], c, 0);
                        DrawBones(b[9], b[10], c, 0);

                        DrawBones(b[0], b[11], c, 0);
                        DrawBones(b[11], b[12], c, 0);
                        DrawBones(b[12], b[13], c, 0);

                        DrawBones(b[0], b[14], c, 0);
                        DrawBones(b[14], b[15], c, 0);
                        DrawBones(b[15], b[16], c, 0);
                    }
                }
            }

            if (Main.MiscSettings.CameraEsp)
            {
                foreach (SpyCamSystem c in Main.Cameras)
                {
                    Vector3 w = Utility.W2S(c.transform.position);
                    if (Utility.IsOnScreen(w) && c.CameraModel.activeSelf)
                    {
                        GUI.color = Main.MiscSettings.CameraColor;
                        GUI.Label(new Rect(w.x, Screen.height - w.y, 250, 100), $"Camera");
                    }
                }
            }
            if (Main.MiscSettings.BreakerEsp)
            {
                Vector3 w = Utility.W2S(Main.BreakerBox.transform.position);
                if (Utility.IsOnScreen(w))
                {
                    GUI.color = Main.MiscSettings.BreakerColor;
                    GUI.Label(new Rect(w.x, Screen.height - w.y, 250, 100), $"Breaker Box");
                }
            }
            if (Main.MiscSettings.TrapEsp)
            {
                foreach (DoorTrapSystem t in Main.Traps)
                {
                    Vector3 w = Utility.W2S(t.transform.position);
                    if (Utility.IsOnScreen(w) && t.ACTIVE)
                    {
                        GUI.color = Main.MiscSettings.TrapColor;
                        GUI.Label(new Rect(w.x, Screen.height - w.y, 250, 100), $"Trap");
                    }
                }
            }
        }

        public static void DrawLine(Vector2 start, Vector2 end, Color color, float width)
        {
            Vector2 d = end - start;
            float a = Mathf.Rad2Deg * Mathf.Atan(d.y / d.x);
            if (d.x < 0)
                a += 180f;

            int w = (int)Mathf.Ceil(width / 2);

            GUI.color = color;
            GUIUtility.RotateAroundPivot(a, start);
            GUI.DrawTexture(new Rect(start.x, start.y - w, d.magnitude, width), Texture2D.whiteTexture, ScaleMode.StretchToFill);
            GUIUtility.RotateAroundPivot(-a, start);
        }
        void DrawBox(Vector3 w, Vector3 wH, Color c)
        {
            float h = Mathf.Abs(wH.y - w.y);
            float x = w.x - h * .3f;
            float y = Screen.height - wH.y;

            DrawBox(new Vector2(x - 1f, y - 1f), new Vector2((h / 2f) + 2f, h + 2f), Color.black); // Outside
            DrawBox(new Vector2(x, y), new Vector2(h / 2f, h), c); // Middle
            DrawBox(new Vector2(x + 1f, y + 1f), new Vector2((h / 2f) - 2f, h - 2f), Color.black); // Inside
        }
        void DrawBox(Vector2 pos, Vector2 size, Color color)
        {
            GUI.color = color;

            GUI.DrawTexture(new Rect(pos.x, pos.y, 1, size.y), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(pos.x + size.x, pos.y, 1, size.y), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(pos.x, pos.y, size.x, 1), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(pos.x, pos.y + size.y, size.x, 1), Texture2D.whiteTexture);
        }
        public static void Draw3DBox(Bounds b, Color color)
        {
            Vector3[] pts = new Vector3[8];
            pts[0] = Main.Cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z));
            pts[1] = Main.Cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z));
            pts[2] = Main.Cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z));
            pts[3] = Main.Cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z));
            pts[4] = Main.Cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z));
            pts[5] = Main.Cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z));
            pts[6] = Main.Cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z));
            pts[7] = Main.Cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z));

            for (int i = 0; i < pts.Length; i++) pts[i].y = Screen.height - pts[i].y;

            GL.PushMatrix();
            GL.Begin(1);
            Main.DrawMat.SetPass(0);
            GL.End();
            GL.PopMatrix();

            GL.PushMatrix();
            GL.Begin(1);
            Main.DrawMat.SetPass(0);
            GL.Color(color);
            // Top
            GL.Vertex3(pts[0].x, pts[0].y, 0f);
            GL.Vertex3(pts[1].x, pts[1].y, 0f);
            GL.Vertex3(pts[1].x, pts[1].y, 0f);
            GL.Vertex3(pts[5].x, pts[5].y, 0f);
            GL.Vertex3(pts[5].x, pts[5].y, 0f);
            GL.Vertex3(pts[4].x, pts[4].y, 0f);
            GL.Vertex3(pts[4].x, pts[4].y, 0f);
            GL.Vertex3(pts[0].x, pts[0].y, 0f);

            // Bottom
            GL.Vertex3(pts[2].x, pts[2].y, 0f);
            GL.Vertex3(pts[3].x, pts[3].y, 0f);
            GL.Vertex3(pts[3].x, pts[3].y, 0f);
            GL.Vertex3(pts[7].x, pts[7].y, 0f);
            GL.Vertex3(pts[7].x, pts[7].y, 0f);
            GL.Vertex3(pts[6].x, pts[6].y, 0f);
            GL.Vertex3(pts[6].x, pts[6].y, 0f);
            GL.Vertex3(pts[2].x, pts[2].y, 0f);

            // Sides
            GL.Vertex3(pts[2].x, pts[2].y, 0f);
            GL.Vertex3(pts[0].x, pts[0].y, 0f);
            GL.Vertex3(pts[3].x, pts[3].y, 0f);
            GL.Vertex3(pts[1].x, pts[1].y, 0f);
            GL.Vertex3(pts[7].x, pts[7].y, 0f);
            GL.Vertex3(pts[5].x, pts[5].y, 0f);
            GL.Vertex3(pts[6].x, pts[6].y, 0f);
            GL.Vertex3(pts[4].x, pts[4].y, 0f);

            GL.End();
            GL.PopMatrix();

        }
        public static void DrawCircle(Color Col, Vector2 Center, float Radius)
        {
            GL.PushMatrix();

            Main.DrawMat.SetPass(0);

            GL.Begin(1);
            GL.Color(Col);

            for (float num = 0f; num < 6.28318548f; num += 0.05f)
            {
                GL.Vertex(new Vector3(Mathf.Cos(num) * Radius + Center.x, Mathf.Sin(num) * Radius + Center.y));
                GL.Vertex(new Vector3(Mathf.Cos(num + 0.05f) * Radius + Center.x, Mathf.Sin(num + 0.05f) * Radius + Center.y));
            }

            GL.End();
            GL.PopMatrix();
        }
        public static void RectFilled(float x, float y, float width, float height, Color color)
        {
            GUI.DrawTexture(new Rect(x, y, width, height), Texture2D.whiteTexture);
        }
        void DrawBones(Transform bone1, Transform bone2, Color c, int mode)
        {
            Vector3 w1 = Utility.W2S(bone1.position);
            Vector3 w2 = Utility.W2S(bone2.position);

            DrawLine(new Vector2(w1.x, Screen.height - w1.y), new Vector2(w2.x, Screen.height - w2.y), c, 2f);
        }
        void DrawAllBones(List<Transform> b, Color c)
        {
            var t = b[13];
            t.position = new Vector3(b[0].position.x, t.position.y, b[0].position.z);

            int mode = 0;

            DrawBones(b[0], b[1], c, mode);
            DrawBones(b[1], b[2], c, mode);

            DrawBones(b[1], b[3], c, mode);
            DrawBones(b[3], b[4], c, mode);
            DrawBones(b[4], b[5], c, mode);
            DrawBones(b[5], b[6], c, mode);

            DrawBones(b[1], b[7], c, mode);
            DrawBones(b[7], b[8], c, mode);
            DrawBones(b[8], b[9], c, mode);
            DrawBones(b[9], b[10], c, mode);

            DrawBones(b[2], b[11], c, mode);
            DrawBones(b[11], b[12], c, mode);
            DrawBones(b[12], b[13], c, mode);

            DrawBones(b[2], b[14], c, mode);
            DrawBones(b[14], b[15], c, mode);
            DrawBones(b[15], b[16], c, mode);
        }
    }
}
