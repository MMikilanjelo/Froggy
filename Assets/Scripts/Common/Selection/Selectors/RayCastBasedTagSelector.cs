
using TMPro;
using UnityEngine;

namespace Selection.Selectors
{
    public class RayCastBasedTagSelector : ISelector
    {
        private string selectableTag = "Selectable";
        private Transform selection_;
        public void Check(Ray ray)
        {
            selection_ = null;

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                var selection = hit.transform;
                if (selection.CompareTag(selectableTag))
                {
                    selection_ = selection;
                }
            }
        }
        public Transform GetSelection()
        {
            return selection_;
        }
    }
}

