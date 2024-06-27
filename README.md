# TransferBatch
Testing the creation of a console application to calculate transfer commissions in accounts.
It receives a CSV file as an input parameter.
File structure:
<Account_ID>,<Transfer_ID>,<Total_Transfer_Amount>

A file will be generated with the result of the transfer commission calculation.
Output file structure:
<Account_ID>,<Total_Commission>


## Create Image in docker
### Run the command below to create the projoet image in docker. This command must be executed within the directory where the application's dockerfile is located.

docker build -t [imagename] .

## Create the container
### Run this command to create the container from the created image. This command must be executed in the same directory where the dockerfile is located.

docker run [imagename]

## Create the container and run the application passing input parameters
### If the application receives an input parameter during execution, it must be informed

docker run docker run [imagename] [svfilepath]


