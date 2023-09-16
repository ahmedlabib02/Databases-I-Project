# Sports Match Management System - Web Application

This project is the implementation of a web application for the Sports Match Management System, as part of the Databases I course at the German University in Cairo, Winter 2022.

## Table of Contents
- [Overview](#overview)
- [Functionalities](#requirements)
- [Getting Started](#getting-started)
- [User Types and Actions](#user-types-and-actions)
- [Database Integration](#database-integration)
- [Contributing](#contributing)
- [License](#license)

## Overview

In this milestone, we have implemented a web application interface that connects to the previously developed database. The web application allows users of different types (System Admin, Sports Association Manager, Club Representative, Stadium Manager, and Fan) to perform specific actions related to the Sports Match Management System.

## Requirements

The project requirements are outlined as follows:

### System Admin

1. Add a new club using its name and location.
2. Delete a club using its name.
3. Add a new stadium using its name, location, and capacity.
4. Delete a stadium using its name.
5. Block a fan using their national ID number.

### Sports Association Manager

1. Register with a name, username, and a password.
2. Add a new match with a host club name, guest club name, start time, and end time.
3. Delete a match with a host club name, guest club name, start time, and end time.
4. View all upcoming matches (in the form of host club name, guest club name, start time, and end time).
5. View already played matches (in the form of host club name, guest club name, start time, and end time).
6. View pair of club names who never scheduled to play with each other.

### Club Representative

1. Register with a name, username, a password, and a name of an already existing club.
2. View all related information of the club they are representing.
3. View all upcoming matches for the club they are representing (in the form of host club name, guest club name, start time, and end time) with the stadium name that hosts the match (if available).
4. View all available stadiums starting at a certain date (in the form of stadium name, location, and capacity).
5. Send a request to a stadium manager requesting to host an upcoming match their club is hosting.

### Stadium Manager

1. Register with a name, username, a password, and a name of an already existing stadium.
2. View all related information of the stadium they are managing.
3. View all requests they have already received (in the form of name of the sending club representative, name of the host club of the requested match, name of the guest club of the requested match, start time of the match, end time of the match, and the status of the request).
4. Accept an already sent unhandled request.
5. Reject an already sent unhandled request.

### Fan

1. Register with a name, username, a password, national id number, phone number, birth date, and an address.
2. View all matches that have available tickets starting at a given time (in the form of host club name, guest club name, name of the stadium hosting the match, and the location of that stadium).
3. Purchase a ticket for a match.

For detailed actions and interfaces, please refer to the specific requirements provided in your project description.

## Getting Started

To run the web application locally, follow these steps:

1. Clone the repository:
   ```bash
   git clone https://github.com/ahmedlabib02/Databases-I-Project.git
   Set up your development environment, ensuring you have the necessary tools and libraries for web development.

2.Configure the web application to connect to your database. Update the database connection settings in the application as needed.

3..Install any dependencies using package manager of your choice (e.g., npm or yarn).

4.Build and run the web application locally.

## Database Integration
The web application seamlessly integrates with the database developed in previous milestones. Ensure your database is properly set up and configured to support the web application's functionalities.

## Authors

We'd like to thank the following authors for their valuable contributions to this project:
- [Omar Ashraf](https://github.com/OmarAshraf-02)
- [Mostafa elKout](https://github.com/Elkott1)



