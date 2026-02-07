using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraMovement : MonoBehaviour
{
    float mDelta = 40; 
    public float speed = 35.0f;

    

    void Update()
    {
        if (!(Mouse.current.position.ReadValue().y <= 0 + mDelta) && !(Mouse.current.position.ReadValue().y >= Screen.height - mDelta) && !(Mouse.current.position.ReadValue().x  <= 0 + mDelta) && Mouse.current.position.ReadValue().x >= Screen.width - mDelta)
        {
            transform.localRotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y + speed * Time.deltaTime, transform.rotation.eulerAngles.z);

        }
        if (!(Mouse.current.position.ReadValue().y <= 0 + mDelta) && !(Mouse.current.position.ReadValue().y >= Screen.height - mDelta) && Mouse.current.position.ReadValue().x <= 0 + mDelta && !(Mouse.current.position.ReadValue().x >= Screen.width - mDelta))
        {
            transform.localRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y -speed * Time.deltaTime, transform.rotation.eulerAngles.z);

        }
        if (!(Mouse.current.position.ReadValue().y <= 0 + mDelta) && Mouse.current.position.ReadValue().y >= Screen.height - mDelta && !(Mouse.current.position.ReadValue().x <= 0 + mDelta) && !(Mouse.current.position.ReadValue().x >= Screen.width - mDelta))
        {
            transform.localRotation = Quaternion.Euler(transform.rotation.eulerAngles.x - speed * Time.deltaTime, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            
        }
        if (Mouse.current.position.ReadValue().y <= 0 + mDelta && !(Mouse.current.position.ReadValue().y >= Screen.height - mDelta) && !(Mouse.current.position.ReadValue().x <= 0 + mDelta) && !(Mouse.current.position.ReadValue().x >= Screen.width - mDelta))
        {
            transform.localRotation = Quaternion.Euler(transform.rotation.eulerAngles.x + speed * Time.deltaTime, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);


        }
    }
}
