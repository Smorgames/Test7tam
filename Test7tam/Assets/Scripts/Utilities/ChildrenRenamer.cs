using UnityEngine;

namespace Utilities
{
    public class ChildrenRenamer : MonoBehaviour
    {
        public string ChildName;
        public int FirstChildNumber;
        
        public void RenameChildren()
        {
            var childCount = transform.childCount;

            for (var i = 0; i < childCount; i++)
            {
                var child = transform.GetChild(i);
                child.name = $"{ChildName} ({FirstChildNumber + i})";
            }
        }
    }
}