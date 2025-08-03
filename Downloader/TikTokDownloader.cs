using System.Text.Json;

namespace TiktokAudioConverter.Downloader;
using System.Diagnostics;



public class DownloadResult
{
   public string VideoPath { get; set; } = string.Empty;
   public string? Title { get; set; }
   public string? Uploader { get; set; }
   public string? UploadDate { get; set; }
   public string? Description { get; set; }
   public string? TikTokUrl { get; set; }

   public string Print()
   {
      return $"Title: {Title}, Uploader: {Uploader}, Url: {TikTokUrl}";
   }


   public static void UpdateMetadata(DownloadResult obj, string filePath)
   {
      string infoJsonPath = Path.ChangeExtension(filePath, ".info.json");
      if (File.Exists(infoJsonPath))
      {
         string json = File.ReadAllText(infoJsonPath);
         using var doc = JsonDocument.Parse(json);
         var root = doc.RootElement;
         
         obj.Title = root.GetProperty("title").GetString();
         obj.Uploader = root.GetProperty("uploader").GetString();
         obj.UploadDate = root.GetProperty("upload_date").GetString();
         obj.Description = root.GetProperty("description").GetString();
         
      }
   }

}



public class TikTokDownloader
{
   private string _savePath = "/Users/jabez/Desktop/TiktokAudioConverter.CLI/VideoAudioLibrary";
   public DownloadResult? DownloadVideo(string link)
   
   {
      try
      {
         Directory.CreateDirectory(_savePath);
         var args = $"-o \"{_savePath}/%(title)s.%(ext)s\" --restrict-filenames --no-playlist --print after_move:filepath --write-info-json {link}"; 
         var process = new Process
         {
            StartInfo = new ProcessStartInfo
            {
               FileName = "yt-dlp",
               Arguments = args,
               RedirectStandardOutput = true,
               RedirectStandardError = true,
               UseShellExecute = false,
               CreateNoWindow = true
            }
         };
         process.Start();
         
         string filePath = process.StandardOutput.ReadToEnd().Trim();
         string error = process.StandardError.ReadToEnd();

         process.WaitForExit();

         if (process.ExitCode != 0)
         {
            Console.WriteLine("yt-dlp failed: \n" + error);
            return null;
         }

         Console.WriteLine("yt-dlp output:\n" + filePath);
         var result = new DownloadResult
         {
            VideoPath = filePath,
            Title = "..",
            Uploader = "..",
            UploadDate = "...",
            Description = "...",
            TikTokUrl = link
         };
         return result;
      }
      catch (Exception ex)
      {
         Console.WriteLine("Error during download: " + ex.Message);
         return null;
      }
   }
}