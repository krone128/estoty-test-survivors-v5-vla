using UnityEngine;

namespace Code.Gameplay.Movement.Behaviours
{
    public class SpriteDirectionController : MonoBehaviour {
        
        private IMovementDirectionProvider _movementDirectionProvider;
        private void Awake()
        {
            _movementDirectionProvider = GetComponent<IMovementDirectionProvider>();
        }

        private void Update()
        {
            transform.localScale = new Vector3(Mathf.Sign(_movementDirectionProvider.GetDirection().x), 1, 1);
        }
    }
}