using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
   private static InteractionManager interactionManager;


   private void Awake() {
    interactionManager = this;
   }

   public static InteractionManager getInstance() {
    if(interactionManager == null) {
        interactionManager = new InteractionManager();
    }

    return interactionManager;
   }

   public void initInteraction(GameObject obj, int interaction_num) {

        

   }


}
