# SSEExample - .NET with React Template Application

SSEExample is a .NET with React template application that demonstrates how to implement Server-Sent Events (SSE) for real-time updates in a web application.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Visual Studio Code](https://code.visualstudio.com/) or your preferred code editor.

## Getting Started

To get started with SSEExample, follow these steps:

1. Clone this repository:

   git clone https://github.com/yunuskiran/SSEExample.git
   cd SSEExample

2. Build and run the .NET backend:

   dotnet build
   dotnet run

3. Open your web browser and visit `http://localhost:{port}` to access the SSEExample application.

## Server-Sent Events (SSE)

SSEExample demonstrates how to implement Server-Sent Events for real-time updates. SSE is a simple and efficient way to send real-time updates from the server to the client over a single HTTP connection. The SSE endpoint can be found in the `Controllers/WeatherForecastController.cs`  file `EventStream` method.
