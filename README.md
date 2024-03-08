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

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/af73d25d-3112-4da5-b51a-971e4d9a8b6b"  height="200">

- **Builder**: Players in the game can create preserved items using jars. These jars are stored in the database and possess attributes for the crops inside at any given moment. To achieve this, I have utilized the jars as ConcreteBuilder classes, rather than a constructor of the preserved items class. 
I've ensured that players can flexibly create preserved items, which align well with the pattern. Furthermore, this implementation is closed for modification yet open for extension, allowing the addition of more ConcreteBuilders for different types of preserved foods, enabling the creation of new varieties of preserved food in the game in the future.

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/09e67bb7-6313-4fab-a59a-67ff8847a6b8"  height="150">


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

![image](https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/3f73f9bd-0111-4f27-922e-3c73f70a7976)

### Data Access Layer
The following diagram displays static classes dedicated to conducting CRUD operations. Each class corresponds to a collection in the database. The CRUD methods are named meaningfully to facilitate easy access and interaction with the Business Logic Layer.

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/5822821f-db31-4a6e-acba-8b539f2aa6be"  height="300">



The following diagram showcases classes representing structured data objects in the Data Access Layer. These classes define the structure and properties of the data stored in the database, ensuring compatibility and efficiency in data manipulation tasks.

![image](https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/72292924-7c0d-44ff-84ad-9d27fb6e28c3)


### Business Logic Layer
To ensure a well-organized structure, I've divided the Business Logic Layer into distinct modules, each module containing related components. See below for class diagrams illustrating selected modules:
- Plant module:

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/eedce7f4-b2d5-48f9-9f4e-5c86866ba4c4"  height="250">


- User module:

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/fd27fbcd-e0cd-4395-bb30-bef81a993cef"  height="300">


- Item module:

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/fe2b38f5-340d-4dfd-be82-d1b268f73359"  height="200">

- Preserve module:

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/ff013c4f-2e13-4af9-bbc2-ed222ce0ec52"  height="300">


- Game state module:

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/c0bf394c-5062-47f9-a99d-53efdf9c9114"  height="450">



- Leaderboard module:
  The following class diagram presented here illustrates the connection between the Presentation Layer and Business Logic Layer for the leaderboard feature.

  <img src="https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/cad8b7b9-6262-49d8-8d4d-7b98009dee28"  height="300">


Additional diagrams can be accessed via the following links: [Npc module](https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/524de56d-511c-4aa4-b59e-30ec13d2c559), [Level module](https://github.com/cayscays/Flower-Box-Bounty/assets/116169018/cc36c21e-2eda-469e-bc99-0fc07d0b6628).

---

Thank you for reviewing Flower Box Bounty!

Created by [cayscays](https://github.com/cayscays/).
