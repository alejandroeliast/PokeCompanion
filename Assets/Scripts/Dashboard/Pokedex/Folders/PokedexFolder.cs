using System;
using UnityEngine;

namespace Pokedex
{
    public class PokedexFolder : MonoBehaviour
    {
        public bool IsActive { get; protected set; }
        public PokedexIndex Index { get; protected set; }

        protected int _id;
        protected Event _event;
        protected PokedexFolderStyle _style;

        public static event Action<int> OnSelected;
        public static event Action<int> OnShiftSelected;
        public static event Action<int> OnDeselected;

        protected virtual void Start()
        {
            
            _style = GetComponent<PokedexFolderStyle>();
        }

        public virtual void OnInteract()
        {
            IsActive = !IsActive;

            if (IsActive)
            {
                _style.SetActive();
                if (_event.shift)
                    OnShiftSelected?.Invoke(_id);
                else
                    OnSelected?.Invoke(_id);
            }
            else
            {
                _style.SetInactive();
                OnDeselected?.Invoke(_id);
            }
        }

        private void OnGUI()
        {
            _event = Event.current;
        }

        public virtual void SetID(int id)
        {
            _id = id;
        }

        public virtual void SetDeselected()
        {
            IsActive = false;
            _style.SetInactive();
        }
    }
}