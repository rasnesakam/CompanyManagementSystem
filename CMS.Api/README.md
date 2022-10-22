# API Layer
API is stands for Application Programming Interface.  
If we seperate the fetching data from server and 
providing user interface jobs, we are getting two different 
concepts.  

One of it is front-end. And it is not our topic for now.
And the other one is back end. And it is not our topic too.  

Our topic is the comminucation system of these two concepts.  
This system needs to be too dynamic and too standard,
so the multiple front end application can benefit 
from one back end service. And vice versa.

This layer provides only the data. The raw data in JSON format 
or in any other format such as XML, YAML etc.  

All of the front end applications make requests of it's endpoints
for recieve the datas that they need. Then, API layer is fetches
the datas and provides it to the front end applications that they
requested.