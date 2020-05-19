using UnityEngine;

namespace Invector
{
    public  class vMonoBehaviour : MonoBehaviour
    {
        [SerializeField] protected Camera MyCam;
        [SerializeField, HideInInspector]
        private bool openCloseEvents ;
        [SerializeField, HideInInspector]
        private bool openCloseWindow;
        [SerializeField, HideInInspector]       
        private int selectedToolbar;
    }  
}
