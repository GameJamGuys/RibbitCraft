using _Code.Core;
using UnityEngine;

namespace Code.Core.Pentagram
{
    public sealed class Candle : MonoBehaviour
    {
        [SerializeField] private GameObject _usualFire;
        [SerializeField] private GameObject _readyFire;

        public bool IsFired => _usualFire.activeSelf;

        public void Fuse()
        {
            _usualFire.SetActive(false);
            _readyFire.SetActive(false);
        }
        
        public void Fire()
        {
            SoundManager.Instance.Play(SoundType.FireLight);
            _readyFire.SetActive(false);
            _usualFire.SetActive(true);
        }

        public void FireSummon()
        {
            SoundManager.Instance.Play(SoundType.FireLight);
            //_usualFire.SetActive(false);
            _readyFire.SetActive(true);
        }
    }
}