# Flower Box Bounty

## Description
Flower Box Bounty is a game that allows players to groom a flower box, nurturing plants that will eventually transform into fresh vegetables and fruits. The game follows the 3-tier architecture with a strong focus on maintainability. I utilized design patterns to ensure efficient handling of future changes.

## Table of Contents
- [Key Features](#key-features)
- [Technologies Used](#technologies-used)
- [Design and Architecture](#design-and-architecture)
- [Roadmap](#roadmap)
- [Class Diagrams](#class-diagrams)


## Key Features
- Grow various plants into fresh produce in a flower box.
- Craft homemade jams and pickles using harvested crops.
- Store and share produce, seeds, and canned goods with other players, fostering a sense of community.

## Technologies Used
- Developed using .NET 7.0 and C#.
- Integrated MongoDB and MongoDB.Driver for remote data storage and retrieval.
- Utilized Windows Presentation Foundation (WPF) for creating an interactive user interface.

## Design and Architecture
In this project, I have implemented the 3-tier architecture. The architecture's main components are as follows:

- **Presentation Layer**: The graphic user interface.

- **Business Logic Layer**: The core business logic and application functionality.

- **Data Access Layer**: Controls the interactions with the MongoDB database, utilizing the MongoDB.Driver library to perform CRUD operations and data management.

In addition to the architectural design, I implemented the following design patterns:

- **Singleton**: The CurrentUser class is implemented as a Singleton to ensure only a single instance exists. The locking mechanism is utilized to synchronize access to the creation of the CurrentUser instance, preventing multiple threads from creating multiple instances.

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/f63d95fb-f075-40df-a340-c6062bc9646b"  height="200">

- **Builder**: Players in the game can create preserved items using jars. These jars are stored in the database and possess attributes for the crops inside at any given moment. To achieve this, I have utilized the jars as ConcreteBuilder classes, rather than a constructor of the preserved items class. 
I've ensured that players can flexibly create preserved items, which align well with the pattern. Furthermore, this implementation is closed for modification yet open for extension, allowing the addition of more ConcreteBuilders for different types of preserved foods, enabling the creation of new varieties of preserved food in the game in the future.

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/60cac21e-b8a3-4d06-b066-d523b26318a8"  height="150">



## Roadmap
1. **Preserved Food Expansion:** Utilize the flexibility of the already implemented Builder pattern to add a recipe feature for jams and pickles by creating additional ConcreteBuilders inheriting from PreserveBuilder. Additionally, explore opportunities to introduce new types of preserved foods using the same approach.
2. **Graphics Enhancement:** Introduce updates to transition the current WPF-style graphics into a more immersive visual experience, with minimal modification of the code due to the architectural benefits of the 3-tier structure.
3. **NPCs Addition:** Add more NPCs (non-player characters) by leveraging the existing support for multiple NPCs.
4. **Plant Additions:** Enhance the plant system with additional growth and weathering stages. Utilize the SRP (Single Responsibility Principle) design of the classes in the plant module.

This roadmap outlines planned enhancements and features that leverage the project's architecture and design principles.


## Class Diagrams
This section contains visual representations of the project's architecture and design.
Below are the class diagrams for each layer:

### Presentation Layer
The following diagram offers an overview of the Presentation Layer, depicting the structure and relationships between View classes, ViewModel classes, and a few relevant classes from the Logic Layer.

Click the image to enlarge:


![image](https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/c0c63a7e-69c5-4640-9a83-8bbd7eb18809)



### Data Access Layer
The following diagram displays static classes dedicated to conducting CRUD operations. Each class corresponds to a collection in the database. The CRUD methods are named meaningfully to facilitate easy access and interaction with the Business Logic Layer.

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/6f428c1d-eae7-4be1-9ab5-cc95c857fe6d"  height="300">


The following diagram showcases classes representing structured data objects in the Data Access Layer. These classes define the structure and properties of the data stored in the database, ensuring compatibility and efficiency in data manipulation tasks.

![image](https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/60cdda74-5d31-4bff-8043-f0164dfb7e3e)


### Business Logic Layer
To ensure a well-organized structure, I've divided the Business Logic Layer into distinct modules, each module containing related components. See below for class diagrams illustrating selected modules:
- Plant module:

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/fc441dc5-9528-45bb-a424-c3e38dfc104b"  height="250">


- User module:

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/a78d815d-3936-4f57-8e04-531ea7fbb1b9"  height="300">


- Item module:

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/24c147fc-e6e1-4bfd-86c0-62092c058841"  height="200">


- Preserve module:

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/1aabdb8a-718d-4251-9cbe-7d6f77dabfa3"  height="300">


- Game state module:

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/11d9e4e7-58ec-4d8f-b214-f59133c649cb"  height="450">


- Leaderboard module:
  The following class diagram presented here illustrates the connection between the Presentation Layer and Business Logic Layer for the leaderboard feature.

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/beb467f3-90d9-438d-a721-472f84ea412a"  height="300">

Additional diagrams can be accessed via the following links: [Npc module](https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/01331d9b-fee8-4dca-9526-13387e51eefa), [Level module](https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/2d25dc82-40bd-4a92-aa31-fbe4ced55348).


---

Thank you for reviewing Flower Box Bounty!
