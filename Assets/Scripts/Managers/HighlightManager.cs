using UnityEngine;
using Selection;
using Selection.RayProviders;
using Selection.Selectors;
using Game.Utilities.Singletons;
namespace Game.Mangers
{
    public class HighlightManager : Singleton<HighlightManager>
    {

        private IRayProvider rayProvider_;
        private ISelectionResponse selectionResponse_;
        private ISelector selector_;
        private Transform currentSelection_;
        protected override void Awake(){
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
