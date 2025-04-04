# UnityUtils

UnityUtils is a growing collection of extension methods, helpers, attributes, and other utilities designed to enhance and simplifyUnity development workflow.

## Features

### AudioSystem
This audio system consists of multiple components that work together to manage and play both music and sound effects in your game.

- **AudioSpawner**: Initializes the audio system by spawning the `SoundManager` and `MusicManager` at the start of the game.
- **MusicManager**: Manages background music, including track fading, playlist handling, and volume control.
- **SoundManager**: Handles sound effects with an object pool for optimal performance, supporting multiple sound instances and volume control.
- **SoundEmitter**: Represents individual sound instances, allowing configuration of various audio properties such as volume, pitch, and spatial blend.

### DetectorsTools
These scripts provide simple detection mechanisms for both 2D and 3D Unity objects based on layers or tags. They allow you to easily manage and respond to collision and trigger events. Each detector allows you to assign **UnityEvents** to respond to these collisions and trigger events.

### EventChannels
A flexible system to manage events through channels, allowing you to easily raise and listen to events of different types. The system uses ScriptableObject instances to decouple event logic from other game components, making it easier to maintain and extend.

### QuestSystem
A comprehensive system to manage and track quests and objectives in the game. The system allows quests to have multiple objectives, and when all objectives are completed, the quest is marked as completed. This system includes functionality to display quests and objectives in the UI and to manage the flow of quest progression.

### ServiceLocator
A simple implementation of the **Service Locator** pattern for managing game services in Unity. It provides a centralized way to access services from anywhere in the code.

- Stores and retrieves instances of services implementing `IGameService`.
- Ensures global access to registered services without direct dependencies.

### StateMachine
A simple state machine implementation for Unity that manages transitions between various game states.

### Timers
An extensible Timer solution for Unity Game Development. Timers are self-managing by injecting a Timer Manager class into Unity's Update loop.

The included Timers are:
- **CountdownTimer**: Counts down from a specified time to zero.
- **FrequencyTimer**: Ticks N times per second.
- **StopwatchTimer**: Counts up from zero to infinity.

### Extension Methods
Extend Unity's built-in types and C# with additional functionality. For example, methods for simplifying math operations, object manipulation, etc.

### Singleton
A generic **MonoBehaviour Singleton**. It simplifies the creation of unique instances that can be accessed globally without needing to manually handle object creation.

### RuntimeScriptableObject
An abstract base class for **ScriptableObject** instances that need to be reset at the start of the game.

- Keeps track of all active instances.
- Automatically resets all instances before the scene loads.
- Provides an `OnReset` method that derived classes must implement for custom reset behavior.

### TagSelectorAttribute
A custom property attribute that allows you to select tags from a dropdown list in the Unity Inspector, instead of manually typing them as strings.
