namespace SpaceInvaderEmulator
{
    public static class Assets
    {
        public static string BYAH_BMP = "../ASSETS/byah-brooker2x-0.bmp";
        public static string LOAD_BPM_ERR = $"Unable to load image {BYAH_BMP}";
    }

    public static class Constants
    {
        public static uint DELAY = 5000;
        public const int SCREEN_WIDTH = 256;
        public const int SCREEN_HEIGHT = 224;

        public static int MAGNIFY = 1;
        public static string SDL_INITIALIZE_ERROR = "SDL could not initialize! SDL_Error: ";
        public static string WINDOW_NOT_CREATED_ERROR = "Window could not be created! SDL_Error:";
    }
    public static class Errors
    {
        public static string INITIALIZE_DISPLAY = "";
    }


}