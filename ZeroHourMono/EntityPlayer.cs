using System.Collections.Generic;
using UnityEngine;

namespace ZeroHourMono
{
    public class EntityPlayer : MonoBehaviour
    {
        public EntityPlayer(UserInput ui)
        {
            UserInput = ui;
            Alive = ui.myHealth.alive;
            Name = ui.MyPhoton.Controller.NickName;
            Health = ui.myHealth.health.GetDecrypted();
            OnTeam = Utility.GetTeam(ui);
            WeaponName = ui.myWeaponManager.CurrentWeapon.Properties.GunName;

            Distance = (int)Utility.GetDistance(ui.transform.position);

            Collider = ui.transform.GetComponentInChildren<CapsuleCollider>();
            Bounds = Collider.bounds;

            Bones = Utility.GetAllBones(ui.myWeaponManager.anim);
            Renderers = ui.GetComponentsInChildren<Renderer>();

            W2SHead = Utility.W2S(Bones[0].position);
            W2SFoot = Utility.W2S(new Vector3(Bones[0].position.x, Bones[15].position.y, Bones[0].position.z));
        }
        public void RecalcStuff()
        {
            Alive = UserInput.myHealth.alive;
            Health = UserInput.myHealth.health.GetDecrypted();

            Bounds = Collider.bounds;

            W2SHead = Utility.W2S(Bones[0].position);
            W2SFoot = Utility.W2S(new Vector3(Bones[0].position.x, Bones[15].position.y, Bones[0].position.z));
        }

        public UserInput UserInput;
        public bool Alive;

        public string Name;
        public float Health;
        public bool OnTeam;
        public string WeaponName;

        public int Distance;
        public CapsuleCollider Collider;
        public Bounds Bounds;

        public Vector3 W2SHead, W2SFoot;

        public List<Transform> Bones = new List<Transform>();
        public Renderer[] Renderers;

    }
}