﻿using GameEngine;
using GameEngine.GameElements.Characters;
using GameEngine.UserInterface;
using System.Reflection.Metadata.Ecma335;

namespace TheLastBite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Application.Setup();

                Inputs.KeyPressedEvent += Inputs.OnKeyPressed;

                Inputs.MouseButtonDownEvent += Inputs.OnMouseButtonPressed;
                Inputs.MouseButtonUpEvent += Inputs.OnMouseButtonReleased;

                while (true)
                {
                    Inputs.Handler();
                    Graphics.Render(Application.Renderer);
                }
            }
            catch (Exception exception)
            {
                Log.Error("Fatal error occured in Main() function!", exception.Message);
            }
        }
    }
}