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
* SQL Server 2019 on docker
* Entity Framework Core for `Command operations`
* Dapper for `Query operations`


Load & Stress testing and monitoring Latency and Throughput  :
* Bombardier

and for logging and log monitoring:

* Nlog
* [Seq](https://datalust.co/seq)

## Architecture:
![architecture](https://github.com/emrealper/order-event-processing/raw/main/media/Event%20Driven-Ordering%20Microservices%20Reference%20Application.png)

## Description:
This repo contains a sample architecture simulates a order creation journey between `Order Producer API` service and `Order Processing and Querying API` Service. The system consists of the following parts.

* **Order Producer API** - An API which accepts post request to transform `NewOrder` record and send it to Kafka Order `topic`.
* **Order Processing and Querying API** - An API and a Hosted Service (As a background worker) which subscribes the Kafka Order Topic `topic` and writes Order record to SQL Server database. This API also offers Get requests to view the saved Orders.
