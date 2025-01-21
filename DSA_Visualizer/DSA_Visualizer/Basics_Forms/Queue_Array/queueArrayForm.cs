using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.DataVisualization.Charting;
using DSA_Visualizer.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DSA_Visualizer.Basics_Forms.Queue_Array
{
    public partial class QueueArrayForm : Form
    {
        //============== Queue Variables ==============//
        public QueueArray queue = new QueueArray(10);

        //============== Sprite Animation Variables ==============//
        private const int Total_Idle_Frames = 6, Total_Death_Frames = 10, Total_Run_Frames = 8, Total_Spawn_Frames = 7, Total_Walk_Frames = 8;
        private int frameCountIdle, frameCountRun, frameCountDeath, frameCountSpawn, frameCountWalk, width, height, speedX = 2, speedY; //REMINDER: remove speedY if not used later
        private int[] transitionCounters;
        private PictureBox[] slimePictureBoxes;
        private TaskCompletionSource<bool> tcs; // maybe

        /* 
         * [x,y] - x determines pictureBox number
         * [0,0] - returns pictureBox0's x-coordinate
         * [0,1] - returns pictureBox0's y-coordinate
        */
        private int[,] originalPositions;

        /*
         *  animationToken = <animation>"<direction>
         *                   Animation: "i" - idle      
         *                              "r" - run 
         *                              "d" - death
         *                              "w" - walk
         *                              "s" - spawn
         *
         *                   Direction: "l" - left     
         *                              "r" - right 
         *                              "f" - front
         *                              "b" - back
        */
        private string[] animationTokens = new string[10];

        //============== Queue Class Implementation ==============//
        public class QueueArray
        {
            private string[] queue;
            private int size = 0, capacity = 0;
            public QueueArray(int queueCapacity)
            {
                queue = new string[queueCapacity];
                size = 0;
                capacity = queueCapacity;
            }

            public int GetSize() { return size; }
            public int GetCapacity() { return capacity; }
            public string GetValueAtIndex(int index)
            {
                if(index >= 0 && index <= size)
                {
                    return queue[index];
                }

                return null;
            }
            public void Enqueue(string input)
            {
                if (size >= capacity)
                {
                    return;
                }

                queue[size] = input;
                size++;
            }
            public string Dequeue()
            {
                if(size <= 0)
                {
                    return null;
                }

                string dequeuedValue = queue[0];

                //shift elements in array left by 1 index
                for (int i = 1; i < size; i++)
                {
                    queue[i - 1] = queue[i];
                }
                size--;

                return dequeuedValue;
            }
            public string GetFront()
            {
                if (size == 0)
                {
                    return "The queue is empty.";
                }

                return queue[0];
            }
            public void Clear()
            {
                for (int i = 0; i < size; i++)
                {
                    queue[i] = null;
                }
                size = 0;
            }
            public void Print()
            {
                if (size == 0)
                {
                    return;
                }
                
                for (int i = 0; i < size; i++)
                {
                    /*Console.WriteLine() crtl shift / */
                    Console.Write(queue[i] + " ");
                }
                Console.WriteLine("\n" + "Size: " + size + ", Capacity " + capacity);
            }
        };
        private void AnimateSlime(int slimePictureBoxIndex, PaintEventArgs e)
        {
            Console.WriteLine("Animate Queue Size: " + queue.GetSize());
            switch (animationTokens[slimePictureBoxIndex])
            {
                case "if":
                    /*Console.WriteLine("IDLE CALLED");
                    Console.WriteLine("Idle Frame:" + frameCountIdle);*/
                    DrawSlimeIdleFrontAnimation(e);
                    break;
                case "wl":
                    /*Console.WriteLine("WALK CALLED");
                    Console.WriteLine("Walk Frame: " + frameCountWalk);*/
                    DrawSlimeWalkLeftAnimation(e);
                    /*slimePictureBoxes[slimePictureBoxIndex].BringToFront();*/
                    /*Console.WriteLine("Index: " + slimePictureBoxIndex + ", (" + slimePictureBoxes[slimePictureBoxIndex].Location.X + ", " + slimePictureBoxes[slimePictureBoxIndex].Location.Y + ")");
                    Console.WriteLine("Need to match X with: " + originalPositions[slimePictureBoxIndex, 0]);*/
                    slimePictureBoxes[slimePictureBoxIndex].Left -= speedX;
                    if (slimePictureBoxes[slimePictureBoxIndex].Left == originalPositions[slimePictureBoxIndex - 1, 0])
                    {
                        animationTokens[slimePictureBoxIndex] = "if";
                        //Reset picturebox positions
                        for (int i = 0; i < queue.GetCapacity(); i++)
                        {
                            slimePictureBoxes[i].Location = new Point(originalPositions[i, 0], originalPositions[i, 1]);
                        }
                    }
                    break;
                case "df":
                    /*Console.WriteLine("DEATH CALLED");
                    Console.WriteLine("Death Frame: " + frameCountDeath);*/
                    DrawSlimeDeathFrontAnimation(e);
                    transitionCounters[slimePictureBoxIndex]++;
                    if (transitionCounters[slimePictureBoxIndex] == Total_Death_Frames)
                    {
                        animationTokens[slimePictureBoxIndex] = "null";
                        transitionCounters[slimePictureBoxIndex] = 0;
                    }
                    break;
                case "sf":
                    /*Console.WriteLine("SPAWN CALLED");
                    Console.WriteLine("Frame: " + frameCountSpawn);*/
                    DrawSlimeSpawnFrontAnimation(e);
                    transitionCounters[slimePictureBoxIndex]++;
                    if (transitionCounters[slimePictureBoxIndex] == Total_Spawn_Frames)
                    {
                        animationTokens[slimePictureBoxIndex] = "if";
                        transitionCounters[slimePictureBoxIndex] = 0;
                    }
                    break;
                case "rb":
                    /*Console.WriteLine("RUN CALLED");
                    Console.WriteLine("Frame: " + frameCountRun);*/
                    DrawSlimeRunBackAnimation_ShrinkOut(e, width, height);
                    /*width -= 8;*/
                    height-= 8;
                    if (width <= 0 || height <= 0)
                    {
                        animationTokens[slimePictureBoxIndex] = "null";
                    }
                    break;
                case "null":
                    /*Console.WriteLine("NULL CALLED");*/
                    DrawClearImage(e);
                    break;
                default:
                    /*Console.WriteLine("DEFAULT CALLED");*/
                    break;
            }
        }
        private void DrawClearImage(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Bitmap.FromFile("D:\\DSAVisualizerMaster\\DSA_Visualizer\\DSA_Visualizer\\Resources\\null.png"), new Point(0, 0));
        }
        private void DrawSlimeIdleFrontAnimation(PaintEventArgs e)
        {
            Console.WriteLine("DRAW: IDLE = " + frameCountIdle);
            Graphics g = e.Graphics;
            g.DrawImage(Bitmap.FromFile("D:\\DSAVisualizerMaster\\DSA_Visualizer\\DSA_Visualizer\\Resources\\QueueArray_resources\\Slime_PNG\\Slime1\\Idle\\Front\\tile" + frameCountIdle + ".png"), new Rectangle(64, 0, 64, 64));
        }

        private void DrawSlimeWalkLeftAnimation(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Bitmap.FromFile("D:\\DSAVisualizerMaster\\DSA_Visualizer\\DSA_Visualizer\\Resources\\QueueArray_resources\\Slime_PNG\\Slime1\\Walk\\Left\\tile" + frameCountWalk + ".png"), new Rectangle(0, 0, 64, 64));
        }

        private void DrawSlimeDeathFrontAnimation(PaintEventArgs e )
        {
            Graphics g = e.Graphics;
            g.DrawImage(Bitmap.FromFile("D:\\DSAVisualizerMaster\\DSA_Visualizer\\DSA_Visualizer\\Resources\\QueueArray_resources\\Slime_PNG\\Slime1\\Death\\Front\\tile" + frameCountDeath + ".png"), new Rectangle(0, 0, 64, 64));
        }

        private void DrawSlimeSpawnFrontAnimation(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Bitmap.FromFile("D:\\DSAVisualizerMaster\\DSA_Visualizer\\DSA_Visualizer\\Resources\\QueueArray_resources\\Slime_PNG\\Slime1\\Spawn\\Front\\tile" + frameCountSpawn + ".png"), new Rectangle(0, 0, 64, 64));
        }
        private void DrawSlimeRunBackAnimation_ShrinkOut(PaintEventArgs e, int width, int height)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Bitmap.FromFile("D:\\DSAVisualizerMaster\\DSA_Visualizer\\DSA_Visualizer\\Resources\\QueueArray_resources\\Slime_PNG\\Slime1\\Run\\Back\\tile" + frameCountRun + ".png"), new Rectangle(0, 0, width, height));
        }

        public QueueArrayForm()
        {
            InitializeComponent();
        }

        private void DisplayQueueBtn_Click(object sender, EventArgs e)
        {
            queue.Print();
        }
        private async void ClearBtn_Click(object sender, EventArgs e)
        {
            EnqueueBtn.Enabled = true;
            DequeueBtn.Enabled = false;
            frameCountDeath = 0;

            // Draw Death Animation for all slimes in the queue
            for (int i = 0; i < queue.GetSize(); i++)
            {
                animationTokens[i] = "df";
            }

            EnqueueBtn.Enabled = false;
            DequeueBtn.Enabled = false;
            await Task.Delay(1250);
            EnqueueBtn.Enabled = true;
            queue.Clear();
            ClearBtn.Enabled = false;
            AnimationTimer.Stop();
        }
        private void EnqueueBtn_Click(object sender, EventArgs e)
        {
            // init TaskCompleteSource, might need
            tcs = new TaskCompletionSource<bool>();

            string input = enqueueTxt.Text;
            input = input.Trim(); //rid of leading/trailing whitespace

            // Only valid strings gets enqueued (no only whitespace)
            if (!string.IsNullOrEmpty(input))
            {
                // Start slime sprite animation
                frameCountIdle = 0;
                frameCountSpawn = 0;
                animationTokens[queue.GetSize()] = "sf";
                AnimationTimer.Start();

                //Perform enqueue
                queue.Enqueue(input);
                if (queue.GetSize() >= queue.GetCapacity())
                {
                    EnqueueBtn.Enabled = false;
                }
            }

            if (queue.GetSize() > 0)
            {
                DequeueBtn.Enabled = true;
                ClearBtn.Enabled = true;
            }
        }
        private async void DequeueBtn_Click(object sender, EventArgs e)
        {
            // Perform Dequeue
            if (queue.GetSize() > 0)
            {
                //Reset animation frames and sprite size
                frameCountWalk = 0;
                frameCountIdle = 0;
                frameCountRun = 0;
                width = 64;
                height = 64;

                Console.WriteLine("DEQUEUE...");
                animationTokens[0] = "rb";
                for (int i = 1; i < queue.GetSize(); i++)
                {
                    animationTokens[i] = "wl";
                }

                DequeueBtn.Enabled = false;
                EnqueueBtn.Enabled = false;
                ClearBtn.Enabled = false;
                await Task.Delay(1250);
                animationTokens[0] = "if";
                animationTokens[queue.GetSize()] = "null";
                slimePictureBoxes[queue.GetSize()].Refresh();
                /*Console.WriteLine("------------------------------------------------------------" + queue.GetSize());*/
                //finish animating picturebox0, then dequeue, add more time //Original Pos: 266, 325 and 336, 325| New: 6 difference between pictureboxes
                queue.Dequeue();
            }

            // Button Configurations
            if (queue.GetSize() == 0)
            {
                DequeueBtn.Enabled = false;
                ClearBtn.Enabled = false;
                AnimationTimer.Stop();
            }

            if (queue.GetSize() > 0)
            {
                DequeueBtn.Enabled = true;
                ClearBtn.Enabled = true;
            }

            if (queue.GetSize() < queue.GetCapacity())
            {
                EnqueueBtn.Enabled = true;
            }
        }
        private void SlimePictureBox0_Paint(object sender, PaintEventArgs e)
        {
            AnimateSlime(0, e);
        }
        //NOTE: Need to optimize these picturebox paint functions...
        private void SlimePictureBox1_Paint(object sender, PaintEventArgs e)
        {
            AnimateSlime(1, e);
        }
        private void SlimePictureBox2_Paint(object sender, PaintEventArgs e)
        {
            AnimateSlime(2, e);
        }
        private void SlimePictureBox3_Paint(object sender, PaintEventArgs e)
        {
            AnimateSlime(3, e);
        }
        private void SlimePictureBox4_Paint(object sender, PaintEventArgs e)
        {
            AnimateSlime(4, e);
        }
        private void SlimePictureBox5_Paint(object sender, PaintEventArgs e)
        {
            AnimateSlime(5, e);
        }
        private void SlimePictureBox6_Paint(object sender, PaintEventArgs e)
        {
            AnimateSlime(6, e);
        }
        private void SlimePictureBox7_Paint(object sender, PaintEventArgs e)
        {
            AnimateSlime(7, e);
        }
        private void SlimePictureBox8_Paint(object sender, PaintEventArgs e)
        {
            AnimateSlime(8, e);
        }
        private void SlimePictureBox9_Paint(object sender, PaintEventArgs e)
        {
            AnimateSlime(9, e);
        }


        private void QueueArrayForm_Load(object sender, EventArgs e)
        {
            // Initial Button States
            DequeueBtn.Enabled = false;
            ClearBtn.Enabled = false;
            /*Console.WriteLine(SlimePictureBox0.Left + ", " + SlimePictureBox0.Top);*/

            // init Slime Picturebox array
            slimePictureBoxes = new PictureBox[10];
            for (int i = 0; i < queue.GetCapacity(); i++)
            {
                slimePictureBoxes[i] = (PictureBox)this.Controls["SlimePictureBox" + i.ToString()];
                slimePictureBoxes[i].BringToFront();
            }

            // init Slime Picturebox Original Coordinates
            originalPositions = new int[10,2];
            for (int i = 0; i < queue.GetCapacity(); i++)
            {
                originalPositions[i, 0] = slimePictureBoxes[i].Location.X;
                originalPositions[i, 1] = slimePictureBoxes[i].Location.Y;
            }

            // init transitionCounters Array
            transitionCounters = new int[10];

            // init animation frame counters and sprite size
            frameCountIdle = 0;
            frameCountRun = 0;
            frameCountDeath = 0;
            frameCountSpawn = 0;
            frameCountWalk = 0;
            width = 64;
            height = 64;
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            foreach (string token in animationTokens)
            {
                Console.Write(token + " | ");
            }
            //Animates Pictureboxes up to queue size
            for (int i = 0; i < queue.GetSize(); i++)
            {
                Console.WriteLine("Refresh Called for: " + i);
                slimePictureBoxes[i].Refresh();
            }


            //NEED TO BE INC AT DIFFERENT TIMES
            /*Console.WriteLine("Spawn: (" + frameCountSpawn + " + 1) " + "% " + Total_Spawn_Frames);
            Console.WriteLine("Run: (" + frameCountRun + " + 1) " + "% " + Total_Run_Frames);*/
            //Idea: Increment and Reset to 0 if last frame is reached

            frameCountSpawn = (frameCountSpawn + 1) % Total_Spawn_Frames;
            frameCountIdle = (frameCountIdle + 1) % Total_Idle_Frames; 
            frameCountDeath = (frameCountDeath + 1) % Total_Death_Frames;
            frameCountRun = (frameCountRun + 1) % Total_Run_Frames;
            frameCountWalk = (frameCountWalk + 1) % Total_Walk_Frames;
        }

        //add invis placeholder (stops timer when !visible)
    }
}
