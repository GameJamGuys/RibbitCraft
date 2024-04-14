using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Core.Pentagram;

namespace Code.UI.Skull
{
    public class SkullController : MonoBehaviour
    {
        [SerializeField] Pentagram pentagram;
        [SerializeField] Animator skullAnim;
        [SerializeField] SkullBubble bubble;

        bool onCast;

        private void OnEnable()
        {
            pentagram.OnFiveItems += SkullReady;
            pentagram.OnSummon += SkullDone;
        }

        private void OnDisable()
        {
            pentagram.OnFiveItems -= SkullReady;
            pentagram.OnSummon -= SkullDone;
        }

        void Start()
        {
            onCast = false;
        }

        void SkullReady()
        {
            onCast = true;
            skullAnim.SetTrigger("Ready");
        }

        void SkullDone()
        {
            skullAnim.SetTrigger("Done");
            onCast = false;
        }

        public void ClickOnSkull()
        {
            if (onCast)
                pentagram.Summon();
            else
            {
                skullAnim.SetTrigger("Say");
                bubble.gameObject.SetActive(true);
            }
        }
    }

}
