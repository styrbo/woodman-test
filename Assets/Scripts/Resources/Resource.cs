using UnityEngine;

namespace Resources
{
    [CreateAssetMenu]
    public class Resource : ScriptableObject
    {
        [SerializeField] private Sprite _icon;

        public Sprite Icon => _icon;
    }
}