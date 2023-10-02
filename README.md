# Unity Vuforia Augmented Reality App

## Overview

This Unity application is designed for augmented reality experiences using Vuforia. It recognizes two different image targets, one representing Manchester United and the other Manchester City. The app responds differently to each target:

- When the Manchester United image target is detected, it plays a video related to Manchester United.
- When the Manchester City image target is detected, it displays a 3D sphere in front of the image.

## Getting Started

### Prerequisites

- Unity (Version X.X.X)
- Vuforia

### Clone the Repository

```shell
git clone https://github.com/Steeroy/hidear.git

### Open the Unity Project:

1. Launch Unity.
2. Open the cloned project by selecting "Open Project" and navigating to the project folder.

### Import and Set Up Targets:

1. Import the image targets for Manchester United and Manchester City into the Vuforia Target Manager.
2. Download and add the image targets to your Unity project.
3. Set up the Vuforia Image Target GameObjects in your Unity scene.

### Assign Media:

1. Prepare the video related to Manchester United and import it into your Unity project.
2. Assign the video to the appropriate GameObject that responds to the Manchester United image target.
3. Configure the 3D sphere for the Manchester City target if needed.

### Build and Run:

1. Build the project for your target platform.
2. Install and run the application on your mobile device.

### Usage

1. Open the app on your mobile device.
2. Point your device's camera at the image target representing Manchester United.
3. The app should detect the image and play the associated video.
4. Point your device's camera at the image target representing Manchester City.
5. The app should detect the image and display a 3D sphere in front of it.

### Troubleshooting

If you encounter any issues or have questions about using this Unity Vuforia app, please refer to the Vuforia documentation or seek assistance from the Unity community.

### Acknowledgments

- Unity
- Vuforia
```
