# LovenseBreedLab

## Table of Contents

* [Description](#description)
* [Contributing](#contributing)
* [Building](#building)
* [Installation](#installation)
* [Usage](#usage)
* [Supported Lovense Toys](#supported-lovense-toys)
* [Supported Enemies](#supported-enemies)
* [Disclaimer](#disclaimer)
* [Limitations](#limitations)

## Description

Mod for the game Breed Laboratory by Moey Moey that connects Lovense toys with the game. It starts/stops toys with sex scenes and adjusts toy speed/intensity according to the rhythm of the sex scene. See [Supported Lovense Toys](#supported-lovense-toys) and

## Contributing

Testing requires having the hardware, sex toys, and I do not own more than 1 at the moment. If you want to test it for other Lovense toys contact me on Discord @redpartyhatboii or on the official game Discord.

## Building

### Requirements

* Installation of Visual Studio with sub-component C# Lib

### Building

* Clone repo
* Open project
* Import references from your game installation: Assembly-CSharp.dll, UnityEngine.dll, UnityEngine.CoreModule.dll, 0Harmony.dll, Bepinex.dll
* Build

## Installation

### Requirements

* Any working Bluetooth dongle or native Bluetooth
* Functional installation of BepInEx v5.X https://github.com/bepinex/bepinex
* Having a copy of Lovense Bluetooth library https://developer.lovense.com/LovenseBLE\_Lib.dll

### Steps

* Build from sources or download the latest version from the release page
* Copy the mod dll and Lovense Bluetooth lib dll into game/bepinex/plugins

### Testing installation

* When the game opens in the main menu screen, the toy will be indicating a remote connection

## Usage

* Connect and turn on the toy before starting the game
* Set speed of toy to 0 so it does not move/vibrate
* Toy should now blink to indicate it is waiting for a new Bluetooth connection
* Open the game
* Toy should now stop blinking to indicate it is now connected
* Toy will now start and stop on sex scenes with this list of enemies: [Supported Enemies](#supported-enemies)
* Pausing the game will not stop the sex toy
* Quitting to the main menu or closing the game will not stop the sex toy

## Supported Lovense Toys

* Lovense Sex Machine

## Supported Enemies

* Episode 1 Hugger
* Episode 1 Flying Insect
* Episode 1 Licker
* Episode 2 Snake
* Episode 2 Futanari
* Episode 3 Mantis
* Episode 4 Hugger
* Episode 4 Feral Wolf
* Episode 4 Wasp
* Episode 4 Plant Walker
* Episode 4 Mind Flayer
* Gallery Episode 1 Wolf
* Gallery Episode 1 Hugger
* Gallery Episode 1 Flying Insect
* Gallery Episode 1 Licker
* Gallery Episode 2 Snake
* Gallery Episode 2 Futanari
* Gallery Episode 3 Mantis
* Gallery Episode 4 Hugger
* Gallery Episode 4 Feral Wolf
* Gallery Episode 4 Wasp

## Limitations

This is a list of limitations that the mod cannot and will not try to implement due to Lovense sex toys hardware or software design.

* Lovense sex machine and mini sex machine:

  * Will not follow depth of penetration according to the sex scene
  * Will not be exact in terms of penetration speed according to the sex scene when it is slower than \~600ms

## Disclaimer

This software controls physical systems that interact with people and the surrounding environment. Improper installation, configuration, operation, or maintenance of physical systems may result in property damage or injury.

This software is provided as-is and may contain bugs, incomplete features, or unexpected behavior. It is the user's responsibility to evaluate whether the software is suitable and safe for their specific application and to implement appropriate safety measures, safeguards, and supervision.

By using this software, you acknowledge and accept all associated risks. The author shall not be held liable for any injury or damages resulting from the use, misuse, modification, or reliance on this software.

