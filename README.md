# DSA Visualizer

WinForms (.NET Framework 4.7.2) desktop app for visualizing data structures and algorithms. The current build focuses on animated sorting visualizations with runtime/space insights.

## Features
- Collapsible left navigation with sections for basics, binary trees, and sorting (sorting view implemented; other sections are stubbed).
- Sorting visualizer with adjustable input size (10, 100, 250, 500, 1000 bars) and animation speed controls.
- Algorithms implemented: Bubble Sort, Insertion Sort, Selection Sort, Quick Sort, Merge Sort (Bogo Sort and comparison view are placeholders).
- Live counters for comparisons and swaps, plus pause/resume and reset to replay the animation.
- Analysis side panel: Big‑O chart overlay, runtime/space complexity outputs, and algorithm descriptions.

## Project Structure
- `DSA_Visualizer/Program.cs` — application entry point.
- `DSA_Visualizer/HomePageForm.*` — main shell with collapsible sidebar and content host panel.
- `DSA_Visualizer/Sorting_Forms/SortingVisualizer/` — sorting UI (`sortingVisualizerForm`), rectangle drawing/animation (`RectangleManger`, `ColoredRectangle`), complexity panel (`AnalysisManager`), and algorithm implementations.
- `DSA_Visualizer/Basics_Forms/` — placeholders for linked list and queue visualizations.
- `DSA_Visualizer/Resources/` — images used in the UI.

## Run the App
1) Prereqs: Windows, Visual Studio 2019+ (or compatible), .NET Framework 4.7.2 targeting pack.  
2) Open `DSA_Visualizer.sln` in Visual Studio.  
3) Set startup project to `DSA_Visualizer` if needed, choose Debug/Release, and run (F5/Ctrl+F5).

## Using the Sorting Visualizer
- Select input size with the top trackbar (10–1000 bars) and pick an algorithm from the dropdown.
- Adjust animation speed with the speed trackbar (left = slower, right = faster).
- Click `Sort` to start; the button toggles Pause/Resume while running. `Reset` stops the animation and restores the current dataset.
- Hover over the slider icon on the right to open the analysis panel and view complexity plots/descriptions.
- Comparisons and swaps update live in the footer.

## Notes & Future Work
- Basics and binary tree pages are not wired yet; queue/linked list forms are empty scaffolds.
- The “Compare Algorithms” button and Bogo Sort are placeholders.
- Additional data structures/algorithms can be added by creating new forms and wiring their tags on the navigation buttons.

## Credits
- Author: Randy
  
