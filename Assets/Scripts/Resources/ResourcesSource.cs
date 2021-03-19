using UnityEngine;
using Zenject;

namespace Resources
{
    public class ResourcesSource : MonoBehaviour
    {
        [SerializeField] private Resource _resourceType;
        [SerializeField] private int _amount;

        public Resource ResourceType => _resourceType;

        public int Amount
        {
            get => _amount;
            private set
            {
                if (value <= 0)
                {
                    Map.RemoveSource(this);
                    print("wood gone!");
                    Destroy(gameObject);
                }
                
                _amount = value;
            }
        }


        private void Start()
        {
            Map.AddSource(this);
        }
        
        private void OnDestroy()
        {
            Map.RemoveSource(this);
        }

        public bool TryRequestResource()
        {
            if (Amount <= 0) return false;
            
            Amount -= 1;
            return true;
        }
    }
}
