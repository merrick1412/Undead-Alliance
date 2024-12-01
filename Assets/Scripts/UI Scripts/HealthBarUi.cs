using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthBarUi {
    public class HealthBarUi : MonoBehaviour
    {
        [SerializeField]
        private UnityEngine.UI.Image hpForeGround;
        public void UpdateHealthBar(PlayerHealthController hc)
        {
            hpForeGround.fillAmount = hc.healthPercent;
        }
    }
}
