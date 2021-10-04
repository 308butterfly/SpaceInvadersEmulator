using System;
using SDL2;

namespace SpaceInvaderEmulator
{
    public static class Screen
    {
        private static IntPtr gWindow = IntPtr.Zero;
        private static IntPtr gScreenSurface = IntPtr.Zero;
        private static IntPtr gBYAH = IntPtr.Zero;
        public static bool Init()
        {
            bool isInitialzed = true;

            // Initialize SDL
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) > -1)
            {
                gWindow = SDL.SDL_CreateWindow(
                "BYAH!!!!!",
                SDL.SDL_WINDOWPOS_CENTERED,
                SDL.SDL_WINDOWPOS_CENTERED,
                Constants.SCREEN_WIDTH,
                Constants.SCREEN_HEIGHT,
                SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE
                );

                if (gWindow != null)
                {
                    gScreenSurface = SDL.SDL_GetWindowSurface(gWindow);
                }
                else
                {
                    Console.WriteLine($"{Constants.WINDOW_NOT_CREATED_ERROR}{SDL.SDL_GetError()}");
                }
            }

            else
            {
                Console.WriteLine($"{Constants.SDL_INITIALIZE_ERROR}{SDL.SDL_GetError()}");
            }

            return isInitialzed;
        }

        public static bool LoadMedia()
        {
            bool isLoaded = false;

            // Load Image
            gBYAH = SDL.SDL_LoadBMP(Assets.BYAH_BMP);

            if (gBYAH != null)
            {
                isLoaded = true;
            }
            else
            {
                Console.WriteLine(Assets.LOAD_BPM_ERR);
            }
            return isLoaded;
        }

        public static void Close()
        {
            SDL.SDL_FreeSurface(gBYAH);
            gBYAH = IntPtr.Zero;
            SDL.SDL_DestroyWindow(gWindow);
            gWindow = IntPtr.Zero;
            SDL.SDL_Quit();
        }
        public static void Display()
        {
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

            var window = IntPtr.Zero;
            window = SDL.SDL_CreateWindow(
                "BYAH!!!!!",
                SDL.SDL_WINDOWPOS_CENTERED,
                SDL.SDL_WINDOWPOS_CENTERED,
                1020,
                800,
                SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE
            );

            SDL.SDL_Delay(5000);

            SDL.SDL_Event e;
            bool quit = false;
            while (!quit)
            {
                while (SDL.SDL_PollEvent(out e) != 0)
                {
                    switch (e.type)
                    {
                        case SDL.SDL_EventType.SDL_QUIT:
                            quit = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            SDL.SDL_DestroyWindow(window);

            SDL.SDL_Quit();
        }

        public static void Display2()
        {
            if (!Init())
            {
                Console.WriteLine(Constants.WINDOW_NOT_CREATED_ERROR);
            }
            else
            {
                if (!LoadMedia())
                {
                    Console.WriteLine(Assets.LOAD_BPM_ERR);
                }
                else
                {
                    SDL.SDL_BlitSurface(gBYAH, IntPtr.Zero, gScreenSurface, IntPtr.Zero);
                    SDL.SDL_UpdateWindowSurface(gWindow);
                    SDL.SDL_Delay(Constants.DELAY);
                }
            }
            Close();
        }
    }
}