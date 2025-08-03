using TiktokAudioConverter.Downloader;
using TiktokAudioConverter.AudioExtractor;

namespace TiktokAudioConverter;




public class Converter
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Paste Tiktok link or input 'Quit' to end program:");
            string? userResponse = Console.ReadLine();
            if (userResponse == null)
            {
                Console.WriteLine("Please input a valid tiktok link else input 'quit' to end session");
            }
            
            else if (userResponse.ToLower() == "quit")
                break;
            // quick validation of user input
            
            else
            {
                //cleaning user input
                string tiktokLink = userResponse.Trim();
                
                //download video
                var downloader = new TikTokDownloader();
                DownloadResult? response = downloader.DownloadVideo(tiktokLink);
                if (response == null)
                {
                    Console.WriteLine("Could not download tiktok link '" + tiktokLink + "'");
                    continue;
                }

                Console.WriteLine($"Successfully Downloaded Video at path : {response.VideoPath}");
                //convert video to audio
                var converter = new AudioConverter();
                string? audio = converter.ConvertVideoToAudio(response); // returns path to audio
                if (audio == null)
                {
                    Console.WriteLine("Could not convert tiktok link '" + tiktokLink + "'");
                    continue;
                }
                //post_process audio to include metadata - do later
                Console.WriteLine($"Audio converted and saved to {audio}");
                
            }
        }

        
        
        // validate + download using tiktok downloader
        // extract audio using audioconverter
        // print metadata using meta datasaver
    }

}