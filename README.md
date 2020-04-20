# VideoConverterUtils

## Description

C# .NET Core program to convert videos to HEVC .MP4 and to go from HEVC .MKV to HEVC.MP4 with FFMPEG.

## How to use it

Under de ```/resources``` folder are stored the txt files where the target files and folders' paths should be placed, ie: ```Z:\Media\Movies\Avengers Endgame.mkv``` to proccess one file or ```Z:\Media\Movies\Harry Potter\``` to do it in a hole folder, with .mkv, .mp4, .mov, .avi, .mts or .m2ts files.

The two use cases are:

- **Encode a file from any given format to HEVC (with NVIDIA codec) in a .MP4 container** (folder  ```/resources/mp4_hevc/```), and 
- **Change an HEVC file container from .MKV to .MP4** (folder  ```/resources/mkv_mp4/```)

After that, because the app is made with .NET core, compile it with your IDE of choice an run it. A CLI will pop-up and start the process automatically.

If you want the ffmpeg commands:

- ```ffmpeg -i "input.ext" -c: hevc_nvenc -crf 28 -acodec copy "output.ext"```
- ```ffmpeg -i "input.ext" -vcodec copy  -acodec copy -scodec copy -y "output.ext```

## License

Licensed under MIT, so use it or modify it as needed.