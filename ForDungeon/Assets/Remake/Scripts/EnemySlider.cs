using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Remake
{
    public class EnemySlider : MonoBehaviour
    {
        private RectTransform _sliderRectTransform;
        private Transform _cameraTransform;
        private Slider _slider;
        private void Awake()
        {
            _sliderRectTransform = GetComponent<RectTransform>();
            _cameraTransform = Camera.main.transform;
            _slider = GetComponent<Slider>();
        }
        private void Update()
        {
            _sliderRectTransform.LookAt(_cameraTransform);
        }

        public Slider GetSlider()
        {
            return _slider;
        }
    }
}
