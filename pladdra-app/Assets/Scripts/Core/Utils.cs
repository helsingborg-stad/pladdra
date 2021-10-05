using UnityEngine;

namespace Pladdra.Core
{
    public static class Utils
    {
        public static Bounds CalculateBoundsFromChildren(GameObject gameObject)
        {
            Renderer[] allChildren = gameObject.GetComponentsInChildren<Renderer>();

            Vector3 center = gameObject.transform.position;
            foreach (Renderer child in allChildren)
            {
                center += child.bounds.center;
            }
            center /= allChildren.Length;

            Bounds bounds = new Bounds(center, Vector3.zero);
            foreach (Renderer child in allChildren)
            {
                bounds.Encapsulate(child.bounds);
            }

            Vector3 centerWithRelativeOffset = ((bounds.center - gameObject.transform.position) / gameObject.transform.localScale.x);
            Vector3 sizeWithRelativeOffset = (bounds.size / gameObject.transform.localScale.x);

            return new Bounds(centerWithRelativeOffset, sizeWithRelativeOffset);
        }
    }
}