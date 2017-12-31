using System;
using System.Threading;
		
namespace Xyz.Softwareeureka.ConsoleTools
{

    class Test
    {
        private const string TEST_DATA = "Press Ctrl+C to cancel...";
        static void Main() => ConsoleLoadingAnimation.Start(TEST_DATA);
    }


    /// A console loading animation made using these characters 
    /// (|, /, -, \,). A custom message can be attached to display
    /// to the user.
    public static class ConsoleLoadingAnimation
    {
        /// Default animation interval.
        private const int DEFAULT_INTERVAL = 250;

        /// Each Animation Stage.
        private static char[] stage0 = new char[] { '|', (char) 1},
                            stage1 = new char[] {'/', (char) 2},
                            stage2 = new char[] {'-', (char) 3},
                            stage3 = new char[] {'\\', (char) 4},
                            stage4 = new char[] {'|', (char) 5},
                            stage5 = new char[] {'/', (char) 6},
                            stage6 = new char[] {'-', (char) 7},
                            stage7 = new char[] {'\\', (char) 0};

        /// Animation loop flag. 
        private static bool running = false;

        /// A custom message displayed after each animation change.
        private static string message = " ";

        /// Starts the animation with the default interval.
        public static void Start()
        {
            running = true;
            new Thread(() => DisplayLoadAnim(DEFAULT_INTERVAL)).Start();
        }

        /// Starts the animation with the default interval and a 
        /// custom message.
        public static void Start(string new_message)
        {
            message = new_message;
            running = true;
            new Thread(() => DisplayLoadAnim(DEFAULT_INTERVAL)).Start();
        }

        /// Starts the animation with a custom interval.
        public static void Start(int frame_interval)
        {
            running = true;
            new Thread(() => DisplayLoadAnim(frame_interval)).Start();
        }

        /// Starts the animation with a custom interval and a
        /// custom message.
        public static void Start(int frame_interval, string new_message)
        {
            message = new_message;
            running = true;
            new Thread(() => DisplayLoadAnim(frame_interval)).Start();
        }

        /// Stops the animation loop.
        public static void Stop() => running = false;

        /// Sets the current animation message.
        public static void SetMessage(string new_message) => message = new_message;

        /// Loop which iterates through the animation. Once completed,
        /// it reiterates the animation. Animation is stop via Stop
        /// method.
        private static void DisplayLoadAnim(int interval)
        {
            char[] loading_sym = stage0;
            while(running)
            {
                string current_line = loading_sym[0] + " " + message;
                Console.Clear();
                Console.WriteLine(current_line);
                Thread.Sleep(interval);
                loading_sym = SetStage((byte) loading_sym[1]);
            }
            Console.WriteLine("Finished");
        }

        /// Sets the next animation stage using the current stage
        /// number. 
        private static char[] SetStage(byte stage)
        {
            switch(stage)
            {
                case 0: return stage0;
                case 1: return stage1;
                case 2: return stage2;
                case 3: return stage3;
                case 4: return stage4;
                case 5: return stage5;
                case 6: return stage6;
                case 7: return stage7;
            }
            return new char[0];
        }
    }
}
