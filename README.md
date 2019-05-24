# BookStore
Console application that decouples data storage from data displayed. 

The BookStore console application includes three projects:
  * BookStore (Console)
  * BookStore.DataAccess
  * BookStore.Tests

The data access layer (BookStore.DataAccess) includes a Reposiotry class that acts as a wrapper for a target text file.
The Repository class operations include:
  * RetrieveDataAsText()
  * RetrieveDataAsList()
    - returns IEnumerable string
  * StoreData(string fileText)
  * StoreData(IEnumerable lines)
  
So the Repository can handle text data operations to or from a file in the form of one string or a list of strings 
representing lines in a file.

The BookStore project includes handler classes for Json and csv data. 
Therefore, the goal of this solution is to decouple data access from console layer and design using SOLID principles approach.

Dependency injection is used to inject the file context, in this case is a FileInfo object, to the Repository class.
