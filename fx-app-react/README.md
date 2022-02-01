# Fundhouse FX

The Fundhouse FX app is a simple client app built with [React](https://reactjs.org/) which integrates with the Fundhouse FX API to produce spot-/exchange-rate history for a range of currencies and straightforward currency conversions.

## Getting started

1. Ensure that the Fundhouse FX API is running at [http://localhost:8080/](http://localhost:8080/)
2. Install [Node.js](https://nodejs.org/en/) (v16+)
3. Open a command prompt (Windows) or shell (Linux)
4. Execute the following commands:

```sh
# Install dependencies (before first run)
npm install

# Run the app in dev mode (with hot-reload)
npm run start
```

Navigate to [http://localhost:3000/](http://localhost:3000/) in your web browser to verify that the app is running.

## Requirements

This app was built in a real hurry and unfortunately, it's poorly structured and quite inefficient. The challenge for you is to refactor the application into a set of re-usable components and complete the integration with the FX API to meet the following functional requirements:

- [ ] Currency conversion form
  - [x] Get supported currencies from the API
  - [ ] Allow the user to enter a conversion amount
  - [ ] Allow the user to select a base currency
  - [ ] Allow the user to select a quote currency
- [ ] Conversion
  - [ ] Get the converted value (quote) from the API using the user's input
  - [ ] Display the conversion result
- [ ] Spot rate history
  - [ ] Get the spot rate history from the API using the user's input
  - [ ] Display the spot rate history (grid or chart)

You are free to make use of any third-party dependencies you wish (via NPM). You are also free to extend or improve the UX as you see fit.

Happy coding! 🚀👩‍🚀