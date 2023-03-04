using AndreyGritsenko.MonoECS.Core;
using UnityEngine;

namespace AndreyGritsenko.MonoECS.Example
{
    public sealed class ExampleComponent : EntityComponent<ExampleComponent>
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _rowX;
        [SerializeField] private float _rowZ;
        [SerializeField] private float _offset;
        [SerializeField] private int _count;

        public GameObject Prefab => _prefab;
        public float RowX => _rowX;
        public float RowZ => _rowZ;
        public float Offset => _offset;
        public int Count => _count;
        
        protected override void OnEntityCreate() { }
        protected override void OnEntityEnable() { }
        protected override void OnEntityDisable() { }
    }
}