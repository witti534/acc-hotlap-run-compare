# ACC Hotlap Run Compare

This tool is used to record and compare the own runs from the Hotlap gamemode in the game Assetto Corsa Competizione. It automatically gathers data while driving and saves them so one can compare the different runs at a later point.

## Requirements

- .NET runtime (program will tell you if it is not installed)

## How to use

- Start this program
- Start Assetto Corsa Competizione in the Hotlap game mode
- Start driving, live data appears after crossing the first sector line
- Run will automatically be saved when crossing the finish line
- Compare runs with each other

- For test purposes runs can be generated in the Debug tab

## Features

- Automatically record runs : Get the sector time of each sector, get the lap times, get the fastest lap time
- Save run information
- Live position during a run: Be able to see your current run compared to the other runs (same track, same car, same session length)
![MainTabLiveRunInfo](https://private-user-images.githubusercontent.com/19347984/365697719-07b8710f-8f22-4f3d-a2be-e71a03e290bd.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MjU4OTQwNTAsIm5iZiI6MTcyNTg5Mzc1MCwicGF0aCI6Ii8xOTM0Nzk4NC8zNjU2OTc3MTktMDdiODcxMGYtOGYyMi00ZjNkLWEyYmUtZTcxYTAzZTI5MGJkLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDA5MDklMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwOTA5VDE0NTU1MFomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTJhNmIyOTM2MzdlNjUyMWQ2OTU5ZGU4MmFmNTg5Nzk0NzNmYjIyZmQxNDAxNjJhNmZmNDk2ZjdiYjQ1ZTZjZDEmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.U-dC5nuJGCb-iKXVw3hYLPEmuZ-RHK20-RG8pH_gcGY)
- Display recorded runs
  - See total time, amount of laps, fastest lap time
  - Sort by total time, fastest lap time or by the day it was recorded
![MainTabDisplayRecordedRuns](https://private-user-images.githubusercontent.com/19347984/365698520-6559a3ab-406d-4751-8251-1a31291b29a6.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MjU4OTQzOTEsIm5iZiI6MTcyNTg5NDA5MSwicGF0aCI6Ii8xOTM0Nzk4NC8zNjU2OTg1MjAtNjU1OWEzYWItNDA2ZC00NzUxLTgyNTEtMWEzMTI5MWIyOWE2LnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDA5MDklMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwOTA5VDE1MDEzMVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTU5ZTRiZTdlOTE0N2FjYzQyY2ZlY2Q4NzdiNzcwYmUxNDQxOWZmMGE2OWNkYTA1OWVjODVmNGVkN2RjMDczNGMmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.Us10o-_NFaGFrS1_MURNU8Ibg9bocozNDqyUdN-7X7o)
- Display information about a finished runs
  - Add information to finished runs: Add a description to the run (e.g. setup name, weather conditions, ... )
  - Display of sector times
  - Direct comparison between multiple runs
![CompareRunsFrame](https://private-user-images.githubusercontent.com/19347984/365701239-2156f6fd-8f82-49d1-a24c-f1fa41789b89.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MjU4OTQzOTEsIm5iZiI6MTcyNTg5NDA5MSwicGF0aCI6Ii8xOTM0Nzk4NC8zNjU3MDEyMzktMjE1NmY2ZmQtOGY4Mi00OWQxLWEyNGMtZjFmYTQxNzg5Yjg5LnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDA5MDklMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwOTA5VDE1MDEzMVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTI4NDNhOGQyMjk2ZjYwYTA1NmQ4MTRjNGIzOWRkNzkxY2M5MmJhNzRlMDY4MmJhMDM4NDQ2MjJjYzMwMjEyOGMmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.425yFQ3Ps469Aubo9wxvMrPsUYo6ZYiz2D_3DjJnPQk)
- Import/Export runs (compare with friends)

## Planned for the future

- Adding graphs to run comparison
