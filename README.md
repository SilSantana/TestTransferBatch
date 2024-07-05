# TransferBatch
Testing the creation of a console application to calculate transfer commissions in accounts.
It receives a CSV file as an input parameter.
File structure:
<Account_ID>,<Transfer_ID>,<Total_Transfer_Amount>

A file will be generated with the result of the transfer commission calculation.
Output file structure:
<Account_ID>,<Total_Commission>


## Execute by Prompt command
-> Run the command bellow to execute the console application. This command must be executed within the directory where the executable file is.

TransferBatch.exe [svfilepath]


## Create Image in docker
-> Run the command below to create the projoet image in docker. This command must be executed within the directory where the application's dockerfile is located.

docker build -t [imagename] .

## Create the container
-> Run this command to create the container from the image. This command must be executed in the same directory where the dockerfile is located.

docker run --name [container_name]  [svfilepath]

## Create the container and run the application passing input parameters
-> If the application receives an input parameter during execution, it must be informed

docker run --name [container_name] [imagename] [svfilepath]

## Application framework
.Net version: 8.0

C# version: 12.0

## IDE Tool
Visual studio version: 2022


## CsvHelpér package
-> Library used to facilitate the reading and writing of large files, being fast, flexible with settings that are easy to apply and use as needed. 
Low memory consumption, reading records will yield results so only one record is in memory at a time.
It has good usage references, supporting documentation and the project continues to evolve with a large number of contributors.


## StreamWriter
-> It is a .NET class that allows you to easily write files using objects with simple serialization. 
Allows writing to occur asynchronously, keeping the application responsive.
Allows writing via configurable memory buffers, and improves writing efficiency by reducing the number of I/O operations.


