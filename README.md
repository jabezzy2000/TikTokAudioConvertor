🎵 TikTok Audio Converter

One bus ride. One perfect TikTok cover. One saturday project.

While heading home, I came across a beautiful cover of one of my favorite songs on TikTok—and all I wanted was to save that audio and loop it forever. I’m sure there are tools out there already, but I figured: why not build my own solution and learn C# along the way?

Thus, TikTokAudioConverter was born—a command-line tool that: 
Accepts a TikTok video link, Downloads the video, Converts it to audio (.wav), Embeds metadata (title, uploader, original TikTok URL)
and Saves the result to your local library

It’s a personal, nerdy way to collect your favorite TikTok sounds.

⸻

1.	Clone the project
```bash
git clone https://github.com//TikTokAudioConverter.git
cd TikTokAudioConverter.CLI
```
2.	Build the project
```bash
dotnet build
```
3.	Run the CLI
```bash
dotnet run
```
4.	Paste any TikTok link when prompted or Type "Quit" to exit




🔜 Future Plans
•	WPF GUI version
•	Support for .mp3 output
•	Add album art from video frames
•	Batch conversion from a list of TikTok links

⸻

Built for fun. Learned a ton. Hope you enjoy using it ✨