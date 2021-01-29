# Unity-ARFoundation-echoAR-demo-Pin-Location

Map pin location demo with Unity, ARFoundation, and echoAR.

## Register
If you don't have an echoAR API key yet, make sure to register for FREE at [echoAR](https://console.echoar.xyz/#/auth/register).

## Setup
### Basics
* Clone [Unity-ARFoundation-echoAR-example](https://github.com/echoARxyz/Unity-ARFoundation-echoAR-example) repo and follow the instructions on [documentation page](https://docs.echoar.xyz/unity/adding-ar-capabilities) to get your project up and running.

### PinLocation Package
* Clone this repo
* In your existing project of ```Unity-ARFoundation-echoAR```, from the toolbar on top select ```Assets > Import Package > Custom Package...```
* Select ```echoAR-PinLocation.unitypackage``` located in this repo and click ```Open```
* Click ```All``` and then ```Import```
* From the ```Project``` tab in Unity, go to ```Assets > AR Foundation > Scenes > PinLocation```
* Open the scene ```PinLocationAR```
* Edit ```ShareButtonHandler.cs``` file in the same directory
* Find the ```ShareLocation()``` function and place your API key and optional configurations
* From the project tab, go to ```Assets > AR Foundation > Scripts```
* Overwrite ```PlaceOnPlane.cs``` with the corresponding file in this repo

## echoAR Console
* In the ```Content``` page under Manage, select the option to upload new files
* Upload **both** files in the directory ```MapPinConsoleObject``` located in this repo

## Note
* This project utilizes [```Native Share for Android & iOS```](https://assetstore.unity.com/packages/tools/integration/native-share-for-android-ios-112731) from the Unity Asset Store
* In your Unity project, go to ```Asset Store``` and download the asset above in its entirety

## Run
* Save, build and run the project just as you would for [Unity-ARFoundation-echoAR](https://docs.echoar.xyz/unity/adding-ar-capabilities)

Note: These instructions assume that you are familiar with building and running the project for your desired platform (iOS, Android...) Please consult external resources if you are having difficulties in this process.

* In Build Settings, after selecting iOS, ensure that you have selected the correct scene that is ```AR Foundation/Scenes/PinLocation/PinLocationAR```. If this option is not available, click ```Add Open Scenes``` and try again by looking at the end of the list.

## Usage
When share button at the bottom-center of the screen is touched, user location is determined with [LocationService](https://docs.unity3d.com/ScriptReference/LocationService.html) in Unity. The location is sent within an HTTP POST request to echoAR’s API.
* In the [echoAR console](https://console.echoar.xyz/#/pages/data), go to ```Data``` tab under Manage
* The ```location``` should be seen in the ```Global database``` table on this page

## Screenshots
### Pin
![Pin](Screenshots/Pin.png)

### Share
![Share](Screenshots/Share.png)

## Attributions
* "Map Pin" (https://skfb.ly/6SVFx) by Ilyas.King is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

## Support
Feel free to reach out at [support@echoAR.xyz](mail:support@echoAR.xyz) or join our [support channel on Slack](https://join.slack.com/t/echoar/shared_invite/enQtNTg4NjI5NjM3OTc1LWU1M2M2MTNlNTM3NGY1YTUxYmY3ZDNjNTc3YjA5M2QyNGZiOTgzMjVmZWZmZmFjNGJjYTcxZjhhNzk3YjNhNjE)