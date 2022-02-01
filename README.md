# Fundhouse FX specification

Thank you for taking the time to take our technical test. We've come up with a simple app specification and we really hope you have fun with this mini-project! 😃🚀

Please read the specification carefully to ensure that you have a firm understanding of the requirements. We've done our best to explain core concepts, but if any of this is unclear or unfamiliar to you, please feel free to send your questions to [📧dev@fundhouse.co.za](mailto:dev@fundhouse.co.za) at any time.

---

## What will you be building?

Fundhouse FX is a simple client-server application, similar to [xe.com](https:/xe.com/), which aims to provide accurate currency conversions and historical [spot exchange rates](https://www.investopedia.com/terms/s/spotexchangerate.asp) to end-users.

As the name implies, a *spot exchange rate* (or simply, *spot rate*) is the exchange ratio applied when one currency is exchanged for another. In simpler terms, the spot exchange rate is best thought of as how much you would have to pay in one currency to buy another at a point in time.

The value of one currency in relation to another is a complex topic, but essentially, these values (spot rates) are determined by buyer and seller activity within the global [foreign exchange market](https://www.investopedia.com/terms/forex/f/foreign-exchange-markets.asp).

The following table illustrates daily spot rates for the exchange of South African Rands (ZAR) for US Dollars (USD):

| Base Currency | Exchange Currency | Date | Value |
| - | - | - | - |
| ZAR | USD | 2021-11-30 | 0.06212 |
| ZAR | USD | 2021-11-29 | 0.06195 |
| ZAR | USD | 2021-11-28 | 0.06134 |
| ZAR | USD | 2021-11-27 | 0.06237 |
| ZAR | USD | 2021-11-26 | 0.06293 |
| ZAR | USD | 2021-11-25 | 0.06315 |

From this table, we can see that 1 ZAR could be exchanged for 0.06212 USD on the 30th of November 2021, but we can easily invert the *currency pair* to give us the exchange rate from USD to ZAR using the formula *1 / Value*:

| Base Currency | Exchange Currency | Date | Value |
| - | - | - | - |
| USD | ZAR | 2021-11-30 | 16.09787 |
| USD | ZAR | 2021-11-29 | 16.14205 |
| USD | ZAR | 2021-11-28 | 16.30257 |
| USD | ZAR | 2021-11-27 | 16.03334 |
| USD | ZAR | 2021-11-26 | 15.89067 |
| USD | ZAR | 2021-11-25 | 15.83531 |

### Functional requirements

Enough with the technical jargon, let's get down to functionality!

The application should provide the capability to answer the following questions:

**What is the converted nominal amount I'll receive when exchanging one currency for another?**

The user should be able to enter a nominal amount (e.g. 1,000), select a _base currency_ and a _quote currency_ and have the application perform the conversion.
For example, if I were to exchange R1,000 for US Dollars, I'd receive $65.00.

**What were the historic exchange rates between two currencies?**

The user should be able to select a base currency and an exchange currency to retrieve the full spot rate history for the selected currency pair.

### Non-functional requirements

- Ease-of-use (UX)
- Speed/Efficiency
- Data accuracy
- Exception handling & friendly error reporting

## The stack

There are two options for the Fundhouse FX API:

- [PHP](./fx-api-php/README.md)
- [ASP.NET Core](./fx-api-net/README.md)

> You are only required to complete **one** of the APIs relevant to your role

The front-end application is a simple [React](https://reactjs.org/) app which you can find under [/fx-app-react](./fx-app-react/README.md).

Each of the applications have their own README documents to get you up and running and to give you a better understanding of the specific tasks required to complete the solution.