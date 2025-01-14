﻿using GameEngine.GameElements;
using GameEngine.GameElements.Characters;
using GameEngine.UserInterface;
using System.Linq.Expressions;
using static SDL2.SDL;

namespace GameEngine
{
    public class Inputs
    {
        public static int MouseMotionX, MouseMotionY;
        public static int MouseButtonDownX, MouseButtonDownY;
        public static int MouseClickedX, MouseClickedY;
        public static bool MouseLeftButtonClicked, MouseRightButtonClicked;

        public delegate void KeySymbleDelegate(SDL_Keysym keysym);
        public delegate void MouseButtonDelegate(SDL_MouseButtonEvent mousebtn);

        public static event KeySymbleDelegate? KeyPressedEvent;
        public static event KeySymbleDelegate? KeyReleasedEvent;
        public static event MouseButtonDelegate? MouseButtonDownEvent;
        public static event MouseButtonDelegate? MouseButtonUpEvent;

        public static GameManager manager = Graphics.manager;

        public static void Handler()
        {
            try
            {
                while (SDL_PollEvent(out SDL_Event events) == 1)
                {
                    switch (events.type)
                    {
                        case SDL_EventType.SDL_QUIT:
                            SDL_Quit();
                            Application.Close();
                            Environment.Exit(0);
                            break;

                        case SDL_EventType.SDL_KEYDOWN:
                            KeyPressedEvent?.Invoke(events.key.keysym);

                            break;

                        case SDL_EventType.SDL_KEYUP:
                            KeyPressedEvent?.Invoke(events.key.keysym);

                            break;

                        case SDL_EventType.SDL_MOUSEBUTTONDOWN:
                            MouseButtonDownEvent?.Invoke(events.button);

                            MouseButtonDownX = events.motion.x;
                            MouseButtonDownX = events.motion.y;

                            break;

                        case SDL_EventType.SDL_MOUSEBUTTONUP:
                            MouseButtonUpEvent?.Invoke(events.button);

                            break;

                        case SDL_EventType.SDL_MOUSEMOTION:
                            MouseMotionX = events.motion.x;
                            MouseMotionY = events.motion.y;

                            break;

                        default:
                            break;
                    }

                    manager.player.HandleInputs(events);
                }
            }
            catch (Exception exception)
            {
                Log.Error("Error in the Handler() function", exception.Message);
            }
        }

        public static void OnKeyPressed(SDL_Keysym keysym)
        {
            if (keysym.scancode == SDL_Scancode.SDL_SCANCODE_A || keysym.scancode == SDL_Scancode.SDL_SCANCODE_LEFT)
            {

            }

            if (keysym.scancode == SDL_Scancode.SDL_SCANCODE_D || keysym.scancode == SDL_Scancode.SDL_SCANCODE_RIGHT)
            {
            }

            if (keysym.scancode == SDL_Scancode.SDL_SCANCODE_E)
            {
            }
        }

        public static void OnMouseButtonPressed(SDL_MouseButtonEvent mousebtn)
        {
            if (mousebtn.button == SDL_BUTTON_LEFT)
            {
                MouseClickedX = mousebtn.x;
                MouseClickedY = mousebtn.y;

                MouseLeftButtonClicked = true;
            }

            if (mousebtn.button == SDL_BUTTON_RIGHT)
            {
                MouseClickedX = mousebtn.x;
                MouseClickedY = mousebtn.y;

                MouseRightButtonClicked = true;
            }
        }

        public static void OnMouseButtonReleased(SDL_MouseButtonEvent mousebtn)
        {
            if (mousebtn.button == SDL_BUTTON_LEFT)
            {
                MouseLeftButtonClicked = false;
            }

            if (mousebtn.button == SDL_BUTTON_RIGHT)
            {
                MouseRightButtonClicked = false;
            }
        }
    }
}
