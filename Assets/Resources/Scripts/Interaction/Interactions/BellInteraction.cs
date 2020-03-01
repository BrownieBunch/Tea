using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
namespace Resources.Scripts.Interaction.Interactions
{ 
public class BellInteraction : BaseInteraction
{
        SceneManagerLocal sceneManagerLocal;

    // Use this for initialization
    void Start()
    {
            sceneManagerLocal = FindObjectOfType<SceneManagerLocal>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void RunAction()
    {
        if  (sceneManagerLocal != null)
            {
                sceneManagerLocal.Reload();
            }
    }
}

}