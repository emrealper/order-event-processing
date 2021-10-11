# Event Driven - Microservices Reference Application

 The primary goal of this sample is to explain following software-architecture concepts and container-technologies like:  
* Microservices  
* CQRS  
* Event Sourcing (Using Kafka)
* Domain Driven Design (DDD)  
* Retry policy Dead Letter Topic (Queue)
* Eventual Consistency  
* Custom Middleware for exception handling
* Docker
* Docker-Compose

Methods and tools to manage persistance and its transactions like:
* SQL Server 2017 on docker (custom image which supports Full Text Search and Indexing)
* Entity Framework Core for `Command operations` and `Data Migrations`
* Dapper for `Query operations`


Load & Stress testing and monitoring Latency and Throughput  :
* Bombardier

Unit Testing  :
* XUnit

and for logging and log monitoring:

* Nlog
* [Seq](https://datalust.co/seq)

## Architecture:
![architecture](https://github.com/emrealper/order-event-processing/raw/main/media/Event%20Driven-Ordering%20Microservices%20Reference%20Application.png)

## Description:
This repo contains a sample architecture simulates a order creation journey between `Order Producer API` service and `Order Processing and Querying API` Service. The system consists of the following parts.

* **Order Producer API** - An API which accepts post request to transform `NewOrder` record and send it to Kafka Order `topic`.
* **Order Processing and Querying API** - An API and a Hosted Service (As a background worker) which subscribes the Kafka Order Topic `topic` and writes Order record to SQL Server database. This API also offers Get requests to view the saved Orders.


## How to set up and run the project
You can run the bellow command by navigating the **/source/OrderProducer/OrderProducer.Api/** directory to build docker images for  `Order Producer API` 
```powershell
docker build -f "Dockerfile" -t orderproducer_rc ..
```

and the below command from the **/source/OrderConsumer/OrderConsumerQueryingService.Api/**  for `Order Processing and Querying API` 

```powershell
docker build -f "Dockerfile" -t orderconsumer_rc ..
```

after building docker images of two microservices you can run the below command by navigating the **/setup/** directory to run both 2 services, SQL Server and service bus enviroments (Kafka and Zookeeper) and logserver (seq)

```powershell
docker-compose up
```

## Load & Stress testing and monitoring Latency/Throughput

To test the application i use `bombardier` which is written in Go programming language to simulate many HTTP(S) request concurently sent from different clients.

You can run the below command by navigating  **/diagnostics/bombardier/** directory to build docker images for  `bombardier` 

```powershell
docker build -t alpine/bombardier .
```

## Let's start load testing using `bombardier` 
![machine-gun](https://i.imgur.com/2u6JJnh.gif)

You can run the below command using powershell or command prompt to make concurent  `HTTP POST ` request to  `Order Producer API`. It simulates 50 http calls per second from 50 different clients during 100 seconds.

### Running and result

```powershell
docker run -ti --rm alpine/bombardier -c 50 -d 100s --rate 50 -m POST "http://host.docker.internal:5000/api/Order" -H "Content-Type: application/json" -f "orderEventData.json"
Bombarding http://host.docker.internal:5000/api/Order for 1m40S using 50 connection(s)Bombarding http://host.docker.internal:5000/api/Order for 1m40s using 50 connection(s)
[=====================================================================================================================================================================================================================================] 1m40sDone!
Statistics        Avg      Stdev        Max
  Reqs/sec        49.41      20.90     380.26
  Latency      166.28ms   262.52ms      2.70s
  HTTP codes:
    1xx - 0, 2xx - 4948, 3xx - 0, 4xx - 0, 5xx - 0
    others - 0
  Throughput:    38.61KB/s
```
Please see the random order content of HTTP `POST` request which extracted from **/orderEventData.json/**

``` JSON
{
  "customerId": 23982398,
  "customerName": "Emre",
  "customerLastName": "Alper",
  "customerEmail": "emrealper@gmail.com",
  "shippingAddress": "AgricolaStrasse 35, München, Germany",
  "billingAddress": "AgricolaStrasse 35, München, Germany",
  "currencyType": 1,
  "totalPrice": 240,
  "paymentMethodType": 1,
  "orderItems": [
    {
      "itemCode": "10293098",
      "brand": "Jack Wolfskin",
      "type": "Parka",
      "size": "XL",
      "colour": "Black",
      "quantity": 1,
      "price": 240,
      "currencyType": 1
    }
  ]
}
```

## Use Case for Get and Full Text Search operations for  Order record (Sql Server)

 Please open the following url for `Order Processing and Querying API`  to access swagger ui locally: http://localhost:5001/swagger/index.html 
 
 ![swagger](https://github.com/emrealper/order-event-processing/blob/main/media/OrderConsumerApiSwagger.png)
 
 This consumer and querying app describes sample Search and Get requests :
1. GetAll
2. GetById
3. FullTextSearch

### 1. GetAll
Sample request: GET /api/Orders

### 2. GetById
Sample request: GET /api/Orders/{id}

### 3. GetById
Sample request: GET /api/Orders/customerSearch/{text}


### 2. GetById
Sample request: GET /api/Orders/{id}


## Log Monitoring

Error logs and also event logs are able to monitor (http://localhost:5341) using centralized structured monitoring (Seq)

## Author
- Name: **Emre Alper**
- Contact: **emrealper@gmail.com**



