# BookStore
Console application to display SOLID principles design

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
  
So the Repository can handle text data read or written to a file in the form of one string or a list of strings 
representing lines in a file.

The BookStore project includes handler classes for Json and csv data. 
Therefore, the goal of this solution is to de-couple data access from console layer and design using SOLID principles approach.

Dependency injection is used to inject the context, in this case is a FileInfo object, to the Repository class.

