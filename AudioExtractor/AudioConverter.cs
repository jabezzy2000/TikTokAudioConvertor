using System.Diagnostics;
using TiktokAudioConverter.Downloader;



namespace TiktokAudioConverter.AudioExtractor;

public class AudioConverter
{
   private readonly string _audioOutputFolder = "/VideoAudioLibrary/Audio";

   private void _ImputeMetaData(string audioPath, DownloadResult meta)
   {
      Console.WriteLine(audioPath);
      Console.WriteLine(meta.Print());
      var file = TagLib.File.Create(audioPath);
      file.Tag.Title = meta.Title;
      file.Tag.Comment = meta.TikTokUrl;
      file.Tag.Performers = new[] {meta.Uploader ?? "Unknown"} ;
      file.Save();
      Console.WriteLine("Imputed MetaData");
   }

   public string? ConvertVideoToAudio(DownloadResult downloadResultObj)
   { // update this method to 1. use the new download result obj 2. update audio metadata
      try
      {
         string path = downloadResultObj.VideoPath;
         Directory.CreateDirectory(_audioOutputFolder);
         string videoFileName = Path.GetFileNameWithoutExtension(path);
         string outputAudioPath = Path.Combine(_audioOutputFolder, $"{videoFileName}.wav");

         string args = $"-i \"{path}\" -vn -acodec pcm_s16le -ar 44100 -ac 2 \"{outputAudioPath}\"";

         var process = new Process
         {
            StartInfo = new ProcessStartInfo
            {
               FileName = "ffmpeg",
               Arguments = args,
               RedirectStandardOutput = true,
               RedirectStandardError = true,
               UseShellExecute = false,
               CreateNoWindow = true
            }
         };
         process.Start();
         string output = process.StandardOutput.ReadToEnd();
         string error = process.StandardError.ReadToEnd();
         process.WaitForExit();

         if (process.ExitCode != 0)
         {
            Console.WriteLine("FFmpeg failed:\n" + error);
            return null;
         }

         _ImputeMetaData(outputAudioPath, downloadResultObj);
         return outputAudioPath;

      }
      catch (Exception ex)
      {
         Console.WriteLine("Audio conversion error: " + ex.Message);
         return null;
      }
   }
}