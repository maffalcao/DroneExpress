# DroneExpress

DroneExpress: A next-gen drone delivery system for efficient package transportation. Optimize routes, minimize trips, and reduce costs. Revolutionizing logistics with autonomous drones.

![DroneExpress](https://tropogo.com/blogs/images/blog/img_india-drone-delivery-progress-banner.png)

# Resolution

## Input Processing:

The input is read from the command line, with the input file path and output file path provided as arguments.
The input file contains information about drones and locations.
The drone data is extracted from the first line of the input file, where each drone's name and maximum weight are listed.
The location data is extracted from the subsequent lines, where each location's name and package weight are listed.
Drones and locations are instantiated based on the extracted data and stored in separate lists.

## Problem Solving:

The locations are sorted in descending order based on package weight.
For each drone, a trip list and remaining weight are initialized.
Iterating through the sorted locations, if a location's package weight is within the drone's remaining weight capacity, it is added to the current trip, and the remaining weight is updated accordingly.
When the remaining weight reaches zero, the current trip is added to the drone's trip list, and a new trip and remaining weight are initialized.
If there are any remaining locations after iterating through all the locations, they are added as a separate trip.
This process ensures that each drone carries as many packages as possible within its weight capacity.

## Output Printing:

The results of the drone deliveries are printed.
The Print() method iterates through each drone and its corresponding trips.
The drone's name is printed, followed by each trip's number and the list of location names in that trip.
The StringBuilder class is used to efficiently build the output string.
Output Writing:

The generated output string is written to the output file specified.
By following this strategy, the code efficiently assigns packages to drones based on their weight capacity and prints the drone deliveries in the desired format. The approach aims to optimize the utilization of drones while considering the weight restrictions imposed by each drone.
