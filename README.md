# Example.AzureServiceBus


## 1. Clone

  ```bash
     git clone https://github.com/berkid89/Example.AzureServiceBus.git
  ```
  
**HINT:** Don't forget to fill the code with Your own `ServiceBusConnectionString`, `TopicName` and `SubscriptionName`.
  
## 2. Build & Run the Sender

  ```bash
     cd Example.AzureServiceBus\Sender
     dotnet restore
     dotnet build
     dotnet run
  ```
  
  ## 3. Build & Run the Receiver
  
  ```bash
     cd Example.AzureServiceBus\Receiver
     dotnet restore
     dotnet build
     dotnet run
  ```
