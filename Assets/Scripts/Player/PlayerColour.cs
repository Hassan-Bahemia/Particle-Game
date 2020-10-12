using UnityEngine;

namespace Player
{
    public class PlayerColour : MonoBehaviour
    {
        [SerializeField] private Gradient _gradient;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private LineRenderer _lineRenderer;

        public Gradient GetColour()
        {
            return _gradient;
        }

        public void SetColour(Gradient newGradient)
        {
            _gradient = newGradient;
            var main = _particleSystem.main;
            main.startColor = _gradient;
            _lineRenderer.colorGradient = _gradient;
        }
    }
}