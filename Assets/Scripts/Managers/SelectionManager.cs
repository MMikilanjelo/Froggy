using UnityEngine;
using Selection;
using Selection.RayProviders;
using Selection.Selectors;
namespace Managers
{
    public class SelectionManager : MonoBehaviour
    {
        private IRayProvider rayProvider_;
        private ISelectionResponse selectionResponse_;
        private ISelector selector_;
        private Transform currentSelection_;
        public static SelectionManager Instance {get;private set;}
        private void Awake(){
            Instance = this;
            selectionResponse_ = GetComponent<ISelectionResponse>();
            selector_ = new RayCastBasedTagSelector();
            rayProvider_ = new MouseScreenRayProvider();
        }
        private void Update(){
            if(currentSelection_ != null){
                selectionResponse_?.OnDeselect(currentSelection_);
            }
            
            selector_.Check(rayProvider_.CreateRay());
            currentSelection_ = selector_.GetSelection();
            
            if(currentSelection_ != null){
                selectionResponse_?.OnSelect(currentSelection_);
            }
        }
    }
}
