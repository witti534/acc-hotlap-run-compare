# ACC Hotrun Run Compare

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
![MainTabLiveRunInfo](https://i.ibb.co/Bgd24X8/Screenshot-2024-10-30-165204.png)
- Display recorded runs
  - See total time, amount of laps, fastest lap time
  - Sort by total time, fastest lap time or by the day it was recorded
![MainTabDisplayRecordedRuns](https://i.ibb.co/YpCB2dh/Screenshot-2024-10-30-170441.png)
- Display information about a finished runs
![DisplaySingleRunFrame](https://i.ibb.co/C61MC9d/Screenshot-2024-10-30-165811.png)
  - Add information to finished runs: Add a description to the run (e.g. setup name, weather conditions, ... )
  - Display of sector times
  - Direct comparison between multiple runs
![CompareMultipleRunsFrame](https://i.ibb.co/9VmmqXk/Screenshot-2024-10-30-165832.png)
- Import/Export runs (compare with friends)

## Planned for the future

- Adding graphs to run comparison
