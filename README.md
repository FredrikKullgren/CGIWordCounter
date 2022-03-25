# CGIWordCounter
What it is:
This is a web api built using Asp.Net Core (.NET 5) Web API. It exposes a single endpoint(/wordcount) that excpects a block of text as post request. The program 
counts the number of ocurrences of each word(making no distinction between capitilazed letters or not, (i.e Apple is the same as apple). The result is returned as a dictionary containing the top 10 most used words and their number of ocurrences. The program is only intended to be used locally and not in production scenarios.


How to run it:
Clone this repository and just type dotnet run to build and run the project. This will start a local server(Kestrel embedded server) on port 5000(http)
and 5001(https). If you run into certificate problems when using curl to make the post request use ISS Express instead. Start the ISS Server by pressing 
the run button in visual studio after choosing ISS Express as server. The default port here is (44367)


How to use it:
Words can be separated by newline or whitespace, at least one is enough but the program will handle multiple in a row also. This is convenient if you just want to copy and paste a block of text into for example postman.

Example using curl command:
  curl -X POST -d "banana apple Apple appLe pear pear" https://localhost:44367/wordcount
  {"apple":3,"pear":2,"banana":1}

Notes:
To be able to just paste a string with no surrounding brackets the controllet needs to accept plain text. This is solved in the current solution in such a way
that any Content-Type in the header of the POST request is accepted.
The current solution therfore accepts whatever value you use and can even be omitted as shown in following examples. This is not ideal and needs to be fixed in the future.  




