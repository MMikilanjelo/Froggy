using UnityEngine;

namespace Selection.Responses{
    public class HightLightSelectionResponse : MonoBehaviour, ISelectionResponse
    {
        [SerializeField] public Material hightLightMaterial;
        [SerializeField] public Material defaultMaterial;
        public void OnDeselect(Transform selection)
        {
            var selectionRenderer = selection.GetComponent<SpriteRenderer>();
            if(selectionRenderer != null){
                selectionRenderer.material = defaultMaterial;
            }
        }

        public void OnSelect(Transform selection)
        {
            var selectionRenderer = selection.GetComponent<SpriteRenderer>();
            if(selectionRenderer != null){
                selectionRenderer.material = hightLightMaterial;
            }
        }
    }
}

