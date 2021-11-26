ITCS-6114/8114: Algorithms and Data Structures
Project 1 — Shortest Paths in a Network

Submitted By: Vasu Tiwari
Student ID: 801254277

Project Description:
We are given a current configuration of a graph in a text file. We need to perform the below operations.
1. Building the Graph
2. Add an Edge from tail vertex to head vertex.
3. Delete an Edge from tail vertex to head vertex.
4. Mark the given edge as Down.
5. Mark the given edge as Up.
6. Mark the given vertex as Up.
7. Mark the given vertex as Down.
8. Find the shortest path from a given vertex to a given vertex.
9. Find all the vertices reachable from each other.
10. Print the graph configuration.
11. Exit from the program

Program Structure:

Program.cs

The program begins execution from the Program.cs class.
Here we will be taking input from the user until the "quit" query is executed.
Please note we need to first build the graph using the command "graph <file_name>.txt" before we can perform any other operation.
Based on the input the program will move to the corresponding function in the Operation.cs class. Operation.cs class is the main driver class of the program and 
contains all the relevant functions.
I have used model classes Vertex for storing vertex information, Edge for edge information, and Graph for storing the graph configuration.


Compiling the program:

The program has been written in C# with .Net Core Framework 3.1.
For installing .Net Core framework use below link.
https://dotnet.microsoft.com/download

For running the program in Windows:
Go to the path where the folder is
type "dotnet build ShortestPath.csproj"
After building the project, go to the given folder inside the directory \bin\Debug\netcoreapp3.1
run the executable file by double-clicking or through cmd.
ShortestPath
You will see the below message.
Welcome to My Shortest Path Project, please run the command as in the read me file.
You can paste the whole set of instructions or paste the instructions one by one.
Please make sure that you build the graph first using command "graph <file_name>.txt"


For running the program in Linux.:
The same process for building the program, the only difference is, a dll file will be created in Linux.
Run the dll file and follow the same instructions.
for running dll file: dotnet ShortestPath.dll


Reachable Vertices:
For doing the above operation I have used the DFS algorithm.
I am looping for all the vertices and maintaining a variable Visited to check whether it is not added if it has been already visited.
The complexity of doing DFS is  O(V*(V+E)) but we are sorting the vertices in alphabetical order which takes O(VlogV).
The overall complexity of the algorithm is  O(VlogV + V*(V+E)).

Note: In the implementaion of this logic, the source nodes are storted in alphabetical order, but the set of reachable nodes from each source are not sorted in alphabetical order.

Shortest Path using Dijkstra's ALgorithm:
For doing the above operation, I am building a priority queue which is a list of vertices with a cost variable(priority variable) through which I will increase and decrease priority.
For a given vertex I will put all its edges to the priority queue and will apply minimum heapify on the list. The above operation takes O(LogV + E + V)
since I have to search the list of vertices to find the given source vertex and then put all its edges to the priority queue and then perform min heapify which will take O(logV) time. After this, I will pick the min element from the queue using O(1) time and then find the corresponding vertex in the list in O(V) time and put all its edges
in the list, and with adding the cost to the edge values. Again I will perform heapify.
I will perform the above operation until the source vertex is found or the queue is empty(in case if there is no path).
The overall complexity of the program will be O(|V+E|logV) on average. I am ignoring all other O(V+E) since O(|V+E|logV) will be greater.

Data structures Used

1. List - for storing the list of vertices
2. Integers - for looping
3. Strings - for taking user input as a string
4. floats - for storing the cost variable.

Sample Instructions for running.

1. Building the Graph
graph network.txt

2. Add an Edge from tail vertex to head vertex.
addedge Education Atkins 0.25

3. Delete an Edge from tail vertex to head vertex.
deleteedge Duke Education

4. Mark the given edge as Down.
edgedown Health Education

5. Mark the given edge as Up.
edgeup Health Education

6. Mark the given vertex as Up.
vertexup Belk

7. Mark the given vertex as Down.
vertexdown Belk

8. Find the shortest path from a given vertex to a given vertex.
path Belk Education

9. Find all the vertices reachable from each other.
reachable

10. Print the graph configuration.
reachable

11. Exit from the program
quit