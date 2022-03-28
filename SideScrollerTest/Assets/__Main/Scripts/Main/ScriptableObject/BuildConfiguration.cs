using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;


namespace General.Configurations
{
    public interface IBuildConfiguration
    {
        
    }

    public class BuildConfiguration : ScriptableObject, IBuildConfiguration
    {

        public BuildController SelectedController;
        



      
        
    }

   

    public enum BuildController
    {
        Keyboard,
        Joystick
    }
}