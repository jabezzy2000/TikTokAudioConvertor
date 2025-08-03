🎵 TikTok Audio Converter

>One bus ride. One perfect TikTok cover. One Saturday project.

While heading home, I came across a beautiful cover of one of my favorite songs on TikTok—and all I wanted was to save that audio and loop it forever. I’m sure there are tools out there already, but I figured: why not build my own solution and learn C# along the way?

This is a command-line tool that:
	•	Accepts a TikTok video link
	•	Downloads the video
	•	Converts it to audio (.wav)
	•	Embeds metadata (title, uploader, original TikTok URL)
	•	Saves the result to your local library

It’s a personal, nerdy way to collect your favorite TikTok sounds.


⚙️ How to Use
	1.	Clone the project

git clone https://github.com/<your-username>/TikTokAudioConverter.git
cd TikTokAudioConverter.CLI



2. Build the project using:
dotnet build


3.	Run the CLI
dotnet run


4.	Paste any TikTok link when prompted.
   
5.	The tool will:
	•	Download the video
	•	Convert it to .wav audio
	•	Add metadata
	•	Save the file to VideoAudioLibrary/Audio/
	
6.	Type quit to exit.

🔜 Future Plans ( maybe? maybe not )
	•	WPF GUI version
	•	Support for .mp3 and other outputs
	•	Add album art from video frames
	•	Batch conversion from a list of TikTok links

⸻

Built for fun. Learned a ton. Hope you enjoy using it ✨
