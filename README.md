# Simple project about RabbitMQ

## Build project

-First step, you need to upload a docker image: 
docker run -d -p 15672:15672 -p 5672:5672 --name rabbit-startup rabbitmq:3-management

This is the runner i used, if you want to know more, follow a great tutorial: 
https://medium.com/dev-genius/rabbitmq-with-docker-on-windows-in-30-minutes-172e88bb0808

-Next step, you just need to run the application.

## Version
SDK .net core: 3.1

## Packages
RabbitMQ.Client: v6.0.0
