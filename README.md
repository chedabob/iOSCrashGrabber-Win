iOSCrashGrabber-Win
===================

Tool for retrieving specific crash logs from an iTunes backup

Consists of two apps:
- One to build the retrieval app so it only searches for specific logs (iOSCrashGrabberGen/Sonny)
- One to retrieve the logs and zip them up (iOSCrashGrabber/Rico)

Build instructions:

Build Rico, then open a command prompt in the root of Sonny, and run ILMerge to merge ICSharpCode.SharpZipLib.dll into Rico.exe, then build Sonny.

This step is necessary as Rico.exe is an embedded resource and it requires the zip library. This behaviour isn't critical to the app functionality, but I wanted to ship a single .exe 
