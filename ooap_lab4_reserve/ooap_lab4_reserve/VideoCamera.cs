using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab4_reserve
{
    class VideoCamera
    {
        public void StartVideo()
        {
            Console.WriteLine("Starting video camera...");
        }
    }
    class VideoCallAdapter : Phone
    {
        private readonly VideoCamera _videoCamera;

        public VideoCallAdapter(VideoCamera videoCamera)
        {
            _videoCamera = videoCamera;
        }

        public void MakeCall()
        {
            Console.WriteLine("Making a video call:");
            _videoCamera.StartVideo();
        }
    }
}
