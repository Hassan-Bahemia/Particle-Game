using System;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CaptureZone
{
    public class CaptureZone : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _captureZone;
        [SerializeField] private ParticleSystem _innerZone;
        [SerializeField] private Gradient _captureGradient;
        [SerializeField] private Gradient _defaultGradient;
        [SerializeField] private float _time;
        [SerializeField] private float _timeBetweenSpawns;
        [SerializeField] private float _timeBreak;
        [SerializeField] private float _minX, _maxX;
        [SerializeField] private float _minY, _maxY;
        [SerializeField] private Vector2 _pos;
        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private bool isTouchingZone;

        // Start is called before the first frame update
        private void Start()
        {
            _captureZone = GameObject.Find("CaptureOuter").GetComponent<ParticleSystem>();
            _innerZone = GameObject.Find("CaptureMid").GetComponent<ParticleSystem>();
            DefaultColor(_defaultGradient);
            isTouchingZone = false;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Time.time - _time >= _timeBetweenSpawns)
            {
                _time = Time.time;
                _captureZone.gameObject.SetActive(false);
                Invoke(nameof(NewCaptureZone), _timeBreak);
            }
        }


        private void NewCaptureZone()
        {
            _timeBetweenSpawns = _timeBetweenSpawns;
            _pos = new Vector2(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY));
            transform.position = new Vector2(_pos.x, _pos.y);
            _captureZone.gameObject.SetActive(true);
        }

        public Gradient GetOuterGradient()
        {
            return _captureGradient;
        }

        public void SetOuterGradient(Gradient newcolorGradient)
        {
            _captureGradient = _captureGradient;
            var mainOuterZone = _captureZone.main;
            var mainInnerZone = _innerZone.main;
            mainOuterZone.startColor = _captureGradient;
            mainInnerZone.startColor = _captureGradient;
        }
        
        public void DefaultColor(Gradient defaultcolorGradient)
        {
            _captureGradient = defaultcolorGradient;
            var mainOuterZone = _captureZone.main;
            var mainInnerZone = _innerZone.main;
            mainOuterZone.startColor = _defaultGradient;
            mainInnerZone.startColor = _defaultGradient;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isTouchingZone = true;
                print("You are touching the zone");
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isTouchingZone = false;
                print("You are leaving the zone");
            }
        }
    }
}
