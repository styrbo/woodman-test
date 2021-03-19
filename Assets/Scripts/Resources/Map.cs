using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Resources
{
    public static class Map
    {
        public static event Action OnResourcesCreated;
        
        private static HashSet<ResourcesSource> Sources { get; } = new HashSet<ResourcesSource>();

        public static bool TryGetNearest(Vector2 position, out ResourcesSource source)
        {
            source = null;

            if (Sources.Count == 0)
                return false;

            source = Sources.OrderBy(resourcesSource => Vector2.Distance(position, resourcesSource.transform.position))
                .First();

            return true;
        }

        internal static void AddSource(ResourcesSource source)
        {
            Sources.Add(source);
            OnResourcesCreated?.Invoke();
        }

        internal static void RemoveSource(ResourcesSource source)
        {
            Sources.Remove(source);
        }
    }
}