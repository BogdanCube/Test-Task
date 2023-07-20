using UnityEngine;
using UnityEngine.SceneManagement;

namespace Base
{
    public class RestarterScene : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}