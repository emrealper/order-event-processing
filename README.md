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
