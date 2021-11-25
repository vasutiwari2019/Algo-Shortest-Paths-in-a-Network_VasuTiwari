ITCS-6114/8114: Algorithms and Data Structures
Project 1 — Shortest Paths in a Network

Welcome to my project.
This file contains all information about the project, how to compile and other information needed.

Project Description:-
We are given a current configuration of a graph in a text file. We need to perform below operations.
1. Building the Graph
2. Add an Edge from tail vertex to headvertex.
3. Delete an Edge from tail vertex to headvertex.
4. Mark the given edge as Down.
5. Mark the given edge as Up.
6. Mark the given vertex as Up.
7. Mark the given vertex as Down.
8. Find the shortest path from given vertex to given vertex.
9. Find all the vertices reachable from each other.
10. Print the graph configuration.
11. Exit from the program

Program Structure.

Program.cs

The program begins execution from the Program.cs class.
Here we will be taking input from the user until he presses quit.
Please note we need to first build the graph using the command "graph network.txt" before we can perform any other operation.
Based on the input the program will move to the corresponding function in Operation.cs class. Operation.cs class is the main driver class of the proram and 
contains all the relevant functions.
I have used model classses Vertex for storing vertex information, Edge for edge information and Graph for storing the graph configuration.
Priority Queue is used to store the graph information as a priority queue.

Compiling the program.

The program has been written in C# with .Net Core Framework 3.1.

Reachable Vertices

For doing the above operation I have used DFS algorithm.
I am looping for all the vertices and maintaining a variable Visited to check whether it is not added if it has been already visited.
Complexity of the doing DFS is  O(V*(V+E)) but we are sorting the vertices in alphabetical order which takes O(VlogV).
Overall complexity of the algorithm is  O(VlogV + V*(V+E)).

Shortest Path using Dijikstra's ALgorithm.

For doing above operation, I am building a priority queue which is a list of vertices and a cost variable through which I will increase and decrease priority.
For a given vertex I will put all its edges to the priority queue and will apply minimum heapify on the list. The above operation takes O(LogV + E + V)
since I have to search the list of vertices to find the given source vertex and then put all its edges to the priority queue and then perform min heapify which will 
take O(logV) time. After this I will pick the min element from the queue using O(1) time and then find the corresponding vertex in list in O(V) time and put all its edges
in the list and with adding the cost to the edge values. Again I will perform heapify.
I will perform the above operation untill the source vertex is found or the queue is empty(for case if there is no path).
The overall complexity of the program will be O(|V+E|logV) on average. I am ignoring all other O(V+E) since O(|V+E|logV) will be greater.

Datastructures Used

1. List - for storing the list of vertices
2. Integers - for looping
3. Strings - for taking user input as a string
4. Custom model classes - graph class, vertex class, edge class.
5. floats - for storing the cost variable.


