using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class BonusView
    {
        private Text _bonusLabel;

        public BonusView(GameObject bonusLabelPrefab)
        {
            _bonusLabel = bonusLabelPrefab.GetComponent<Text>();
            _bonusLabel.text = string.Empty;
        }

        public void Display(int value) //int/string
        {
            _bonusLabel.text = $"Очки: {value}";
        }
    }
}
