# Fundhouse FX API

The Fundhouse FX API provides a small number of REST endpoints to allow for quick and easy currency conversions, as well as the retrieval of historical exchange rate information.

However, the API is not yet complete & we hope to employ your super duper dev skills to help us get it up and running! 🚀

## Getting started

### Dependencies

To get up and running, please ensure that you have the following tools installed in your development environment:

- Docker ([Windows](https://www.docker.com/products/docker-desktop) | [MacOS](https://hub.docker.com/editions/community/docker-ce-desktop-mac?utm_source=docker&utm_medium=webreferral&utm_campaign=dd-smartbutton&utm_location=header) | [Linux](https://hub.docker.com/search?offering=community&operating_system=linux&q=&type=edition))
- .NET Core SDK v5.0.13 ([All platforms](https://dotnet.microsoft.com/en-us/download/dotnet/5.0))

### Running the solution

Now that we have everything set up, we should be ready to go! You'll need to decide whether you'd like to run the solution using Docker or on your local machine using the the dotnet CLI.

**Run in a Docker container:**

```sh
# Build the Docker image
docker build -t fh-fx-api-net:latest -f .docker/Dockerfile .

# Start a new container instance
docker run -d --rm -p 8080:80 fh-fx-api-net:latest
```

**Run using the Kestrel:**

```sh
dotnet restore
dotnet build
dotnet run
```

Open your web-browser and navigate to [https://localhost:8080/currencies](https://localhost:8080/currencies) to verify that the API is running.

### Project structure

```
fx-api-net/
├─ .docker/
├─ Controllers/
│  ├─ ResponseTypes/
│  │  ├─ Currency.cs
│  │  ├─ Quote.cs
│  │  ├─ SpotRate.cs
│  ├─ CurrenciesController.cs
│  ├─ QuotesController.cs
│  ├─ RatesController.cs
├─ Data/
│  ├─ Configuration/
│  │  ├─ CurrencyConfiguration.cs
│  │  ├─ SpotRateConfiguration.cs
│  ├─ Model/
│  │  ├─ Currency.cs
│  │  ├─ SpotRate.cs
│  ├─ FxDataContext.cs
├─ Serialization/
│  ├─ SnakeCaseNamingPolicy.cs
├─ Resources/
│  ├─ fundhouse_fx.db
│  ├─ openapi.yaml
├─ appSettings.json
├─ Program.cs
├─ README.md
├─ Startup.cs
```

[Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) is used to access the [SQLite](https://sqlite.org/index.html) database contained in the _/Resources_ folder.
The database has been pre-populated with exchange rates going back a few years.

> **NOTE**: The design of the application is quite barebones, and if you wish to reactor it because you feel it can be improved, you are encouraged to do so, but it's by no means expected.

## API schema

The API is relatively well documented using an [OpenAPI](https://swagger.io/specification/) schema file located in the _/resources_ folder. It can be quite difficult to read the schema in raw YAML format, but you can easily copy and paste the contents of the schema file into the online editor at [swagger.io](https://editor.swagger.io/) to get a good overview.

The API exposes 3 endpoints, each of which has a distinct responsibility.

### [GET] /currencies

This endpoint simply returns a list of supported currencies. At present, the API supports:

- South African Rand (ZAR)
- US Dollar (USD)
- Euro (EUR)
- British Pound (GBP)
- Japanese Yen (JPY)

### [GET] /rates/{base}/{quote}

This endpoint returns the exchange rate history for a pair of currencies, denoted by the _{base}_ and _{quote}_ path parameters.

For example, requesting _/rates/ZAR/USD_ will return the full Rand/Dollar exchange rate history.

### [GET] /quotes/{base}/{quote}?amount=_n_

This endpoint converts the specified nominal _{amount}_ from one currency to another using the **latest** available exchange rate for the currency pair.

For example, requesting _/convert/ZAR/USD?amount=100_ will return a quote response indicating the Dollar amount one can expect to receive when exchanging R100.

## Requirements

As we mentioned, the bones of the API are all set up, but we haven't actually met all of the requirements.

We're able to get a list of supported currencies using the _/currencies_ endpoint and that seems to work just fine, but the rest is half-baked or incomplete. This is where you come in! 👩‍💻💥

To make things even more challenging, we **only have exchange rates loaded for a single base currency in the database**!
That means that we only have the exchange rates for South African Rands (ZAR) to US Dollars, Euros, British Pounds and Japanese Yen, but not the other way around. We also don't have the exchange rates between the other currencies (e.g. Dollars to Pounds, Euros to Yen etc.), frustrating! 🤦‍♀️

- [x] Get a list of currencies
- [ ] Get the exchange rate history for a currency pair
    - [x] Direct lookup from the database
    - [ ] Inverse currency pair (e.g. USD/ZAR instead of ZAR/USD)
    - [ ] Derived exchange rate (e.g. USD/GBP)
- [ ] Currency conversion
    - [ ] Direct lookup of the latest exchange rate from the database
    - [ ] Inverse currency pair (e.g. USD/ZAR instead of ZAR/USD) latest exchange rate
    - [ ] Derived latest exchange rate (e.g. USD/GBP)
- [ ] Exception handling

To help guide you towards a solution, comments have been left in the codebase to deal with these unmet requirements.
Happy coding, superstar! ⚡