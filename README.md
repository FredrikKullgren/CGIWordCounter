# CGIWordCounter
What it is:
This is a web api built using Asp.Net Core (.NET 5) Web API. It exposes a single endpoint(/wordcount) that excpects a block of text as post request. The program 
counts the number of ocurrences of each word(making no difference if letters capitilazed or not i.e Apple is the same as apple). The result is returned as a list
containing the top 10 most used words and their number of ocurrences.


How to run it:
Clone this repository and just type dotnet run to build and run the project. This will start a local server(Kestrel embedded server) on port 5000(http)
and 5001(https). If you run into certificate problems when using curl to make the post request use ISS Express instead. Start the ISS Server by pressing 
the run button in visual studio after choosing ISS Express as server. The default port here is (44367)


How to use it:
Words can be separated by newline or whitespace, at least one is enough but the program will handle multiple in a row also. This is convenient if you just want to copy and paste a block of text into for example postman.
The Content-Type is free of choice. This means that both these different Content-Type will work (using curl command in this case):

curl -H "Content-Type: text/plain" -d "banana apple pear pear" https://localhost:44367/wordcount
[{"word":"pear","count":2},{"word":"banana","count":1},{"word":"apple","count":1}]

curl -H "Content-Type: application/json" -d "banana apple pear pear" https://localhost:44367/wordcount
[{"word":"pear","count":2},{"word":"banana","count":1},{"word":"apple","count":1}]



